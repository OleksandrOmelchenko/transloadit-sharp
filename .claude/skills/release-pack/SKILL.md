---
name: release-pack
description: Cut a NuGet release of the Transloadit Sharp library — bump the version, build and pack, and (only if asked) trigger the deploy workflow. Use when the user wants to release, publish to NuGet, pack the package, or bump the version.
---

# Release / pack

The package version lives in `<Version>` in `src/Transloadit/Transloadit.csproj`. Publishing is done by the manual **NuGet Deploy** GitHub workflow (`.github/workflows/deploy.yml`), not from a dev machine.

## Steps

1. **Bump the version** — edit `<Version>` in `src/Transloadit/Transloadit.csproj` (e.g. `0.9.4` → `0.9.5`). Always bump *before* deploying; the workflow tags the commit `v<Version>` and only creates the tag if it doesn't already exist.

2. **Build and pack locally to validate:**
   ```sh
   dotnet build src/Transloadit/Transloadit.csproj -c Release
   dotnet pack src/Transloadit -c Release --output nuget
   ```
   This produces `nuget/Transloadit.<Version>.nupkg`.

3. **Deploy (only when the user explicitly asks).** The workflow is `workflow_dispatch` and requires a `notifyUrl` input plus repo secrets (`AUTH_KEY`, `AUTH_SECRET`, `NUGET_KEY`); it runs the full test matrix, packs, tags `v<Version>`, and pushes to nuget.org. Do **not** commit, push, or trigger it on your own. When asked, trigger with:
   ```sh
   gh workflow run "NuGet Deploy" -f notifyUrl=<https url>
   ```

## Notes

- Committing the version bump and triggering the deploy are outward-facing actions — confirm with the user first.
- The deploy tests hit the live Transloadit API and are gated on the `Release` environment secrets; a local pack does not run them.
