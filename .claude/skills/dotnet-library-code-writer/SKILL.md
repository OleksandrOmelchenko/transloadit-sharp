---
name: dotnet-library-code-writer
description: Write or change .NET library code the repo's way, in the client target — old-TFM API gaps, constant-time signature checks, binary-compatible public API, serializer parity. Use when editing src/Transloadit/**.
---

# .NET library code writer

Write code that looks like the code already here. The rules live in the rulebooks below, which are authoritative;
this skill is the decision procedure. Read them before editing. Where a rulebook marks a "Known deviation", the
repo's current way is debt to fix, never a pattern to copy.

| Read first | Before touching |
|---|---|
| [language-csharp](../../../.stackfoundry/rules/language-csharp.md) | any `.cs`, `.csproj`, `Directory.Build.props`, `.editorconfig` |
| [app-model-dotnet-library](../../../.stackfoundry/rules/app-model-dotnet-library.md) | public API, packaging, versioning, `src/Transloadit/**` |
| [capability-system-text-json](../../../.stackfoundry/rules/capability-system-text-json.md) | `src/Transloadit/Serialization/**`, `src/Transloadit/Models/**` |
| [capability-newtonsoft-json](../../../.stackfoundry/rules/capability-newtonsoft-json.md) | code under `#if TRANSLOADIT_NEWTONSOFT` (net452/net461) |
| [tooling-xunit](../../../.stackfoundry/rules/tooling-xunit.md), [tooling-cscheck](../../../.stackfoundry/rules/tooling-cscheck.md), [testing](../../../.stackfoundry/rules/testing.md) | `tests/Transloadit.Tests/**` |
| [tooling-coverlet](../../../.stackfoundry/rules/tooling-coverlet.md) | coverage settings and the `coverage` skill |
| [tooling-github-actions](../../../.stackfoundry/rules/tooling-github-actions.md) | `.github/workflows/**` |
| [dependency-bumps](../../../.stackfoundry/rules/dependency-bumps.md) | package and SDK versions |

## The decisions that go wrong most often

1. **Does this API exist on net452 and netstandard2.0?** Check its "Applies to" list. If not, bridge it with an
   internal helper in `src/Transloadit/Polyfills/` behind the exact TFM symbol, like
   `src/Transloadit/Polyfills/DateTimeOffsetExtensions.cs` `ToUnixTimeMilliseconds`. Wrong answer: the net452 or
   netstandard2.0 inner build fails and blocks pack and deploy.
2. **Is a secret, token or signature compared?** Decode to bytes and compare in constant time
   (`CryptographicOperations.FixedTimeEquals` on `NETCOREAPP2_1_OR_GREATER`, an internal XOR-accumulate polyfill
   elsewhere); never `==`. Wrong answer: a timing side channel on consumers' webhook endpoints.
   `src/Transloadit/Utilities/SignatureUtilities.cs` `ValidateSignature` is the known deviation to fix.
3. **Does the change alter a public signature?** Add an overload (e.g. one taking `CancellationToken`) and keep the
   old one delegating; never add an optional parameter, rename a parameter or remove a member without an
   `[Obsolete]` release first. Wrong answer: `MissingMethodException` in compiled consumers.
4. **Does the value go on the wire or into a signed string?** Format with `CultureInfo.InvariantCulture`, sort keys
   with `StringComparer.Ordinal`, name JSON members with `[TransloaditJsonName]`, and keep both serializer engines
   emitting the same JSON (`src/Transloadit/Serialization/StjConverters.cs`). Wrong answer: rejected requests,
   failed signature checks, or a parity break that only net461 shows.
5. **Is there an `await` in `src/`?** Append `.ConfigureAwait(false)` and never block on a task; in test methods,
   never use `ConfigureAwait`. Wrong answer: deadlocks in consumers with a synchronization context.
6. **Is it a new public member?** Give it a `///` comment (no `?` on reference types: Nullable is off) and validate
   reference arguments with `?? throw new ArgumentNullException(nameof(x))`, as the `TransloaditClient`
   constructors do. Wrong answer: CS1591 or CS8632 fails the warnings-as-errors build.

## Non-negotiables

- Generated files are never hand-edited: `tests/Transloadit.Tests/Snapshots/*.json` regenerate only with the
  `UPDATE_*` variables on `-f net8.0` after the owner accepts the wire change;
  `.claude/skills/transloadit-docs-sync/baseline.json` only through that skill.
- Live-API tests (`tests/Transloadit.Tests/Tests/Api/**`, `AssemblyTrackerTests`) run only when the owner asks.
- Never `dotnet nuget push`; releases go through `.github/workflows/deploy.yml`.
- New robots, credentials and endpoints go through the repo's `add-robot`, `add-credentials` and
  `add-service-endpoint` skills, which this skill complements.

## Working procedure

1. Read the rulebooks for the files you are about to touch.
2. **Read a neighbour first**: the closest existing service, model or robot class and match its shape, naming and
   comment density.
3. Make the change. A wire-format change needs the golden/snapshot tests reviewed (and regenerated only with the
   owner's yes); a version change goes through the `bump-version` skill.
4. Verify with the `client` gate:
   ```sh
   dotnet build Transloadit.slnx -c Release
   dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -c Release -f net10.0 --no-build --filter "FullyQualifiedName!~.Api.&FullyQualifiedName!~Transloadit.Tests.Tests.AssemblyTrackerTests."
   dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -c Release -f net48 --no-build --filter "FullyQualifiedName!~.Api.&FullyQualifiedName!~Transloadit.Tests.Tests.AssemblyTrackerTests."
   dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -c Release -f net461 --no-build --filter "FullyQualifiedName!~.Api.&FullyQualifiedName!~Transloadit.Tests.Tests.AssemblyTrackerTests."
   ```
5. Then `/stackfoundry:review-changes` for an independent review.

## Tooling
- `Read` the rulebooks and a neighbour, `Edit`/`Write` the change, `Bash` for the gate.
- The net461 and net48 legs need Windows with the .NET Framework runtime; the build needs `appsettings.Tests.json`
  present in `tests/Transloadit.Tests/` (a copy of `appsettings.json` is enough offline).
