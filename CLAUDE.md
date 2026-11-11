# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

Transloadit Sharp is a .NET client library for the [Transloadit](https://transloadit.com) API, published to NuGet as `Transloadit`. It is a portable class library targeting a wide range of frameworks — from `net452` and `netstandard2.0` through `net10.0`. The only runtime dependency is `Newtonsoft.Json`.

## Build & Test

The solution uses the `.slnx` format (`Transloadit.slnx`). Use the .NET CLI:

```sh
dotnet build Transloadit.slnx                                  # build all target frameworks
dotnet build src/Transloadit/Transloadit.csproj -c Release     # build the library only
dotnet pack src/Transloadit -c Release                         # produce the NuGet package
```

Tests are xUnit and live in `tests/Transloadit.Tests`. Run a single target framework (the test project multi-targets, so always pass `-f`):

```sh
dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -f net8.0
dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -f net8.0 --filter "FullyQualifiedName~SignatureTests"
dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -f net8.0 --filter "DisplayName~CreateAsync"
```

### Test credentials (important)

Most `Tests/Api/*` tests are **integration tests that hit the live Transloadit API** and require credentials. They read `appsettings.Tests.json` from the test output directory at runtime. This file is gitignored and absent by default; create it by copying `tests/Transloadit.Tests/appsettings.json` and filling in `AuthKey`, `AuthSecret`, and `NotifyUrl`. Without it, `TestBase` throws at construction and API tests fail. Pure-unit tests (e.g. `SignatureTests`, `SerializationDefaultsTests`, `ProjectTests`, robot serialization in `NewRobotsTests`) do not need credentials. Test parallelization is disabled globally (see the assembly attribute in `Tests/TestBase.cs`) because integration tests share account-level rate limits.

## Build settings that affect all code

- `TreatWarningsAsErrors` is **true** — any warning fails the build. This includes missing XML doc comments, since `GenerateDocumentationFile` is on. Every public type and member needs a `///` doc comment.
- `Nullable` is **disabled** — do not add nullable reference annotations (`string?`); use `?` only for nullable value types.
- `LangVersion` is **12**, but the library targets frameworks as old as `net452`/`netstandard2.0`. Avoid APIs unavailable on old targets; framework gaps are bridged in `src/Transloadit/Polyfills/`. Framework-conditional package references live in `Directory.Build.props`.
- The assembly is strong-name signed (`SignAssembly`).

## Architecture

The public surface is `TransloaditClient` (`src/Transloadit/TransloaditClient.cs`), constructed with an auth key (and optionally a secret). Key-only clients can do unsigned operations (assembly create/status/cancel); key+secret is required for anything needing signature authentication.

**Services.** The client exposes API areas as lazily-instantiated service properties: `Assemblies`, `Templates`, `Credentials`, `Queues`, `Billing`, `AssemblyNotifications`, `Tokens`. Each service (`src/Transloadit/Services/`) holds a reference back to the client and turns typed request models into calls to the client's central `SendRequest<T>` method. To add an endpoint, add a method to the relevant service; to add an API area, add a service class and a lazy property on `TransloaditClient`.

**Request pipeline.** `TransloaditClient.SendRequest<T>` / `BuildRequest` is the single choke point for every request. It:
- serializes the `BaseParams`-derived parameter object to a JSON `params` field,
- injects `auth.key`, and (when signature auth is enabled and a secret is present) an `expires` timestamp plus a signature computed by `SignatureUtilities`,
- places `params`/`signature` in the query string for GET and in multipart form data for POST/PUT/DELETE,
- deserializes the response into a `ResponseBase`-derived type and attaches the raw `TransloaditResponse` (status code, headers, body).

Signature auth is on by default per request; endpoints that must not sign set `EnableSignatureAuth = false` on their `BaseParams` (see `AssembliesService.GetAsync`). OAuth token requests go through the separate `SendTokenRequest` path using HTTP Basic auth.

**Models** (`src/Transloadit/Models/`) are split into requests and responses:
- Request params derive from `BaseParams` / `PaginationParams` (`Models/BaseRequests.cs`).
- Responses derive from `ResponseBase` (`Models/BaseResponses.cs`), which implements `IResponseBase` explicitly to hide the raw `ok`/`error` fields behind a `Base` accessor and exposes `IsSuccessResponse()`. Check `IsSuccessResponse()` rather than inspecting status codes directly.

**Robots.** Assembly/template steps are modeled as strongly-typed classes under `Models/Robots/<category>/`, all deriving from `RobotBase` (with `ImportRobotBase`, `StoreRobotBase`, `PaginatedImportRobotBase` intermediates). Each concrete robot sets its `Robot` string (e.g. `/ftp/import`) in its constructor and links to the corresponding Transloadit docs page in its XML summary. Steps are supplied as `Dictionary<string, RobotBase>`. When adding a robot, mirror this pattern: pick the right base class, set `Robot` in the constructor, map every property with `[JsonProperty("snake_case_name")]`, and document each with `///`.

**Serialization.** `TransloaditSerializerSettings.CreateDefault()` (`src/Transloadit/Serialization/`) is the default Newtonsoft config: `NullValueHandling.Ignore`, `SnakeCaseNamingStrategy`, and the custom `AnyOfConverter`. Callers can customize by passing settings via `TransloaditClientOptions`. The `AnyOf<...>` union types (`Models/AnyOf.cs`) model API fields that accept multiple shapes (e.g. a string *or* a list); `AnyOfConverter` handles their JSON. Other custom converters: `BooleanToIntConverter`, and the `DateTimeConverters` used for `expires`/pagination dates.

**Constants** (`src/Transloadit/Constants/`) are static classes of string literals for API enum-like values (presets, stacks, formats, response codes). Prefer referencing these over raw strings.

## Conventions

- Comments start with a lowercase letter and need no trailing period.
- Reference types, methods, and properties in prose with backticks.
- Make minimal, well-scoped changes; avoid new dependencies.
- Async methods use `.ConfigureAwait(false)` throughout and are suffixed `Async`.
- When editing `readme.md`, keep examples runnable (include `using` directives, note async context) and use `csharp` fences; forward-slash paths like `images/snowflake.jpg` are fine in docs.

## Release

`Version` is set in `src/Transloadit/Transloadit.csproj`. The `NuGet Deploy` workflow (`.github/workflows/deploy.yml`, manual `workflow_dispatch`) runs the test matrix, packs, tags the commit `v<Version>` if that tag doesn't exist, and pushes to nuget.org. Bump `<Version>` before deploying a release.

<!-- stackfoundry:begin (managed by the stackfoundry init and upgrade skills; edit outside the markers) -->
## stackfoundry

This repo's specialists are generated by the stackfoundry plugin. The repo profile is
`.stackfoundry/profile.md`; targets and their gates are in `.stackfoundry/targets.json`; the settings, including
the assistants this repo uses, are in `.stackfoundry/config.json`.

Claude Code loads each rulebook's copy in `.claude/rules/` when it reads a matching file.

| Rulebook | Applies to | Covers |
|---|---|---|
| [language-csharp](.stackfoundry/rules/language-csharp.md) | C# sources, project files, `Directory.Build.props`, `.editorconfig` | old-TFM API gaps, LangVersion limits, constant-time comparison, analyzers, async, docs, culture |
| [app-model-dotnet-library](.stackfoundry/rules/app-model-dotnet-library.md) | the library source, `Directory.Build.props`, the deploy workflow | public API compatibility, multi-targeting, packaging, versioning, strong naming |
| [capability-system-text-json](.stackfoundry/rules/capability-system-text-json.md) | serialization, models, the client pipeline | System.Text.Json converters, polymorphism, parity with Newtonsoft |
| [capability-newtonsoft-json](.stackfoundry/rules/capability-newtonsoft-json.md) | serialization, models, the project files | the net452/net461 engine, host-settings isolation, parity |
| [tooling-xunit](.stackfoundry/rules/tooling-xunit.md) | tests, the test workflow, coverage settings | xUnit v2 practice, live vs offline tests, golden regeneration |
| [tooling-cscheck](.stackfoundry/rules/tooling-cscheck.md) | tests | CsCheck property tests across the 2.x/4.x split |
| [tooling-coverlet](.stackfoundry/rules/tooling-coverlet.md) | coverage settings, the coverage skill, the test project | collecting and reporting coverage |
| [tooling-github-actions](.stackfoundry/rules/tooling-github-actions.md) | workflows | pinning, secrets, Trusted Publishing, release safety |
| [testing](.stackfoundry/rules/testing.md) | tests, test designs | how tests are designed, written and judged here |
| [dependency-bumps](.stackfoundry/rules/dependency-bumps.md) | project files, `Directory.Build.props`, local tools | how versions are bumped and gated |
| [documentation](.stackfoundry/rules/documentation.md) | docs, `.claude/`, `CLAUDE.md`, READMEs | keeping living docs true |

Targets: client.

To change what a stackfoundry skill or agent does here, say "customize <skill>": the change lives in
`.stackfoundry/extensions/`, every run reads it, and plugin updates keep it.
<!-- stackfoundry:end -->
