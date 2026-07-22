---
name: fetch-transloadit-docs
description: Fetch the authoritative parameter spec for a Transloadit Robot or API endpoint from the official docs. Use when implementing or updating a robot/credentials/endpoint model and you need the exact parameters (names, types, defaults, allowed values), or whenever the user asks to "look up the params/docs for /x/y". Called by the add-robot, add-credentials, and add-service-endpoint skills.
---

# Fetch Transloadit docs

Pull the authoritative parameter list for a Robot or API endpoint so a C# model maps exactly. The reliable source **for parameters** is Transloadit's machine-readable **`llms-full.txt`**, which contains a **Zod schema** for every robot — exact keys, types, defaults, and descriptions. The rendered HTML pages and per-robot `.md` pages are JS stubs that omit parameters, so do **not** rely on `WebFetch` against them for the parameter list.

## ⚠️ The LLM index can be stale — verify against the live docs page

`llms-full.txt` / `llms.txt` are **not authoritative for whether a robot exists or is current**. They lag behind the live docs and have listed robots (with full schemas) that either 404 (no published docs page — e.g. `/document/extract`, `/mega/import`, `/image/enhance`) or are marked removed (e.g. `/edgly/deliver`). So **before implementing** a robot and **after** (as a final check), verify it exists as a published docs page.

**Use reliable, server-side signals — NOT `WebFetch`.** `WebFetch` renders/summarizes these JS SPA pages with a small model and has been observed to **fabricate plausible content (fake headings, fake "beta/ga" stages) for pages that actually 404** — do not trust it for existence/status. Instead:

1. **Sitemap** (authoritative list of published pages):
   ```sh
   curl -sSL https://transloadit.com/sitemap.xml | grep -oE 'docs/robots/[a-z-]+' | sort -u
   ```
   If the robot's slug is **not** in the sitemap, its docs page is not published — treat it as not available.
2. **HTTP status + server-rendered `<title>`** (the title is rendered server-side even on the SPA):
   ```sh
   curl -sS -o /dev/null -w '%{http_code}\n' -L "https://transloadit.com/docs/robots/<slug>/"
   curl -sSL "https://transloadit.com/docs/robots/<slug>/" | grep -oiE '<title>[^<]*</title>'
   ```
   A real page returns `200` with `<title>/x/y | Transloadit</title>`; a missing one returns `404` with `<title>404 - Not Found | Transloadit</title>`.

If the robot is **404 / not in the sitemap / removed → do not implement it** (and if it already exists in the repo, flag it for removal). Trust the sitemap + HTTP/title over the LLM index whenever they disagree.

## Slug mapping

A robot's Assembly path maps to a docs slug by dropping the leading slash and replacing slashes with hyphens: `/image/resize` → `image-resize`, `/ftp/import` → `ftp-import`.

## Robots — primary method (curl + grep the Zod schema)

1. Download the full dump once per session to your scratch dir (it is ~650 KB / ~13k lines; `WebFetch` truncates it, so use `curl`):
   ```sh
   curl -sSL https://transloadit.com/llms-full.txt -o "$SCRATCH/llms-full.txt"
   ```
2. Find the robot's section anchor (each of the ~95 robots has one `[/x/y docs](...)` line):
   ```sh
   grep -n "\[/image/resize docs\]" "$SCRATCH/llms-full.txt"
   ```
3. Read from that line to the **next** `[/… docs](https://transloadit.com/docs/robots/` anchor — that span is the robot's `const xxxSchema = z.object({ … })` block. Read it with the Read tool (offset/limit) rather than dumping the whole file.
4. The robot index (slug + one-line description for every robot) is `https://transloadit.com/llms.txt` (~230 lines) — handy for confirming the exact path/slug.

## Zod → C# mapping (how to read the schema)

| Zod in `llms-full.txt` | C# in this repo |
|---|---|
| `z.string()` | `string` |
| `z.number().int().gte(1).lte(25000)` | `int?` |
| `z.number()` (non-int) | `double?` |
| `z.boolean()` / `z.union([z.boolean(), z.enum(['true','false'])])` | `bool?` |
| `z.enum(['a','b'])` / `.literal('x')` | `string` + add/reuse a `Constants/` class, `<see cref>` it |
| `z.union([z.string(), z.array(z.string())])` | `AnyOf<string, List<string>>` |
| `z.union([z.boolean(), z.object(...)])` | `AnyOf<bool, SomeModel>` |
| `.describe('...')` | the property's `///` `<summary>` text |
| `.default(x)` | note `<para>Default: <c>x</c></para>` |
| `.optional()` / `.default(...)` | nullable value type (`?`); reference types stay plain (no `string?`) |

Shared sub-schemas (`IgnoreErrorsSchema`, `UseSchema`, `OutputMetaSchema`, `ResultSchema`, `ForceAcceptSchema`) are already modeled on the base classes in `src/Transloadit/Models/Robots/RobotBase.cs` — don't re-declare them; pick the base class that provides them.

## API endpoints

For service endpoints, use the API markdown pages via `curl` (some are non-empty, some 404 depending on slug):
```sh
curl -sSL https://transloadit.com/docs/api/authentication.md
```
Discover the correct slug from the index at `https://transloadit.com/docs/api/`. The intro sections of `llms-full.txt` / `llms.txt` also describe Assembly Instructions and auth.

## Cross-check (required)

Reconcile the fetched spec against a **sibling class in the same folder** — it is the source of truth for this repo's idioms (`AnyOf<>`, `Constants/`, nullable value types, doc style). If docs and siblings disagree on a shape, follow the sibling and note the discrepancy to the user. Downloaded files are cached in scratch for the session; re-`curl` only if you suspect staleness.
