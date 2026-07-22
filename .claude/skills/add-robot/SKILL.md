---
name: add-robot
description: Add a new Transloadit Robot model class to the Transloadit Sharp library. Use when the user wants to implement/add a robot, gives a robot path like /image/resize or /ai/chat, or points at a robot docs URL. Handles picking the base class, the constructor Robot string, snake_case JsonProperty mapping, mandatory XML docs, and the NewRobotsTests assertion.
---

# Add a Transloadit Robot

Robots are strongly-typed step models under `src/Transloadit/Models/Robots/<Category>/`. There is **no central registry** — a robot is consumed polymorphically via `Dictionary<string, RobotBase>` on `AssemblyRequest.Steps` and `TemplateRequestContent.Steps`, so adding one means adding a single class file plus a test assertion. Nothing else references it.

## Steps

1. **Resolve slug + category.** From the robot path `/x/y`, derive the docs slug (`/image/resize` → `image-resize`) and map the Transloadit doc category to an existing folder:
   `AI`, `AudioEncoding`, `Code`, `Documents`, `FileCompressing`, `FileExporting`, `FileFiltering`, `FileImporting`, `ImageManipulation`, `MediaCataloging`, `SmartCdn`, `VideoEncoding`.

2. **Fetch the parameter spec** using the `fetch-transloadit-docs` skill. That skill also covers the mandatory **existence/status check**: the `llms.txt`/`llms-full.txt` index can be stale (it lists robots that 404 or are removed), so before writing any code confirm the robot has a **published docs page** — check the `sitemap.xml` and the `curl` HTTP status + server-rendered `<title>` of `https://transloadit.com/docs/robots/<slug>/` (do **not** use `WebFetch` — it fabricates content for 404 pages). If the page is 404 / not in the sitemap / marked removed, **do not implement it** — report that to the user instead.

3. **Open a sibling** in the same category folder and mirror it — it is the source of truth for idioms. Pick the base class from `src/Transloadit/Models/Robots/RobotBase.cs`:
   - `RobotBase` — default.
   - `ImportRobotBase` / `PaginatedImportRobotBase` — import robots (add `ignore_errors`, `credentials`, `path`, and pagination).
   - `StoreRobotBase` — store/export robots (add `use`, `credentials`, `path`).
   - If a base's fields don't quite fit, derive `RobotBase` directly and declare the fields yourself (some existing import robots do this).

4. **Create the file** `src/Transloadit/Models/Robots/<Category>/<Name>Robot.cs`:
   - namespace `Transloadit.Models.Robots.<Category>`
   - `public class <Name>Robot : <Base>`
   - parameterless constructor sets the path: `Robot = "/x/y";`

5. **Map each parameter** to a `public` property:
   - `[JsonProperty("snake_case_key")]` on every property.
   - nullable value types use `?` (`int?`, `bool?`, `double?`); reference types plain — do **not** write `string?` (`Nullable` is disabled).
   - multi-shape fields → `AnyOf<...>` (`src/Transloadit/Models/AnyOf.cs`).
   - enum-like string values → reuse or add a `src/Transloadit/Constants/` static class and reference it in the doc with `<see cref="Constants.X"/>`.

6. **Write XML docs on everything** — the build has `TreatWarningsAsErrors` + `GenerateDocumentationFile`, so a missing `///` fails compilation:
   - class `<summary>`: `Represents <a href="https://transloadit.com/docs/robots/<slug>/">/x/y</a> Robot.`
   - constructor `<summary>`: `Initializes <a href="https://transloadit.com/docs/robots/<slug>/">/x/y</a> Robot.`
   - every property: describe it; use `<para>Default: <c>...</c></para>`, `<c>` for values, `<list>`/`<item>` for enumerations, matching the siblings.
   - comments in prose start lowercase, no trailing period.

7. **Nested models** (robot-specific sub-objects) go in the same file, `public`, fully doc-commented.

8. **Add the test assertion** to `tests/Transloadit.Tests/Tests/NewRobotsTests.cs` — this is the canonical place robots are enumerated:
   ```csharp
   Assert.Equal("/x/y", new <Name>Robot().Robot);
   ```
   Add assertions for any new `Constants` values too.

9. **Verify:**
   ```sh
   dotnet build src/Transloadit/Transloadit.csproj -c Release
   dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -f net8.0 --filter "FullyQualifiedName~NewRobotsTests"
   ```
   Optionally hand the diff to the `csharp-build-reviewer` agent.

10. **Re-confirm existence (post-check).** As a final step, re-check each robot you added against the `sitemap.xml` and the `curl` HTTP status/`<title>` of its docs page — the LLM index that seeded the work may have been out of date. Drop any robot whose page 404s, is absent from the sitemap, or is marked removed.
