# Transloadit Sharp: repo profile

<!-- Written by /stackfoundry:init from the interview and the survey. Owned by the team: edit freely.
     Every role agent reads it first, so keep it short and true. -->

## The product

A .NET client library for the Transloadit file-processing API, published to nuget.org as `Transloadit`. It builds and
signs API requests, models Assemblies, Templates, Credentials and Robots as typed classes, and validates the
signatures of inbound Assembly notifications. One library multi-targets everything from `net452` to `net10.0`.

## Users and channels

Third-party .NET developers call it from their own applications. It has no network listener of its own. Untrusted
input reaches it through Transloadit API responses and through webhook bodies that consumers pass to
`client.Signature.ValidateSignature` (readme "Receiving Assembly notifications").

## What is at stake

- **Auth**: HMAC request signing with the account secret (`SignatureUtilities.CalculateSignature`), inbound
  signature validation (`SignatureUtilities.ValidateSignature`), Smart CDN signed URLs
  (`SmartCdnService.GetSignedSmartCdnUrl`), Basic-auth token requests, and credential models carrying
  third-party secrets (`src/Transloadit/Models/Credentials/`).
- **Data integrity**: two serializer engines must emit the same wire format. System.Text.Json is used everywhere
  except `net452`/`net461`, which compile `#if TRANSLOADIT_NEWTONSOFT` and use Newtonsoft.Json. Golden and snapshot
  tests in `tests/Transloadit.Tests/Snapshots/` guard parity.

## Constraints that shape the code

- `TreatWarningsAsErrors` and `GenerateDocumentationFile`: every public member needs a `///` comment.
- Nullable reference types are off: `?` only on value types.
- The oldest targets (`net452`, `netstandard2.0`) limit which BCL APIs exist; gaps are bridged in
  `src/Transloadit/Polyfills/`.
- `.ConfigureAwait(false)` on every await in `src/` (CA2007 is an error there).
- Best practice wins over repo habit: where the rulebooks mark a "Known deviation", the repo's current way is debt
  to fix, never a pattern to copy.

## Who decides

The maintainer (repo owner) approves releases (manual `deploy.yml` dispatch), version bumps, breaking API changes,
dropped target frameworks, and golden-file regeneration.

## Working agreements

- Git: the owner decides every commit, push, tag and PR (enforced as `guards.json` `git.writes: ask`).
- Generated files: `tests/Transloadit.Tests/Snapshots/*.json` regenerate only through the `UPDATE_*` variables on
  net8.0; `.claude/skills/transloadit-docs-sync/baseline.json` only through that skill's accept-baseline step
  (enforced by the guard hook).
- Live-API tests (`Tests/Api/*`, `AssemblyTrackerTests`) need credentials and spend account usage: they run only
  when the owner asks, never in a gate.
- Releases go out only through `.github/workflows/deploy.yml` (NuGet Trusted Publishing); never `dotnet nuget push`.
- Docs root: `docs`. Report dates use the machine's time zone.
- Plan and spec categories: `api`, `robots`, `client`, `platform` (see `docs/plans/README.md`).
- The repo's own skills and agents (`.claude/skills/`, `.claude/agents/`) stay side by side with stackfoundry's;
  `csharp-build-reviewer` is registered as a specialist.

## Targets

`.stackfoundry/targets.json` is the list; each target's facts are in `.stackfoundry/targets/`.
