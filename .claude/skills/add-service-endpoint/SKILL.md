---
name: add-service-endpoint
description: Add a new API endpoint method to an existing Transloadit Sharp service, or add a whole new service area. Use when the user wants to call a Transloadit API endpoint the library doesn't cover yet. Handles the SendRequest delegation, request/response models, signature-auth toggling, and the lazy service property on TransloaditClient.
---

# Add a service endpoint (or a new service)

Services live in `src/Transloadit/Services/` and are the typed wrappers over the single request choke point `TransloaditClient.SendRequest<T>` (`src/Transloadit/TransloaditClient.cs`). Each is registered as a lazy property on the client.

## Fetch the spec

Use `fetch-transloadit-docs` against the `/docs/api/` endpoint to get the path, HTTP method, request params, and response shape. Cross-check against an existing service (e.g. `CredentialsService.cs`, `TemplatesService.cs`) and its models.

## Mode A — new endpoint on an existing service

1. Add request/response models as needed:
   - request: `public class <X>Request : BaseParams` (or `PaginationParams` for lists), snake_case `[JsonProperty]` fields.
   - response: `public class <X>Response : ResponseBase`.
2. Add the method to the service:
   ```csharp
   /// <summary>...</summary>
   public async Task<<X>Response> <X>Async(<args>)
   {
       return await _client.SendRequest<<X>Response>(HttpMethod.<Verb>, $"/path/{id}", requestModel)
           .ConfigureAwait(false);
   }
   ```
   - `HttpMethod` maps to REST semantics (`Get`/`Post`/`Put`/`Delete`).
   - for **unsigned** endpoints, disable signing on the params: `parameters.EnableSignatureAuth = false;` or `parameters.DisableSignatureAuth();` (pattern in `AssembliesService.GetAsync`).

## Mode B — new service area

1. Create `src/Transloadit/Services/<Area>Service.cs`:
   ```csharp
   public class <Area>Service
   {
       private readonly TransloaditClient _client;

       /// <summary>...</summary>
       public <Area>Service(TransloaditClient client) => _client = client;

       // endpoint methods (Mode A)
   }
   ```
2. Register a lazy property on `src/Transloadit/TransloaditClient.cs`, next to the existing ones:
   ```csharp
   private <Area>Service _<area>Service;
   /// <summary><Area> service.</summary>
   public <Area>Service <Area> => _<area>Service ??= new <Area>Service(this);
   ```

## Conventions & verify

- `Async` suffix; `.ConfigureAwait(false)` on every await; full XML docs (build fails otherwise); nullable value types only (no `string?`); comments lowercase, no trailing period.
- `dotnet build src/Transloadit/Transloadit.csproj -c Release`.
- Add a `tests/Transloadit.Tests/Tests/Api/<Area>ApiTests.cs` integration test (derives from `TestBase`, needs live credentials) and/or a credential-free serialization unit test.
