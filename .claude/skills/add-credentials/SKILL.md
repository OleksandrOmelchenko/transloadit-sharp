---
name: add-credentials
description: Add a new template-credentials type to the Transloadit Sharp library (e.g. S3, Azure, FTP, Supabase). Use when the user wants to support storing credentials for a new service. Handles the Request + Content class pair, the Type string, and why no service change is needed.
---

# Add a template-credentials type

Credentials request models live in `src/Transloadit/Models/Credentials/`. `CredentialsService.CreateAsync` / `UpdateAsync` accept the abstract base `CredentialsRequestBase`, so a new type is fully polymorphic — **no service or client change is required**.

## Steps

1. **Fetch the content fields** for the service using the `fetch-transloadit-docs` skill (API credentials docs). Cross-check against an existing sibling such as `S3CredentialsRequest.cs` or `AzureCredentialsRequest.cs`.

2. **Create** `src/Transloadit/Models/Credentials/<Svc>CredentialsRequest.cs` with two `public` classes in one file:
   - `public class <Svc>CredentialsRequest : CredentialsRequestBase` (base in `CredentialsRequest.cs`; it provides `[TransloaditJsonName("name")] Name`). The parameterless constructor sets the discriminator:
     ```csharp
     public <Svc>CredentialsRequest()
     {
         Type = "<svc>";
     }
     ```
     and exposes `[TransloaditJsonName("content")] public <Svc>CredentialsContent Content { get; set; }`.
   - `public class <Svc>CredentialsContent` holding the service fields, each with `[TransloaditJsonName("snake_case_key")]` (omit the attribute when the key is exactly `snake_case(PropertyName)`).

   Use the library's provider-neutral `Transloadit*` attributes (in `Transloadit.Serialization.Attributes`), **not** native `[JsonProperty]`/`[JsonPropertyName]`: the client serializes with System.Text.Json on `net462`+ and Newtonsoft on `net452`/`net461`, and a native attribute is honored on only one engine — so the JSON key would differ by target framework.

3. **Conventions:** nullable value types use `?`; no `string?` (`Nullable` is disabled); full XML docs on every public type and member (build fails otherwise); comments lowercase, no trailing period.

4. **Verify:** `dotnet build src/Transloadit/Transloadit.csproj -c Release`.

5. **Tests (optional).** `tests/Transloadit.Tests/Tests/Api/CredentialsApiTests.cs` runs a live create→get→update→list→delete lifecycle and needs real credentials in `appsettings.Tests.json`; extend it only if you have credentials to run against. A serialization unit test (asserting `Type`/JSON keys) needs no credentials and is a good lightweight alternative.
