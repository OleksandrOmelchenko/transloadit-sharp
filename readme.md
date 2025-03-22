## Quick Start

### Installation

Nuget package [Transloadit](https://www.nuget.org/packages/Transloadit/).

### Create Transloadit client

```C#
using Transloadit;

var client = new TransloaditClient("<auth key>", "<auth secret>");
```

### Create an Assembly

Using a Template

```C#
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
    //assembly was created and started successfully
}
else
{
    //there was an error during assembly creation
}
```

Specifying Steps

```C#
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

```C#
var assembly = new AssemblyRequest
{
    TemplateId = "47c5b0b70ac64deaa821eae6424bbb4f"
};
var file = new ByteArrayContent(File.ReadAllBytes(@"/images/snowflake.jpg"));
var file1 = new ByteArrayContent(File.ReadAllBytes(@"/images/flower-field.jpg"));
var formData = new MultipartFormDataContent
{
    { file, "file-first", "snowflake.jpg" },
    { file1, "file-second", "flower-field.jpg" },
};

var assemblyResponse = await client.Assemblies.CreateAsync(assembly, formData);
```

### Create a Template and Credentials

```C#
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
                //other properties...
            },
            ["store"] = new S3StoreRobot
            {
                Use = "import",
                Credentials = s3Credentials.Name,
                //other properties...
            }
        }
    }
};

var templateResponse = await client.Templates.CreateAsync(templateRequest);
```