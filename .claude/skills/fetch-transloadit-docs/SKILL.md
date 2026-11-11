---
name: fetch-transloadit-docs
description: Fetch the authoritative parameter spec for a Transloadit Robot or API endpoint from the official docs. Use when implementing or updating a robot/credentials/endpoint model and you need the exact parameters (names, types, defaults, allowed values), or whenever the user asks to "look up the params/docs for /x/y". Called by the add-robot, add-credentials, and add-service-endpoint skills.
---

# Fetch Transloadit docs

Pull the authoritative parameter list for a Robot or API endpoint so a C# model maps exactly. For a whole-library drift report (everything that's new or changed), use the **transloadit-docs-sync** skill instead. Its `snapshot_docs.py` extracts the same sources for every robot and endpoint at once.

## Sources (strongest first)

1. **The robot's Markdown page:** `https://transloadit.com/docs/robots/<slug>.md`. It lists every parameter as `### \`name\`` under `## Parameters`, followed by its description and a `Type:` line, and has a `Stage:` line (`alpha`/`beta`/`ga`/`removed`). This is the live site's content.
2. **`https://transloadit.com/openapi.json`** (OpenAPI 3.1, ~1.2 MB). It has:
   - every REST operation with its request and response schemas
   - the credential `type` enum
   - a step-schema variant per robot (`properties.robot.const == "/x/y"`), with the same params as the `.md` page
3. **`llms-full.txt`** (~1.6 MB). Robot params appear as `##### \`param\`` headings under `#### \`/x/y\`` in its `### Robot parameters` section. It **no longer contains Zod schemas**. It lags the site, so use it only as a fallback.

## ⚠️ Verify the robot is published before implementing it

The `llms*` indexes and `openapi.json` are **not authoritative for whether a robot is current**. They have listed robots whose docs page 404s (e.g. `/image/copyrightdetect`) or is marked `removed` (e.g. `/edgly/deliver`). Use reliable server-side signals, **not `WebFetch`**. `WebFetch` summarizes these SPA pages with a small model and has fabricated plausible content for pages that 404.

1. **Sitemap**, the authoritative list of published pages:
   ```sh
   curl -sSL https://transloadit.com/sitemap.xml | grep -oE 'docs/robots/[a-z0-9-]+/' | sort -u
   ```
2. **HTTP status, `Stage:` and `<title>`:**
   ```sh
   curl -sS -o /dev/null -w '%{http_code}\n' -L "https://transloadit.com/docs/robots/<slug>.md"
   curl -sSL "https://transloadit.com/docs/robots/<slug>.md" | grep -m1 '^Stage:'
   ```
   A real page returns `200` with a `Stage:` line. A missing one returns `404`.

If the robot is 404, absent from the sitemap, or `Stage: removed`, **do not implement it**. If the repo already has it, flag it for removal.

## Slug mapping

A robot's Assembly path maps to a docs slug by dropping the leading slash and replacing the remaining slash with a hyphen: `/image/resize` → `image-resize`, `/ftp/import` → `ftp-import`.

## Robots: fetch the parameter list

```sh
curl -sSL https://transloadit.com/docs/robots/<slug>.md -o "$SCRATCH/<slug>.md"
grep -nE '^### `' "$SCRATCH/<slug>.md"             # one line per parameter
```

Read the file with the Read tool to get each parameter's description, `Type:` and default. Parameters that every robot lists, or every robot of one kind (`use`, `result`, `queue`, `force_accept`, `ignore_errors`, `output_meta`, `interpolate`, `credentials`, `path`, …), live on the base classes in `src/Transloadit/Models/Robots/RobotBase.cs`. Pick the base class that provides them; don't re-declare them.

## `Type:` → C# mapping

| `Type:` on the page | C# in this repo |
|---|---|
| `string` | `string` |
| `number` (integral by its description/default) | `int?` |
| `number` (fractional) | `double?` |
| `string \| number` | `AnyOf<string, int>` (or `AnyOf<string, double>`), following a sibling with the same shape |
| `boolean` | `bool?` |
| `a \| b \| c` (literal choices) | `string` + add/reuse a `Constants/` class, `<see cref>` it |
| `Array<string>` | `List<string>` |
| `string \| Array<string>` | `AnyOf<string, List<string>>` |
| `boolean \| Array<…>` | `AnyOf<bool, List<string>>` |
| `object` / `Record<string, …>` | a model class, or `Dictionary<string, object>` when the shape is open |
| `… \| null` | nullable value type (`?`); reference types stay plain (no `string?`) |

The description text becomes the property's `///` `<summary>`. A documented default goes in `<para>Default: <c>x</c></para>`.

## API endpoints

`openapi.json` is the most precise source. For example, to list operations and read one operation's response fields:

```sh
curl -sSL https://transloadit.com/openapi.json -o "$SCRATCH/openapi.json"
python -I -c "import json,sys; o=json.load(open(sys.argv[1],encoding='utf-8')); [print(m.upper(),p) for p,v in o['paths'].items() for m in v]" "$SCRATCH/openapi.json"
```

Schemas are `$ref`s into `components.schemas`, which have hash-like names: resolve them, then flatten `allOf`/`anyOf`/`oneOf`, skipping error variants (`required: ["error"]`). The prose page `https://transloadit.com/docs/api/<slug>.md` adds explanations. Discover slugs from the `docs/api/` entries in `sitemap.xml`.

## Cross-check (required)

Reconcile the fetched spec against a **sibling class in the same folder**. It's the source of truth for this repo's idioms (`AnyOf<>`, `Constants/`, nullable value types, doc style). If the docs and the siblings disagree on a shape, follow the sibling and note the discrepancy to the user. Downloaded files are cached in scratch for the session; re-`curl` only if you suspect staleness.
