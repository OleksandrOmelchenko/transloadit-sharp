---
name: bump-version
description: Bump the NuGet package version of the Transloadit Sharp library. Use when the user wants to increment/raise/set the version, bump patch/minor/major, or prepare for a release (version change only — not the full pack/deploy, which is the release-pack skill).
---

# Bump version

The package version is the single `<Version>` element in `src/Transloadit/Transloadit.csproj` (SemVer `MAJOR.MINOR.PATCH`). The deploy workflow tags the commit `v<Version>`.

## Steps

1. **Read the current version:**
   ```sh
   grep -oE '<Version>[^<]+</Version>' src/Transloadit/Transloadit.csproj
   ```

2. **Decide the new version** from the user's request:
   - `patch` (default for a bugfix): `0.9.4` → `0.9.5`
   - `minor` (new backwards-compatible feature): `0.9.4` → `0.10.0`
   - `major` (breaking change): `0.9.4` → `1.0.0`
   - or an explicit version the user gives (e.g. "bump to 1.2.0").
   If the user didn't say which part, ask, or infer from the change (new robots/params → minor; fixes → patch; breaking API → major).

3. **Edit** the `<Version>` value in `src/Transloadit/Transloadit.csproj` (Edit tool — change only that element).

4. **Verify** it still builds and the version reads back:
   ```sh
   dotnet msbuild src/Transloadit/Transloadit.csproj -getProperty:Version
   ```

## Notes

- **Don't reuse an existing tag.** The deploy workflow only tags `v<Version>` if that tag doesn't already exist, so a stale/duplicate version would silently skip tagging. Check `git tag -l "v<new>"` if unsure.
- Bump the version **before** cutting a release — the actual pack/publish is the **release-pack** skill.
- Do **not** commit or push the bump unless the user asks; changing a released version is outward-facing.
