"""Snapshot the Transloadit documentation sources into one normalized, deterministic JSON file.

Sources, strongest first:
  * live robot pages  - sitemap.xml membership + https://transloadit.com/docs/robots/<slug>.md (params, stage)
  * openapi.json      - REST operations, response fields, credential types, robot step schemas
  * llms-full.txt     - robot params as `##### \\`param\\`` headings (lags the site)
  * llms.txt          - robot index, plus the robot catalog docs/robots/llms.txt (lags the site)
  * blog              - English posts since a cursor month, title + date from the post's .md

Usage:
  python -I snapshot_docs.py --work <fresh empty dir> --out <docs-snapshot.json> [--blog-since YYYY-MM]

The output has no timestamps or volatile fields, so two runs against unchanged docs are byte-identical.
Standard library only.
"""

import argparse
import datetime
import json
import os
import re
import sys
import time
import urllib.error
import urllib.request

SITE = "https://transloadit.com"
USER_AGENT = "transloadit-sharp-docs-sync/1.0 (+https://github.com/OleksandrOmelchenko/transloadit-sharp)"
DELAY_SECONDS = 0.15
MAX_RESPONSE_DEPTH = 4

ROBOT_PATH_RE = re.compile(r"^/[a-z0-9]+/[a-z0-9]+$")


def fetch(url, work, name, allow_missing=False):
    """Download url into work/name and return (status, text). Retries transient failures."""
    target = os.path.join(work, name)
    last_error = None
    for attempt in range(3):
        try:
            request = urllib.request.Request(url, headers={"User-Agent": USER_AGENT})
            with urllib.request.urlopen(request, timeout=60) as response:
                body = response.read().decode("utf-8", errors="replace")
            with open(target, "w", encoding="utf-8", newline="\n") as handle:
                handle.write(body)
            time.sleep(DELAY_SECONDS)
            return response.status, body
        except urllib.error.HTTPError as error:
            if error.code == 404 and allow_missing:
                time.sleep(DELAY_SECONDS)
                return 404, ""
            last_error = error
        except (urllib.error.URLError, TimeoutError, ConnectionError) as error:
            last_error = error
        time.sleep(2 * (attempt + 1))
    raise RuntimeError(f"failed to fetch {url}: {last_error}")


def slug_of(robot_path):
    return robot_path.lstrip("/").replace("/", "-")


# ---------------------------------------------------------------- robots: index sources


def sitemap_slugs(sitemap):
    return set(re.findall(r"<loc>https://transloadit\.com/docs/robots/([a-z0-9-]+)/</loc>", sitemap))


def llms_index_robots(*indexes):
    # entries look like `- [/image/resize](https://transloadit.com/docs/robots/image-resize.md)`, sometimes with
    # the path in backticks
    pattern = re.compile(r"\[`?(/[a-z0-9]+/[a-z0-9]+)`?\]\(https://transloadit\.com/docs/robots/")
    return {path for index in indexes for path in pattern.findall(index)}


def llms_full_robot_params(llms_full):
    """Robot params from the `### Robot parameters` section: `#### `/x/y`: title` then `##### `param``.

    Robot prose inside the section contains its own `##`/`###` headings, so only a new robot heading switches
    the current robot; the section ends at the machine-readable index list."""
    robots = {}
    current = None
    in_section = False
    for line in llms_full.splitlines():
        if line.startswith("### Robot parameters"):
            in_section = True
            continue
        if not in_section:
            continue
        if line.startswith("## Machine-readable indexes"):
            break
        robot = re.match(r"^#### `(/[a-z0-9]+/[a-z0-9]+)`", line)
        if robot:
            current = robot.group(1)
            robots.setdefault(current, set())
            continue
        param = re.match(r"^##### `([A-Za-z0-9_]+)`", line)
        if param and current:
            robots[current].add(param.group(1))
    return {path: sorted(params) for path, params in robots.items()}


def parse_robot_md(markdown):
    title = None
    stage = None
    params = {}
    in_params = False
    current = None
    for line in markdown.splitlines():
        if title is None and line.startswith("# "):
            title = line[2:].strip()
        stage_match = re.match(r"^Stage:\s*`?([A-Za-z-]+)`?\s*$", line)
        if stage is None and stage_match:
            stage = stage_match.group(1).lower()
        if line.startswith("## "):
            in_params = line.strip() == "## Parameters"
            current = None
            continue
        if not in_params:
            continue
        param = re.match(r"^### `([A-Za-z0-9_]+)`", line)
        if param:
            current = param.group(1)
            params[current] = None
            continue
        if line.startswith("#"):
            current = None
            continue
        type_match = re.match(r"^Type:\s*(.+?)\s*$", line)
        if type_match and current and params[current] is None:
            params[current] = type_match.group(1).replace("`", "")
    return title, stage, params


# ---------------------------------------------------------------- openapi


class OpenApi:
    def __init__(self, document):
        self.document = document
        self.schemas = document.get("components", {}).get("schemas", {})

    def resolve(self, schema):
        seen = 0
        while isinstance(schema, dict) and "$ref" in schema and seen < 50:
            schema = self.schemas.get(schema["$ref"].split("/")[-1], {})
            seen += 1
        return schema if isinstance(schema, dict) else {}

    @staticmethod
    def is_error_variant(schema):
        required = schema.get("required") or []
        return "error" in required and "ok" not in required

    def object_properties(self, schema, drop_error_variants=False):
        """properties of an object schema, flattening allOf/anyOf/oneOf (error-only variants optionally skipped)"""
        schema = self.resolve(schema)
        merged = {}
        for key in ("allOf", "anyOf", "oneOf"):
            for variant in schema.get(key, []):
                resolved = self.resolve(variant)
                if drop_error_variants and self.is_error_variant(resolved):
                    continue
                merged.update(self.object_properties(resolved, drop_error_variants))
        merged.update(schema.get("properties", {}))
        return merged

    def container_element(self, schema):
        """unwrap arrays, maps (additionalProperties) and nullable unions down to an object schema, if any"""
        schema = self.resolve(schema)
        for _ in range(8):
            if schema.get("type") == "array" or "items" in schema:
                schema = self.resolve(schema.get("items", {}))
                continue
            additional = schema.get("additionalProperties")
            if isinstance(additional, dict) and not schema.get("properties"):
                schema = self.resolve(additional)
                continue
            variants = [self.resolve(v) for v in schema.get("anyOf", []) + schema.get("oneOf", [])]
            structured = [v for v in variants if v.get("type") not in ("null", "string", "number", "integer", "boolean")]
            if variants and not schema.get("properties") and len(structured) == 1:
                schema = structured[0]
                continue
            break
        return schema

    def field_tree(self, schema, depth=0, drop_error_variants=False):
        """{field: subtree | None} for an object schema; containers are unwrapped transparently"""
        element = self.container_element(schema)
        properties = self.object_properties(element, drop_error_variants)
        if not properties or depth >= MAX_RESPONSE_DEPTH:
            return None
        tree = {}
        for name in sorted(properties):
            tree[name] = self.field_tree(properties[name], depth + 1)
        return tree

    def response_schema(self, operation):
        responses = operation.get("responses", {})
        for code in ("200", "201", "2XX", "default"):
            content = responses.get(code, {}).get("content", {})
            for media in ("application/json", *content.keys()):
                if media in content and "schema" in content[media]:
                    return content[media]["schema"]
        return None

    def operations(self):
        result = {}
        for path, item in self.document.get("paths", {}).items():
            for method, operation in item.items():
                if method not in ("get", "post", "put", "patch", "delete", "head", "options"):
                    continue
                key = f"{method.upper()} {normalize_path(path)}"
                schema = self.response_schema(operation)
                result[key] = {
                    "path": path,
                    "summary": (operation.get("summary") or "").strip(),
                    "docs": (operation.get("externalDocs") or {}).get("url"),
                    "response_fields": self.field_tree(schema, drop_error_variants=True) if schema else None,
                }
        return result

    def credential_types(self):
        found = set()

        def walk(node):
            if isinstance(node, dict):
                properties = node.get("properties")
                if isinstance(properties, dict) and isinstance(properties.get("type"), dict):
                    enum = self.resolve(properties["type"]).get("enum")
                    if isinstance(enum, list) and "s3" in enum:
                        found.update(e for e in enum if isinstance(e, str))
                for value in node.values():
                    walk(value)
            elif isinstance(node, list):
                for value in node:
                    walk(value)

        walk(self.schemas)
        return sorted(found)

    def robot_params(self):
        """robot path -> params, from the step union (the schema whose map values are robot variants)"""
        best = {}
        for schema in self.schemas.values():
            additional = schema.get("additionalProperties") if isinstance(schema, dict) else None
            if not isinstance(additional, dict):
                continue
            variants = additional.get("anyOf") or additional.get("oneOf") or []
            robots = {}
            for variant in variants:
                properties = self.object_properties(variant)
                robot = self.resolve(properties.get("robot", {}))
                path = robot.get("const") or ((robot.get("enum") or [None])[0])
                if isinstance(path, str) and ROBOT_PATH_RE.match(path):
                    robots[path] = sorted(p for p in properties if p != "robot")
            if len(robots) > len(best):
                best = robots
        return best

    def notification_payload(self):
        schema = self.schemas.get("assemblyNotificationPayload")
        return self.field_tree(schema, drop_error_variants=True) if schema else None


def normalize_path(path):
    return "/".join("{}" if "{" in segment else segment for segment in path.split("/"))


# ---------------------------------------------------------------- blog


def blog_posts(sitemap, since):
    """English blog post urls (`/blog/YYYY/MM/<slug>/`) at or after the `since` month"""
    posts = set()
    for year, month, slug in re.findall(r"<loc>https://transloadit\.com/blog/(\d{4})/(\d{2})/([a-z0-9-]+)/</loc>", sitemap):
        if f"{year}-{month}" >= since:
            posts.add((f"{year}-{month}", f"{SITE}/blog/{year}/{month}/{slug}/"))
    return sorted(posts, reverse=True)


def parse_blog_md(markdown):
    title = None
    date = None
    for line in markdown.splitlines()[:40]:
        stripped = line.strip()
        # the first line is the publish date, optionally followed by `· Updated <date>`
        published = re.match(r"^([A-Z][a-z]{2} \d{1,2}, \d{4})", stripped)
        if date is None and published:
            date = datetime.datetime.strptime(published.group(1), "%b %d, %Y").date().isoformat()
            continue
        if title is None and stripped.startswith("# "):
            title = stripped[2:].strip()
        if title and date:
            break
    return title, date


# ---------------------------------------------------------------- main


def main():
    parser = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    parser.add_argument("--work", required=True, help="fresh, empty directory for raw downloads")
    parser.add_argument("--out", required=True, help="path of the normalized snapshot JSON to write")
    parser.add_argument("--blog-since", help="first blog month to include, YYYY-MM (default: from --baseline, else 90 days ago)")
    parser.add_argument("--baseline", help="accepted baseline; its newest blog month becomes the default --blog-since")
    args = parser.parse_args()

    os.makedirs(args.work, exist_ok=True)
    if os.listdir(args.work):
        sys.exit(f"--work must be an empty directory: {args.work}")
    for sub in ("robots", "blog"):
        os.makedirs(os.path.join(args.work, sub))

    since = args.blog_since
    if not since and args.baseline and os.path.exists(args.baseline):
        with open(args.baseline, encoding="utf-8") as handle:
            months = [post["month"] for post in json.load(handle).get("blog", {}).get("posts", [])]
        # re-read the newest accepted month: posts published later that month are not in the baseline yet
        since = max(months) if months else None
    since = since or (datetime.date.today() - datetime.timedelta(days=90)).strftime("%Y-%m")

    _, sitemap = fetch(f"{SITE}/sitemap.xml", args.work, "sitemap.xml")
    _, llms = fetch(f"{SITE}/llms.txt", args.work, "llms.txt")
    _, robots_llms = fetch(f"{SITE}/docs/robots/llms.txt", args.work, "robots-llms.txt")
    _, llms_full = fetch(f"{SITE}/llms-full.txt", args.work, "llms-full.txt")
    _, openapi_text = fetch(f"{SITE}/openapi.json", args.work, "openapi.json")
    openapi = OpenApi(json.loads(openapi_text))

    in_sitemap = sitemap_slugs(sitemap)
    in_llms_index = llms_index_robots(llms, robots_llms)
    llms_full_params = llms_full_robot_params(llms_full)
    openapi_params = openapi.robot_params()
    operations = openapi.operations()

    # refuse to produce a snapshot from a broken fetch: an empty source would read as "everything was removed"
    problems = []
    if len(in_sitemap) < 50:
        problems.append(f"sitemap lists only {len(in_sitemap)} robot pages")
    if len(in_llms_index) < 50:
        problems.append(f"llms.txt lists only {len(in_llms_index)} robots")
    if len(openapi_params) < 50:
        problems.append(f"openapi.json step schema yields only {len(openapi_params)} robots")
    if len(operations) < 20:
        problems.append(f"openapi.json has only {len(operations)} operations")
    if problems:
        sys.exit("aborting, the docs sources look broken: " + "; ".join(problems))

    # every robot any source mentions; sitemap slugs map back to paths via the other sources
    paths_by_slug = {slug_of(p): p for p in in_llms_index | set(llms_full_params) | set(openapi_params)}
    all_paths = set(paths_by_slug.values())
    for slug in in_sitemap:
        path = paths_by_slug.get(slug, "/" + slug.replace("-", "/", 1))
        # docs/robots/ also hosts non-robot pages (e.g. `pricing`, `downloading`)
        if ROBOT_PATH_RE.match(path):
            all_paths.add(path)

    robots = {}
    for path in sorted(all_paths):
        slug = slug_of(path)
        status, markdown = fetch(f"{SITE}/docs/robots/{slug}.md", args.work, f"robots/{slug}.md", allow_missing=True)
        title, stage, params_md = parse_robot_md(markdown) if status == 200 else (None, None, {})
        robots[path] = {
            "slug": slug,
            "in_sitemap": slug in in_sitemap,
            "in_llms_index": path in in_llms_index,
            "in_llms_full": path in llms_full_params,
            "in_openapi": path in openapi_params,
            "md_status": status,
            "title": title,
            "stage": stage,
            "params_site": params_md,
            "params_llms_full": llms_full_params.get(path, []),
            "params_openapi": openapi_params.get(path, []),
        }

    posts = []
    for month, url in blog_posts(sitemap, since):
        name = url.rstrip("/").split("/")[-1]
        status, markdown = fetch(url.rstrip("/") + ".md", args.work, f"blog/{month}-{name}.md", allow_missing=True)
        title, date = parse_blog_md(markdown) if status == 200 else (None, None)
        posts.append({"url": url, "month": month, "date": date, "title": title})
    posts.sort(key=lambda p: (p["date"] or p["month"], p["url"]), reverse=True)

    snapshot = {
        "schema": 1,
        "robots": robots,
        "endpoints": operations,
        "notification_payload": openapi.notification_payload(),
        "credential_types": openapi.credential_types(),
        "blog": {"since": since, "posts": posts},
    }
    with open(args.out, "w", encoding="utf-8", newline="\n") as handle:
        json.dump(snapshot, handle, indent=1, sort_keys=True, ensure_ascii=False)
        handle.write("\n")

    print(f"robots: {len(robots)} total, {sum(r['in_sitemap'] for r in robots.values())} in sitemap, {len(in_llms_index)} in llms.txt, "
          f"{len(llms_full_params)} in llms-full, {len(openapi_params)} in openapi")
    print(f"endpoints: {len(operations)}; credential types: {len(snapshot['credential_types'])}; "
          f"blog posts since {since}: {len(posts)}")
    print(f"wrote {args.out}")


if __name__ == "__main__":
    main()
