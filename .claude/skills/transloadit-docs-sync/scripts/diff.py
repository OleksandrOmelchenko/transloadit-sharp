"""Diff a docs snapshot against the library (and against the last accepted baseline) and write the findings.

Usage:
  python -I diff.py --snapshot <docs-snapshot.json> --library <library.json> --repo <repo root>
                    --exceptions <known-exceptions.json> --out-dir <dir>
                    [--baseline <baseline.json>] [--previous-fingerprints <file>]

Writes into --out-dir:
  findings.json     every finding (suppressed ones flagged), machine-readable
  report.md         the human report; the blog section lists posts for Claude to triage
  issue-body.md     rolling GitHub issue body, ending with a hidden fingerprint list
  issue-comment.md  only when there are findings not in --previous-fingerprints

Sections:
  A  library gaps        - what to add/update in the library
  B  source divergence   - llms.txt / llms-full.txt / openapi.json disagreeing with the live site (site wins)
  C  upstream changes    - docs-side changes since the baseline, whether or not the library is affected
  D  blog                - new English posts since the baseline

Standard library only.
"""

import argparse
import fnmatch
import glob
import json
import os
import re

SITE = "https://transloadit.com"
BASE_PARAM_SHARE = 0.9
ISSUE_BODY_LIMIT = 60000

SECTION_TITLES = {
    "A": "Add or update in the library",
    "B": "Source divergence (llms.txt / llms-full.txt / OpenAPI vs the live site)",
    "C": "Upstream changes since the baseline",
    "D": "Blog posts to triage",
}


def load(path):
    with open(path, encoding="utf-8") as handle:
        return json.load(handle)


def robot_link(snapshot, path):
    robot = snapshot["robots"].get(path)
    slug = robot["slug"] if robot else path.lstrip("/").replace("/", "-")
    return f"{SITE}/docs/robots/{slug}/"


def short(text, limit=60):
    text = text or "?"
    return text if len(text) <= limit else text[: limit - 1].rstrip(" |") + "…"


def published(robot):
    return bool(robot) and robot["in_sitemap"] and robot["md_status"] == 200 and robot["stage"] not in ("removed", "deprecated")


class Findings:
    def __init__(self):
        self.items = []
        self._seen = set()

    def add(self, section, fingerprint, title, detail=None, fix=None, link=None, group=None, group_title=None, item=None):
        """`group` folds related findings into one report line: `group_title` (with `{n}` for the count) followed by
        each finding's `item`; fingerprints stay per finding so the issue can tell exactly what is new"""
        if fingerprint in self._seen:
            return
        self._seen.add(fingerprint)
        self.items.append({
            "section": section,
            "fingerprint": fingerprint,
            "title": title,
            "detail": detail,
            "fix": fix,
            "link": link,
            "group": group,
            "group_title": group_title,
            "item": item,
            "suppressed": None,
        })


# ---------------------------------------------------------------- library side


def library_endpoints(repo):
    """METHOD /normalized/path -> response type, scanned from the services' SendRequest<T>(HttpMethod.X, $"/path") calls"""
    endpoints = {}
    call = re.compile(r'SendRequest<(?P<type>[\w<>, ]+?)>\(\s*HttpMethod\.(?P<method>\w+),\s*\$?"(?P<path>/[^"]*)"')
    for source in sorted(glob.glob(os.path.join(repo, "src", "Transloadit", "Services", "*.cs"))):
        with open(source, encoding="utf-8-sig") as handle:
            text = handle.read()
        for match in call.finditer(text):
            key = f"{match['method'].upper()} {normalize_path(match['path'])}"
            endpoints.setdefault(key, match["type"].replace(" ", ""))
        if "SendTokenRequest" in text:
            endpoints.setdefault("POST /token", "TokenResponse")
    return endpoints


def normalize_path(path):
    return "/".join("{}" if "{" in segment else segment for segment in path.split("/"))


def parse_type(expression):
    """`PaginatedListResponse<AssemblyCompactResponse>` -> ("PaginatedListResponse`1", ["AssemblyCompactResponse"])"""
    match = re.match(r"^(\w+)<(.+)>$", expression)
    if not match:
        return expression, []
    depth, start, args = 0, 0, []
    inner = match.group(2)
    for index, char in enumerate(inner):
        if char == "<":
            depth += 1
        elif char == ">":
            depth -= 1
        elif char == "," and depth == 0:
            args.append(inner[start:index])
            start = index + 1
    args.append(inner[start:])
    return f"{match.group(1)}`{len(args)}", args


def missing_fields(tree, type_expression, types, prefix="", seen=None):
    """(model, field, json path) for every documented field the C# model graph does not map"""
    seen = seen or set()
    name, args = parse_type(type_expression)
    if (name, tuple(args)) in seen:
        return []
    seen = seen | {(name, tuple(args))}
    fields = types.get(name)
    if fields is None or not tree:
        return []
    display = type_expression
    found = []
    for field, subtree in sorted(tree.items()):
        if field not in fields:
            found.append((display, field, prefix + field))
            continue
        nested = fields[field]
        if nested and nested.startswith("$T"):
            position = int(nested[2:])
            nested = args[position] if position < len(args) else None
        if nested and subtree:
            found.extend(missing_fields(subtree, nested, types, prefix + field + ".", seen))
    return found


# ---------------------------------------------------------------- A: library gaps


def library_gaps(snapshot, library, repo, findings):
    robots_docs = snapshot["robots"]
    robots_lib = library["robots"]

    for path, robot in sorted(robots_docs.items()):
        if published(robot) and path not in robots_lib:
            findings.add("A", f"robot-missing:{path}", f"New robot `{path}` ({robot['stage']}): {robot['title']}",
                         detail=f"{len(robot['params_site'])} params", fix="add-robot", link=robot_link(snapshot, path))

    for path in sorted(robots_lib):
        robot = robots_docs.get(path)
        if not published(robot):
            state = "no docs source mentions it" if robot is None else (
                f"stage `{robot['stage']}`" if robot["stage"] in ("removed", "deprecated")
                else f"docs page HTTP {robot['md_status']}, in sitemap: {robot['in_sitemap']}")
            findings.add("A", f"robot-unpublished:{path}", f"Implemented robot `{path}` is no longer published ({state})",
                         detail=f"class `{robots_lib[path]['class']}`", fix="deprecate or remove the class",
                         link=robot_link(snapshot, path))

    # base-class params: a param the site lists on (almost) every robot of a base class but the library maps on
    # (almost) none is one gap on the base class, not dozens of per-robot gaps
    candidates = {}
    for path, lib in robots_lib.items():
        robot = robots_docs.get(path)
        if not published(robot) or not robot["params_site"]:
            continue
        for base in lib["bases"]:
            candidates.setdefault(base, []).append(path)

    flagged = {}  # base -> params flagged on it (also applies to every subclass)
    ordered_bases = sorted(candidates, key=lambda b: -len(candidates[b]))  # broadest first
    for base in ordered_bases:
        members = candidates[base]
        if len(members) < 3:
            continue
        counts = {}
        for path in members:
            lib_params = set(robots_lib[path]["params"])
            for param in robots_docs[path]["params_site"]:
                if param not in lib_params:
                    counts[param] = counts.get(param, 0) + 1
        for param, count in sorted(counts.items()):
            if count >= BASE_PARAM_SHARE * len(members):
                inherited = any(param in flagged.get(other, set()) for other in robots_lib[members[0]]["bases"] if other != base)
                if inherited:
                    continue
                flagged.setdefault(base, set()).add(param)
                findings.add("A", f"base-param-missing:{base}:{param}",
                             f"`{param}` is documented on {count} of {len(members)} robots deriving from `{base}` but mapped on none of them",
                             detail="add it once to the base class", fix=f"add `{param}` to `{base}`")

    for path, lib in sorted(robots_lib.items()):
        robot = robots_docs.get(path)
        if not published(robot) or not robot["params_site"]:
            continue
        lib_params = set(lib["params"]) - {"robot"}
        site_params = set(robot["params_site"]) - {"robot"}
        covered_by_base = set().union(*(flagged.get(base, set()) for base in lib["bases"]))
        for param in sorted(site_params - lib_params - covered_by_base):
            findings.add("A", f"robot-param-missing:{path}:{param}",
                         f"`{path}` is missing `{param}` (`{short(robot['params_site'][param])}`)",
                         fix="add-robot (update)", link=robot_link(snapshot, path),
                         group=f"robot-param-missing:{path}",
                         group_title=f"`{path}` (`{lib['class']}`) is missing {{n}} documented param(s):",
                         item=f"`{param}` ({short(robot['params_site'][param])})")
        for param in sorted(lib_params - site_params):
            findings.add("A", f"robot-param-undocumented:{path}:{param}",
                         f"`{path}` maps `{param}`, which its docs page no longer lists",
                         fix="check upstream; rename or remove", link=robot_link(snapshot, path),
                         group=f"robot-param-undocumented:{path}",
                         group_title=f"`{path}` (`{lib['class']}`) maps {{n}} param(s) its docs page does not list (renamed or removed?):",
                         item=f"`{param}`")

    endpoints_lib = library_endpoints(repo)
    for key, endpoint in sorted(snapshot["endpoints"].items()):
        if key not in endpoints_lib:
            area = "/" + key.split(" ", 1)[1].strip("/").split("/")[0]
            findings.add("A", f"endpoint-missing:{key}", f"Endpoint `{key}` is not implemented",
                         detail=endpoint["summary"] or endpoint["path"], fix="add-service-endpoint",
                         link=endpoint["docs"] or f"{SITE}/docs/api/",
                         group=f"endpoint-missing:{area}",
                         group_title=f"`{area}`: {{n}} endpoint(s) not implemented:",
                         item=f"`{key}` {endpoint['summary']}".rstrip())

    # response fields, deduplicated per model field (one model often backs several endpoints)
    gaps = {}
    for key, type_expression in sorted(endpoints_lib.items()):
        endpoint = snapshot["endpoints"].get(key)
        if not endpoint or not endpoint["response_fields"]:
            continue
        for model, field, json_path in missing_fields(endpoint["response_fields"], type_expression, library["types"]):
            gaps.setdefault((model, field), []).append(f"{key} → `{json_path}`")
    if snapshot.get("notification_payload"):
        for model, field, json_path in missing_fields(snapshot["notification_payload"], "AssemblyResponse", library["types"]):
            gaps.setdefault((model, field), []).append(f"notification payload → `{json_path}`")
    sources = {}
    for (model, _), where in gaps.items():
        sources.setdefault(model, set()).update(w.split(" → ")[0] for w in where)
    for (model, field), where in sorted(gaps.items()):
        seen_in = sorted(sources[model])
        findings.add("A", f"model-field-missing:{model}:{field}", f"`{model}` does not map response field `{field}`",
                     detail="; ".join(where[:3]) + (f" (+{len(where) - 3} more)" if len(where) > 3 else ""),
                     fix="add the property with [TransloaditJsonName]",
                     group=f"model-field-missing:{model}",
                     group_title=f"`{model}` does not map {{n}} documented response field(s) (seen in `{seen_in[0]}`"
                                 + (f" and {len(seen_in) - 1} more" if len(seen_in) > 1 else "") + "):",
                     item=f"`{field}`")

    documented_types = set(snapshot["credential_types"])
    library_types = set(library["credential_types"])
    for credential_type in sorted(documented_types - library_types):
        findings.add("A", f"credential-type-missing:{credential_type}", f"Credential type `{credential_type}` is not implemented",
                     fix="add-credentials", link=f"{SITE}/docs/api/template-credentials-types-get/")
    for credential_type in sorted(library_types - documented_types):
        findings.add("A", f"credential-type-undocumented:{credential_type}",
                     f"Credential type `{credential_type}` (`{library['credential_types'][credential_type]}`) is not in the OpenAPI type enum",
                     fix="check upstream; deprecate if removed")


# ---------------------------------------------------------------- B: source divergence


def source_divergence(snapshot, findings):
    for path, robot in sorted(snapshot["robots"].items()):
        live = published(robot)
        sources = {"llms.txt": robot["in_llms_index"], "llms-full.txt": robot["in_llms_full"], "openapi.json": robot["in_openapi"]}
        if live:
            for source, present in sources.items():
                if not present:
                    findings.add("B", f"source-missing-robot:{source}:{path}",
                                 f"`{path}` is published but absent from {source}", link=robot_link(snapshot, path))
        else:
            listed = [source for source, present in sources.items() if present]
            if listed:
                state = f"stage `{robot['stage']}`" if robot["stage"] in ("removed", "deprecated") else f"docs page HTTP {robot['md_status']}"
                findings.add("B", f"source-stale-robot:{path}",
                             f"`{path}` is not published ({state}) but {', '.join(listed)} still list it",
                             link=robot_link(snapshot, path))
        if live and robot["params_site"]:
            site = set(robot["params_site"]) - {"robot"}
            for source, params in (("llms-full.txt", robot["params_llms_full"]), ("openapi.json", robot["params_openapi"])):
                other = set(params) - {"robot"}
                if params and other != site:
                    findings.add("B", f"source-params:{source}:{path}",
                                 f"`{path}` params in {source} differ from the site",
                                 detail=f"only on site: {sorted(site - other)}; only in {source}: {sorted(other - site)}",
                                 link=robot_link(snapshot, path))


# ---------------------------------------------------------------- C: upstream changes


def flatten(tree, prefix=""):
    paths = set()
    for field, subtree in (tree or {}).items():
        paths.add(prefix + field)
        if subtree:
            paths |= flatten(subtree, prefix + field + ".")
    return paths


def upstream_changes(snapshot, baseline, findings):
    old_robots, new_robots = baseline["robots"], snapshot["robots"]
    for path in sorted(set(old_robots) | set(new_robots)):
        old, new = old_robots.get(path), new_robots.get(path)
        link = robot_link(snapshot, path)
        if published(new) and not published(old):
            findings.add("C", f"upstream-robot-published:{path}", f"`{path}` was published", link=link)
        if published(old) and not published(new):
            findings.add("C", f"upstream-robot-unpublished:{path}", f"`{path}` was unpublished or removed", link=link)
        if old and new and old["stage"] != new["stage"]:
            findings.add("C", f"upstream-stage:{path}:{old['stage']}->{new['stage']}",
                         f"`{path}` stage changed `{old['stage']}` → `{new['stage']}`", link=link)
        if old and new:
            old_params, new_params = old["params_site"], new["params_site"]
            for param in sorted(set(new_params) - set(old_params)):
                findings.add("C", f"upstream-param-added:{path}:{param}", f"`{path}` gained `{param}`", link=link,
                             group=f"upstream-param-added:{path}", group_title=f"`{path}` gained {{n}} param(s):",
                             item=f"`{param}` ({short(new_params[param])})")
            for param in sorted(set(old_params) - set(new_params)):
                findings.add("C", f"upstream-param-removed:{path}:{param}", f"`{path}` dropped `{param}`", link=link,
                             group=f"upstream-param-removed:{path}", group_title=f"`{path}` dropped {{n}} param(s):",
                             item=f"`{param}`")
            for param in sorted(set(old_params) & set(new_params)):
                if old_params[param] != new_params[param]:
                    findings.add("C", f"upstream-param-type:{path}:{param}", f"`{path}` `{param}` type changed", link=link,
                                 group=f"upstream-param-type:{path}", group_title=f"`{path}` changed the type of {{n}} param(s):",
                                 item=f"`{param}` `{short(old_params[param])}` → `{short(new_params[param])}`")

    old_endpoints, new_endpoints = baseline["endpoints"], snapshot["endpoints"]
    for key in sorted(set(new_endpoints) - set(old_endpoints)):
        findings.add("C", f"upstream-endpoint-added:{key}", f"Endpoint `{key}` was added", detail=new_endpoints[key]["summary"])
    for key in sorted(set(old_endpoints) - set(new_endpoints)):
        findings.add("C", f"upstream-endpoint-removed:{key}", f"Endpoint `{key}` was removed")
    for key in sorted(set(old_endpoints) & set(new_endpoints)):
        old_fields = flatten(old_endpoints[key]["response_fields"])
        new_fields = flatten(new_endpoints[key]["response_fields"])
        for field in sorted(new_fields - old_fields):
            findings.add("C", f"upstream-field-added:{key}:{field}", f"`{key}` response gained `{field}`",
                         group=f"upstream-field-added:{key}", group_title=f"`{key}` response gained {{n}} field(s):", item=f"`{field}`")
        for field in sorted(old_fields - new_fields):
            findings.add("C", f"upstream-field-removed:{key}:{field}", f"`{key}` response dropped `{field}`",
                         group=f"upstream-field-removed:{key}", group_title=f"`{key}` response dropped {{n}} field(s):", item=f"`{field}`")

    old_types, new_types = set(baseline["credential_types"]), set(snapshot["credential_types"])
    for credential_type in sorted(new_types - old_types):
        findings.add("C", f"upstream-credential-type-added:{credential_type}", f"Credential type `{credential_type}` was added")
    for credential_type in sorted(old_types - new_types):
        findings.add("C", f"upstream-credential-type-removed:{credential_type}", f"Credential type `{credential_type}` was removed")


# ---------------------------------------------------------------- D: blog


def blog_posts(snapshot, baseline, findings):
    seen = {post["url"] for post in (baseline or {}).get("blog", {}).get("posts", [])}
    for post in snapshot["blog"]["posts"]:
        if post["url"] not in seen:
            findings.add("D", f"blog:{post['url']}", post["title"] or post["url"], detail=post["date"] or post["month"], link=post["url"])


# ---------------------------------------------------------------- exceptions


def apply_exceptions(findings, exceptions, snapshot):
    """suppress findings matching a recorded exception; an exception whose `while` no longer holds resurfaces"""
    stale = []
    for exception in exceptions.get("exceptions", []):
        condition = exception.get("while")
        holds = True
        if condition:
            robot = snapshot["robots"].get(condition.get("robot"), {})
            holds = all(robot.get(field) == value for field, value in condition.items() if field != "robot")
        matched = [f for f in findings.items if fnmatch.fnmatchcase(f["fingerprint"], exception["match"])]
        if holds:
            for finding in matched:
                finding["suppressed"] = exception["reason"]
        elif matched or condition:
            stale.append(exception)
    for exception in stale:
        findings.add("A", f"exception-stale:{exception['match']}",
                     f"Recorded exception `{exception['match']}` no longer holds",
                     detail=f"recorded reason: {exception['reason']}; condition now false: {json.dumps(exception.get('while'))}",
                     fix="re-evaluate, then update or delete it in known-exceptions.json")


# ---------------------------------------------------------------- output


def render_item(finding):
    line = f"- {finding['title']}"
    if finding["detail"]:
        line += f" — {finding['detail']}"
    if finding["fix"]:
        line += f" — *fix: {finding['fix']}*"
    if finding["link"]:
        line += f" ([docs]({finding['link']}))"
    return line


def render_group(members):
    first = members[0]
    line = "- " + first["group_title"].replace("{n}", str(len(members))) + " " + ", ".join(m["item"] for m in members)
    if first["fix"]:
        line += f" — *fix: {first['fix']}*"
    if first["link"]:
        line += f" ([docs]({first['link']}))"
    return line


def render_sections(items, include_d_note):
    lines = []
    for section in "ACDB":
        active = [f for f in items if f["section"] == section and not f["suppressed"]]
        if not active:
            continue
        lines.append(f"## {section}. {SECTION_TITLES[section]} ({len(active)})")
        lines.append("")
        if section == "D" and include_d_note:
            lines.append("> Triage pending: read the API-relevant posts and link each announcement to an A finding.")
            lines.append("")
        groups = {}
        for finding in active:
            groups.setdefault(finding["group"] or finding["fingerprint"], []).append(finding)
        for members in groups.values():
            lines.append(render_group(members) if members[0]["group"] else render_item(members[0]))
        lines.append("")
    return lines


def summary(items):
    counts = {s: sum(1 for f in items if f["section"] == s and not f["suppressed"]) for s in "ABCD"}
    suppressed = sum(1 for f in items if f["suppressed"])
    return counts, suppressed


def write(path, text):
    with open(path, "w", encoding="utf-8", newline="\n") as handle:
        handle.write(text)


def main():
    parser = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    parser.add_argument("--snapshot", required=True)
    parser.add_argument("--library", required=True)
    parser.add_argument("--repo", required=True)
    parser.add_argument("--exceptions", required=True)
    parser.add_argument("--out-dir", required=True)
    parser.add_argument("--baseline")
    parser.add_argument("--previous-fingerprints")
    args = parser.parse_args()

    snapshot = load(args.snapshot)
    library = load(args.library)
    exceptions = load(args.exceptions)
    baseline = load(args.baseline) if args.baseline and os.path.exists(args.baseline) else None

    findings = Findings()
    library_gaps(snapshot, library, args.repo, findings)
    source_divergence(snapshot, findings)
    if baseline:
        upstream_changes(snapshot, baseline, findings)
    blog_posts(snapshot, baseline, findings)
    apply_exceptions(findings, exceptions, snapshot)

    items = findings.items
    counts, suppressed = summary(items)
    os.makedirs(args.out_dir, exist_ok=True)
    write(os.path.join(args.out_dir, "findings.json"), json.dumps(items, indent=1, ensure_ascii=False) + "\n")

    robots = snapshot["robots"]
    header = [
        f"Docs: {sum(1 for r in robots.values() if published(r))} published robots, {len(snapshot['endpoints'])} API operations, "
        f"{len(snapshot['credential_types'])} credential types. Library: {len(library['robots'])} robots, "
        f"{len(library_endpoints(args.repo))} endpoints, {len(library['credential_types'])} credential types.",
        "",
        f"Findings: **A {counts['A']}** · C {counts['C']} · D {counts['D']} · B {counts['B']} · suppressed {suppressed}"
        + ("" if baseline else " · *no baseline: section C skipped*"),
        "",
    ]

    report = ["# Transloadit docs sync report", ""] + header + render_sections(items, include_d_note=True)
    suppressed_items = [f for f in items if f["suppressed"]]
    if suppressed_items:
        report += [f"## Suppressed by known-exceptions.json ({len(suppressed_items)})", ""]
        report += [f"- `{f['fingerprint']}` — {f['suppressed']}" for f in suppressed_items]
        report.append("")
    write(os.path.join(args.out_dir, "report.md"), "\n".join(report))

    active = [f for f in items if not f["suppressed"]]
    fingerprints = sorted(f["fingerprint"] for f in active)
    body = ["Rolling report maintained by the `transloadit-docs-sync` skill. Each run updates this body; "
            "new findings are also posted as a comment.", ""] + header + render_sections(items, include_d_note=False)
    body_text = "\n".join(body)
    if len(body_text) > ISSUE_BODY_LIMIT:
        body_text = body_text[:ISSUE_BODY_LIMIT].rsplit("\n", 1)[0] + "\n\n*…truncated; see the local report for the rest.*\n"
    body_text += "\n<!-- docs-sync-fingerprints\n" + "\n".join(fingerprints) + "\n-->\n"
    write(os.path.join(args.out_dir, "issue-body.md"), body_text)

    comment_path = os.path.join(args.out_dir, "issue-comment.md")
    previous = set()
    if args.previous_fingerprints and os.path.exists(args.previous_fingerprints):
        with open(args.previous_fingerprints, encoding="utf-8") as handle:
            previous = {line.strip() for line in handle if line.strip()}
    new_items = [f for f in active if f["fingerprint"] not in previous]
    if new_items:
        comment = [f"**{len(new_items)} new finding(s)** since the last run:", ""] + render_sections(new_items, include_d_note=False)
        write(comment_path, "\n".join(comment))
    elif os.path.exists(comment_path):
        os.remove(comment_path)

    # console output stays ascii: a scheduled run's console may not be utf-8 (the files are)
    print(f"A {counts['A']} | C {counts['C']} | D {counts['D']} | B {counts['B']} | suppressed {suppressed} | new {len(new_items)}")
    print(f"wrote {args.out_dir}")


if __name__ == "__main__":
    main()
