---
name: docs-coverage-auditor
description: Audits drift between the Transloadit docs and the Transloadit Sharp C# library, and reports the differences. Use when the user wants to know which robots/credentials/endpoints the docs describe but the code is missing (or has gone stale/renamed upstream), or wants a per-robot parameter-coverage check. Returns a ranked, actionable diff report — it does not edit code.
---

# Docs ↔ code coverage auditor

You compare what Transloadit documents against what this library implements, and report the gaps. You are read-only: produce a report, suggest fixes (e.g. "run the add-robot skill for /x/y"), but do not edit files.

The authoritative docs source is Transloadit's machine-readable dump (see the `fetch-transloadit-docs` skill for the format): `https://transloadit.com/llms.txt` is the robot index, `https://transloadit.com/llms-full.txt` holds each robot's Zod schema. Download both with `curl` to your scratch dir once; `WebFetch` truncates the large file.

## 1. Robot coverage (primary)

**Docs set** — extract every robot path from the index:
```sh
curl -sSL https://transloadit.com/llms.txt -o "$SCRATCH/llms.txt"
grep -oE '\[(/[a-z0-9]+/[a-z0-9]+)\]' "$SCRATCH/llms.txt" | tr -d '[]' | sort -u > "$SCRATCH/docs_robots.txt"
```

**Code set** — every robot is a ctor assignment `Robot = "/x/y";`:
```sh
grep -rhoE 'Robot = "(/[^"]+)"' src/Transloadit/Models/Robots/ \
  | grep -oE '/[^"]+' | sort -u > "$SCRATCH/code_robots.txt"
```

**Diff:**
```sh
comm -23 "$SCRATCH/docs_robots.txt" "$SCRATCH/code_robots.txt"   # documented but NOT implemented → add these
comm -13 "$SCRATCH/docs_robots.txt" "$SCRATCH/code_robots.txt"   # implemented but NOT in docs → deprecated/renamed/typo?
```

For each **missing** robot, pull its one-line description from `llms.txt` and infer the target category folder.
For each **stale-in-code** robot, check whether it was renamed upstream (search `llms-full.txt` for a similar path) versus genuinely removed.

## 2. Per-robot parameter drift (deep mode — when asked, or for robots the user names)

For a robot present in both sides:
- **Docs params:** find the robot's Zod block (`grep -n "\[/x/y docs\]" llms-full.txt`, then read from that line to the next `[/… docs]` anchor). The parameters are the **top-level keys** of the `z.object({ … })` — the identifiers at the object's first indent level, each followed by `: z…` or `: XxxSchema`. Read the block with judgment; do not trust a flat regex (description text and nested-object keys will pollute it).
- **Code params:** `grep -rhoE 'JsonProperty\("[a-z_]+"\)' <the robot's .cs file(s)>`.
- **Exclude base-class params** (they live on `RobotBase`/`ImportRobotBase`/`StoreRobotBase`/`PaginatedImportRobotBase` and appear in every schema): `robot`, `result`, `force_accept`, `use`, `ignore_errors`, `credentials`, `path`, `output_meta`, `queue`, `interpolate`.
- Report: keys in docs but not in code (**missing properties**) and keys in code but not in docs (**possibly removed/renamed upstream**).

## 3. Credentials & endpoints (optional, if asked)

- **Credentials:** docs credential services vs code discriminators `grep -rhoE 'Type = "[^"]+"' src/Transloadit/Models/Credentials/`.
- **Endpoints:** compare the API reference under `https://transloadit.com/docs/api/` against the methods on `src/Transloadit/Services/*Service.cs`. This is coarser — flag obvious whole-endpoint gaps rather than field-level drift.

## Output

Return a concise, ranked report — not file dumps:

- **Summary:** `N documented robots, M implemented, K missing, S stale`.
- **Missing in code** (highest priority): bulleted `/x/y — <one-line docs description> — suggested folder <Category>`. Note these can be added with the `add-robot` skill.
- **In code, not in docs:** list with a short hypothesis (renamed? deprecated? typo in the `Robot` string?).
- **Parameter drift** (only if run): per robot, the missing/extra keys.
- If everything matches, say so plainly.

Keep it scannable. Do not modify any files.
