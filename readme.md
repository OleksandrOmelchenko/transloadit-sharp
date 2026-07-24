## Quick Start

### Installation

NuGet package: [Transloadit](https://www.nuget.org/packages/Transloadit/).

### Create Transloadit client

```csharp
using Transloadit;

// suitable for operations not requiring signature authentication, like assembly creation
// or retrieving assembly status
var clientNoAuth = new TransloaditClient("<auth key>");

// for all APIs (including those that require signature authentication)
var client = new TransloaditClient("<auth key>", "<auth secret>");
```

### Choosing / customizing the JSON serializer

Serialization is abstracted behind the `ITransloaditSerializer` interface:

```csharp
public interface ITransloaditSerializer
{
    string Serialize(object value);
    T Deserialize<T>(string json);
}
```

#### Default serializer

You don't need to configure anything. By default the client uses **System.Text.Json**, falling back to
**Newtonsoft.Json** on `net452`/`net461` (where System.Text.Json is unavailable). The active default for the
current framework is available from `TransloaditSerializerFactory.CreateDefault()`, and any serializer can be
set explicitly via `TransloaditClientOptions.Serializer`:

```csharp
using Transloadit;
using Transloadit.Serialization;

var options = new TransloaditClientOptions
{
    Serializer = TransloaditSerializerFactory.CreateDefault(),
};

var client = new TransloaditClient("<auth key>", "<auth secret>", options);
```

#### Customize the built-in engine

To tweak options or register extra converters without writing a new serializer, pass a configuration callback
to the built-in adapter. Use `SystemTextJsonSerializer` (net462+) or `NewtonsoftJsonSerializer` (net452/net461):

```csharp
using System.Text.Json.Serialization;
using Transloadit;
using Transloadit.Serialization;

// System.Text.Json: add a converter, keep everything else at the Transloadit defaults
var serializer = new SystemTextJsonSerializer(options => options.Converters.Add(new MyConverter()));

// Newtonsoft.Json (net452 / net461):
// var serializer = new NewtonsoftJsonSerializer(settings => settings.Converters.Add(new MyConverter()));

var client = new TransloaditClient("<auth key>", "<auth secret>", new TransloaditClientOptions
{
    Serializer = serializer,
});
```

#### Implement a custom `ITransloaditSerializer`

Implement the interface to add cross-cutting behavior or plug in a different engine. The recommended approach
is to **wrap the default serializer** (via `TransloaditSerializerFactory.CreateDefault()`) so the correct
Transloadit wire format is preserved — for example, a decorator that logs every request/response:

```csharp
using System;
using Transloadit;
using Transloadit.Serialization;

public sealed class LoggingSerializer : ITransloaditSerializer
{
    private readonly ITransloaditSerializer _inner;

    public LoggingSerializer(ITransloaditSerializer inner) => _inner = inner;

    public string Serialize(object value)
    {
        var json = _inner.Serialize(value);
        Console.WriteLine($"--> {json}");
        return json;
    }

    public T Deserialize<T>(string json)
    {
        Console.WriteLine($"<-- {json}");
        return _inner.Deserialize<T>(json);
    }
}

// usage
var client = new TransloaditClient("<auth key>", "<auth secret>", new TransloaditClientOptions
{
    Serializer = new LoggingSerializer(TransloaditSerializerFactory.CreateDefault()),
});
```

> A serializer written fully from scratch (not delegating to a built-in one) is responsible for producing the
> Transloadit wire format itself: snake_case property names with a few explicit overrides (e.g. `rawGb`,
> `imagemagick_stack`, `pagesize`), the integer boolean fields, and the `expires`/pagination date formats. The
> built-in serializers derive all of this from the models' provider-neutral attributes, so wrapping the default
> is the recommended path.

### Create an Assembly

Using a template

```csharp
using System.Collections.Generic;
using Transloadit;
using Transloadit.Models.Assemblies;

var assembly = new AssemblyRequest
{
    TemplateId = "c9e195983aa7459bad20a04973ca1ac1",
    Fields = new Dictionary<string, object>
    {
        ["uploadPath"] = "/main/images",
        ["imageId"] = "58129",
        ["userId"] = "73852",
    },
    NotifyUrl = "https://my.webhook/notify"
};
var assemblyResponse = await client.Assemblies.CreateAsync(assembly);
if (assemblyResponse.IsSuccessResponse())
{
    // assembly was created and started successfully
}
else
{
    // there was an error during assembly creation
}
```

Specifying steps

```csharp
using System.Collections.Generic;
using Transloadit;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Models.Robots.FileExporting;
using Transloadit.Models.Robots.FileImporting;

var assembly = new AssemblyRequest
{
    Steps = new Dictionary<string, RobotBase>
    {
        ["ftp-import"] = new FtpImportRobot
        {
            Credentials = "main-ftp-creds",
            PassiveMode = true,
            Path = "/${fields.uploadPath}/processing/${fields.imageId}.jpg"
        },
        ["aws-store"] = new S3StoreRobot
        {
            Use = "ftp-import",
            Credentials = "primary-s3-bucket",
            Path = "/upload/${fields.userId}/${file.url_name}",
            Acl = "bucket-default",
            CheckIntegrity = true,
        }
    },
    Fields = new Dictionary<string, object>
    {
        ["uploadPath"] = "/main/images",
        ["imageId"] = "58129",
        ["userId"] = "73852",
    }
};
var assemblyResponse = await client.Assemblies.CreateAsync(assembly);
```

With file uploads

```csharp
using System.IO;
using System.Net.Http;

var assembly = new AssemblyRequest
{
    TemplateId = "47c5b0b70ac64deaa821eae6424bbb4f"
};
var file = new ByteArrayContent(File.ReadAllBytes("images/snowflake.jpg"));
var file1 = new ByteArrayContent(File.ReadAllBytes("images/flower-field.jpg"));
var formData = new MultipartFormDataContent
{
    { file, "file-first", "snowflake.jpg" },
    { file1, "file-second", "flower-field.jpg" },
};

var assemblyResponse = await client.Assemblies.CreateAsync(assembly, formData);
```

### Awaiting assembly completion

```csharp
var assemblyTracker = new AssemblyTracker(client);

// by id (first gets the assembly by id and then polls the status)
var completedAssembly = await assemblyTracker.WaitCompletionAsync(assemblyResponse.AssemblyId);

// by assembly (checks the passed assembly and then polls the status)
var completedAssembly2 = await assemblyTracker.WaitCompletionAsync(assemblyResponse);
```

### Create a template and credentials

```csharp
using System.Collections.Generic;

var azureCredentials = new AzureCredentialsRequest
{
    Name = "azure-storage",
    Content = new AzureCredentialsContent
    {
        Account = "main-account",
        Container = "docs-container",
        Key = "secret key"
    }
};
var s3Credentials = new S3CredentialsRequest
{
    Name = "s3-documents",
    Content = new S3CredentialsContent
    {
        BucketRegion = "us-east-1",
        Bucket = "docs-bucket",
        Secret = "secret",
        Key = "key"
    }
};
var azureResponse = await client.Credentials.CreateAsync(azureCredentials);
var s3Response = await client.Credentials.CreateAsync(s3Credentials);

var templateRequest = new TemplateRequest
{
    Name = "sync-cloud-documents",
    RequireSignatureAuth = true,
    Template = new TemplateRequestContent
    {
        AllowStepsOverride = true,
        Steps = new Dictionary<string, RobotBase>
        {
            ["import"] = new AzureImportRobot
            {
                Credentials = azureCredentials.Name,
                // other properties...
            },
            ["store"] = new S3StoreRobot
            {
                Use = "import",
                Credentials = s3Credentials.Name,
                // other properties...
            }
        }
    }
};

var templateResponse = await client.Templates.CreateAsync(templateRequest);
```
