using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transloadit.Models;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Models.Robots.FileExporting;
using Transloadit.Models.Robots.FileImporting;
using Transloadit.Models.Robots.ImageManipulation;
using Transloadit.Models.Templates;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Models;

// cross-provider golden test: serializing representative populated models through the active serializer
// (System.Text.Json on net6+, Newtonsoft on net461) must match a committed golden JSON *structurally*.
// JToken.DeepEquals is key-order-independent, so both engines are held to the same golden despite the
// two producing keys in different orders. Regenerate via UPDATE_GOLDEN=1 (writes only under net8.0/STJ).
//
// decimals are deliberately avoided in the cases here (2 vs 2.0 render differently per engine); the exact
// decimal wire format is asserted by SerializerWireFormatTests instead.
public class SerializationGoldenTests
{
    private static readonly IReadOnlyDictionary<string, object> Cases = BuildCases();

    public static IEnumerable<object[]> CaseNames()
    {
        foreach (var name in Cases.Keys)
        {
            yield return new object[] { name };
        }
    }

    [Theory]
    [MemberData(nameof(CaseNames))]
    public void Serializes_To_Golden(string caseName)
    {
        var actual = JToken.Parse(TestSerializer.Default.Serialize(Cases[caseName]));
        var path = GoldenPath();

        if (Environment.GetEnvironmentVariable("UPDATE_GOLDEN") == "1")
        {
            var store = File.Exists(path)
                ? JObject.Parse(File.ReadAllText(path))
                : new JObject();
            store[caseName] = actual;
            File.WriteAllText(path, store.ToString(Formatting.Indented).Replace("\r\n", "\n") + "\n");
            return;
        }

        Assert.True(File.Exists(path), $"golden file missing: {path} (regenerate with UPDATE_GOLDEN=1)");
        var golden = JObject.Parse(File.ReadAllText(path));
        Assert.True(golden.ContainsKey(caseName), $"golden has no case '{caseName}' (regenerate with UPDATE_GOLDEN=1)");
        Assert.True(
            JToken.DeepEquals(golden[caseName], actual),
            $"'{caseName}' diverged from golden.\nexpected: {golden[caseName]}\nactual:   {actual}");
    }

    private static string GoldenPath([CallerFilePath] string thisFile = null)
    {
        // <repo>/tests/Transloadit.Tests/Tests/Models/SerializationGoldenTests.cs -> .../Snapshots/models.golden.json
        var testsRoot = Directory.GetParent(thisFile).Parent.Parent.FullName;
        return Path.Combine(testsRoot, "Snapshots", "models.golden.json");
    }

    private static IReadOnlyDictionary<string, object> BuildCases()
    {
        var expires = new DateTime(2025, 2, 20, 1, 52, 4, DateTimeKind.Utc);

        return new Dictionary<string, object>
        {
            ["assembly_request_with_steps"] = new AssemblyRequest
            {
                TemplateId = "tpl-1",
                NotifyUrl = "https://example.test/notify",
                Fields = new Dictionary<string, object>
                {
                    ["userId"] = "42",
                    ["uploadPath"] = "/main/images",
                },
                Steps = new Dictionary<string, RobotBase>
                {
                    ["import"] = new HttpImportRobot
                    {
                        Url = "https://example.test/in.jpg",
                    },
                    ["resize"] = new ImageResizeRobot
                    {
                        Use = "import",
                        Width = 100,
                        Height = 200,
                        ImageMagickStack = "v3.0.1",
                        Interpolate = true,
                    },
                    ["store"] = new S3StoreRobot
                    {
                        Use = "resize",
                        Credentials = "s3-creds",
                        Path = "/out/${file.url_name}",
                    },
                },
            },

            ["pagination_params"] = new PaginationParams
            {
                Page = 2,
                PageSize = 25,
                FromDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ToDate = new DateTime(2025, 1, 31, 23, 59, 59, DateTimeKind.Utc),
                Keywords = new List<string> { "video", "image" },
            },

            ["auth_params"] = new AuthParams
            {
                Key = "my-auth-key",
                Expires = expires,
                Nonce = "n-123",
                MaxSize = 10485760,
            },

            ["template_request"] = new TemplateRequest
            {
                Name = "my-template",
                RequireSignatureAuth = true,
                Template = new TemplateRequestContent
                {
                    AllowStepsOverride = true,
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["resize"] = new ImageResizeRobot
                        {
                            Width = 50,
                            Height = 50,
                            OutputMeta = new OutputMeta { DominantColors = true },
                        },
                    },
                },
            },
        };
    }
}
