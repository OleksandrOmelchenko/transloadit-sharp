# Target `client`

<!-- Facts every role agent needs for this target. Grounded: every line names a path + symbol or a command that
     init ran. No counts, no file:line. Owned by the team; /stackfoundry:sync proposes changes, never overwrites. -->

The `Transloadit` NuGet library: public exposure (consumers feed it webhook bodies and API responses); stakes are
auth (signing, signature validation, credential secrets) and data integrity (two serializer engines, one wire format).

## Stack

| Layer | Pack | Rulebook |
|---|---|---|
| language | language-csharp | .stackfoundry/rules/language-csharp.md |
| app model | app-model-dotnet-library | .stackfoundry/rules/app-model-dotnet-library.md |
| capability | capability-system-text-json | .stackfoundry/rules/capability-system-text-json.md |
| capability | capability-newtonsoft-json | .stackfoundry/rules/capability-newtonsoft-json.md |
| tooling | tooling-xunit | .stackfoundry/rules/tooling-xunit.md |
| tooling | tooling-cscheck | .stackfoundry/rules/tooling-cscheck.md |
| tooling | tooling-coverlet | .stackfoundry/rules/tooling-coverlet.md |
| tooling | tooling-github-actions | .stackfoundry/rules/tooling-github-actions.md |

## Where things are

- Source: `src/Transloadit/**`. Entry point: `src/Transloadit/TransloaditClient.cs` `TransloaditClient`; every
  request goes through `SendRequest<T>` / `BuildRequest`. Services in `src/Transloadit/Services/`, models in
  `src/Transloadit/Models/` (robots under `Models/Robots/<category>/`, deriving from `RobotBase`).
- Serialization: System.Text.Json engine in `src/Transloadit/Serialization/SystemTextJsonSerializer.cs` and
  `StjConverters.cs` (default via `TransloaditSerializerFactory.CreateDefault`); Newtonsoft engine under
  `#if TRANSLOADIT_NEWTONSOFT` (net452/net461). Names come from `[TransloaditJsonName]`, no naming policy.
- Tests: `tests/Transloadit.Tests/**`, xUnit v2 with CsCheck property tests
  (`Tests/Unit/SignaturePropertyTests.cs`). Live-API tests derive from `Tests/TestBase.cs` `TestBase`, which reads
  `appsettings.Tests.json`; offline tests use fakes such as `FakeHttpMessageHandler`. Parallelization is off.
- Generated, never hand-edited: `tests/Transloadit.Tests/Snapshots/*.json` (regenerate with the `UPDATE_*`
  variables on `-f net8.0`, see `guards.json`), `.claude/skills/transloadit-docs-sync/baseline.json` (that skill's
  accept-baseline step).

## Gate

```sh
dotnet build Transloadit.slnx -c Release
dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -c Release -f net10.0 --no-build --filter "FullyQualifiedName!~.Api.&FullyQualifiedName!~Transloadit.Tests.Tests.AssemblyTrackerTests."
dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -c Release -f net48 --no-build --filter "FullyQualifiedName!~.Api.&FullyQualifiedName!~Transloadit.Tests.Tests.AssemblyTrackerTests."
dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -c Release -f net461 --no-build --filter "FullyQualifiedName!~.Api.&FullyQualifiedName!~Transloadit.Tests.Tests.AssemblyTrackerTests."
```

Status (proven by init): the build **fails**: NuGet audit reports NU1902 for `Microsoft.Build.Tasks.Git` 8.0.0
(transitive from `Microsoft.SourceLink.GitHub` 8.0.0) and `TreatWarningsAsErrors` makes it an error. With
`-p:NuGetAudit=false` the build is green and all three test legs pass. The fix is in the language-csharp rulebook
(global.json, `WarningsNotAsErrors` for NU1901–NU1904 plus an audit job) and the app-model rulebook (drop or bump
the Source Link pin).

Preconditions: .NET SDK 10.x; Windows with the .NET Framework 4.6.1+ runtime for net48/net461;
`tests/Transloadit.Tests/appsettings.Tests.json` present (a copy of `appsettings.json` with empty values is enough
offline). The three test legs cover modern System.Text.Json, .NET Framework System.Text.Json, and the Newtonsoft
engine (net461, which CI never runs).
Shuffled run (assurance gate): none yet (xUnit v2 has no built-in shuffle). Coverage: the `offline` suite's
`coverage` command in `targets.json`. Mutation lane: none yet: /stackfoundry:setup-mutation.

Local URL for live repros: not served locally.

## Oracle sources

In precedence order: the Transloadit API docs (via the repo's `fetch-transloadit-docs` skill); the rulebooks;
`tests/Transloadit.Tests/Snapshots/*.json` for wire format; `src/Transloadit/Constants/` for API enum values;
`docs/specifications/` and `docs/bug-reports/`.

## Emphasis

Public library handling secrets and signatures: constant-time and null-safe signature checks, secrets never logged
or leaked through shared `HttpClient` headers, invariant-culture formatting of everything signed or sent, parity
between the two serializer engines, binary compatibility of the public API across every target framework.

## Traps

- Offline vs live tests are told apart by name filter today; the xUnit rulebook's fix is a `Category=Live` trait.
- `UPDATE_*` regeneration writes under whichever TFM runs; always pass `-f net8.0` (tooling-xunit rulebook).
- CI runs only on manual dispatch and skips net461, net6.0 and net7.0; the local gate is the only Newtonsoft check.
- The rulebooks' "Known deviation" notes (timing-unsafe `ValidateSignature`, unconfirmed strong naming, tag-pinned
  actions, Debug-only coverage, and more) are open debt, not conventions.
