---
name: coverage
description: Run the Transloadit Sharp test suite with code coverage and produce an AI-readable report. Use when the user wants a coverage report, asks "what's covered / what's untested", wants to raise coverage, or after adding tests to see the delta. Runs offline unit tests on net8.0, emits a Markdown/text summary you read to find the lowest-covered files, then act.
---

# Code coverage

Produces a cobertura report from the test suite and a Markdown/text summary you can read to decide what to test next. Coverage runs on a **single modern TFM (net8.0)** — the project multi-targets, and running all TFMs would produce a report per framework.

Use a scratch directory for output so nothing lands in the repo. In examples below `$OUT` is `<scratch>/coverage` (your session scratchpad).

## Steps

1. **Restore the report tool** (pinned in `.config/dotnet-tools.json`):
   ```sh
   dotnet tool restore
   ```

2. **Run tests with coverage.** To measure everything, run the whole suite — but the live `Tests/Api/*` and `AssemblyTrackerTests` need real credentials in `tests/Transloadit.Tests/appsettings.Tests.json`. If you don't have credentials, filter to the offline tests so the run is green:
   ```sh
   dotnet test tests/Transloadit.Tests/Transloadit.Tests.csproj -f net8.0 \
     --collect:"XPlat Code Coverage" --settings coverlet.runsettings \
     --results-directory "$OUT" \
     --filter "FullyQualifiedName~Tests.Unit|FullyQualifiedName~Tests.Models|FullyQualifiedName~Tests.Constants|FullyQualifiedName~SignatureTests|FullyQualifiedName~SerializationDefaultsTests|FullyQualifiedName~NewRobotsTests"
   ```
   Drop the `--filter` to include the live integration tests when credentials are present (higher coverage of the service methods).

3. **Generate the report.** The collector writes `coverage.cobertura.xml` under a per-run GUID folder:
   ```sh
   dotnet tool run reportgenerator \
     -reports:"$OUT/**/coverage.cobertura.xml" \
     -targetdir:"$OUT/report" \
     -reporttypes:"MarkdownSummaryGithub;TextSummary;Html"
   ```

4. **Read the summary and act.** Read `$OUT/report/Summary.txt` (or `SummaryGithub.md`) — it lists line/branch coverage per class. Identify the lowest-covered types in `src/Transloadit`, open them, and add targeted tests (prefer the offline patterns in `tests/Transloadit.Tests/Tests/Unit/` and the reflection smoke tests in `Tests/Models/`). The HTML report (`$OUT/report/index.html`) is for humans.

## Notes

- The `.gitignore` already ignores `coverage*.xml`; keep coverage output in scratch so nothing is committed.
- The runsettings (`coverlet.runsettings`) excludes the test assembly and generated code, so figures reflect `src/Transloadit` only.
- Pure logic (signatures, converters, `AnyOf`, base params/responses, the client pipeline via the fake handler) and all robot/credential model serialization are covered offline; the numbers for service methods that only do a `SendRequest` round-trip rise further when the credentialed integration tests are included.
