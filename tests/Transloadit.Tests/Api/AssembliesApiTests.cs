using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Models.Robots.FileCompressing;
using Transloadit.Models.Robots.FileImporting;
using Transloadit.Models.Templates;
using Transloadit.Tests.Fixtures;
using Transloadit.Tests.Robots;
using Xunit;

namespace Transloadit.Tests.Api
{
    public class AssembliesApiTests : TestBase
    {
        [Fact]
        public async Task CreateAssemblyFromTemplateWithFields_ShouldSucceed()
        {
            var templateRequest = new TemplateRequest
            {
                Name = $"my-test-generic-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Template = new TemplateRequestContent
                {
                    Fields = new Dictionary<string, object> { ["number"] = 66 },
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = new HttpImportRobot
                        {
                            Url = "https://demos.transloadit.com/${fields.number}/${fields.image_guid}/${fields.image}",
                        },
                    }
                }
            };
            var createTemplateResponse = await TransloaditClient.Templates.CreateAsync(templateRequest);
            Assert.Equal(ResponseCodes.TemplateCreated, createTemplateResponse.Base.Ok);

            var createAssembly = new AssemblyRequest
            {
                TemplateId = createTemplateResponse.Id,
                Fields = new Dictionary<string, object> { ["image"] = "snowflake.jpg" },
                Steps = new Dictionary<string, RobotBase>
                {
                    ["import"] = new HttpImportRobot
                    {
                        FailFast = true,
                    }
                }
            };
            createAssembly.DisableSignatureAuth();
            var formData = new MultipartFormDataContent
            {
                { new StringContent("01604e7d0248109df8c7cc0f8daef8"), "image_guid" }
            };

            var assemblyResponse = await TransloaditClient.Assemblies.CreateAsync(createAssembly, formData);
            Assert.Equal(ResponseCodes.AssemblyExecuting, assemblyResponse.Base.Ok);
            Assert.Equal(66L, assemblyResponse.Fields["number"]);
            Assert.Equal("snowflake.jpg", assemblyResponse.Fields["image"]);
            Assert.Equal("01604e7d0248109df8c7cc0f8daef8", assemblyResponse.Fields["image_guid"]);

            var deleteTemplateResponse = await TransloaditClient.Templates.DeleteAsync(createTemplateResponse.Id);
            Assert.Equal(ResponseCodes.TemplateDeleted, deleteTemplateResponse.Base.Ok);
        }

        [Fact]
        public async Task CreateAssemblyWithAdvancedUse_Should_Succeed()
        {
            var createAssembly = new AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase>
                {
                    ["compress"] = new FileCompressRobot
                    {
                        Use = new AdvancedUse
                        {
                            Steps = new List<AdvancedStep> { new AdvancedStep { Name = ":original", As = "new" } }
                        },
                        Format = "zip"
                    }
                }
            };

            var file = new ByteArrayContent(File.ReadAllBytes(@"TestData/lorem.txt"));
            var formData = new MultipartFormDataContent
            {
                { file, "file-first", "lorem.txt" },
            };

            var response = await TransloaditClient.Assemblies.CreateAsync(createAssembly, formData);
            Assert.Equal(ResponseCodes.AssemblyExecuting, response.Base.Ok);
        }

        [Fact]
        public async Task CreateQuietAssembly_Should_BeEmpty()
        {
            var createAssembly = new AssemblyRequest
            {
                Quiet = true,
                Steps = new Dictionary<string, RobotBase>
                {
                    ["import"] = TestDataFactory.GetDemoHttpImportRobot()
                }
            };
            var response = await TransloaditClient.Assemblies.CreateAsync(createAssembly);

            Assert.Equal(ResponseCodes.AssemblyExecuting, response.Base.Ok);
            Assert.Null(response.TemplateId);
        }

        [Fact]
        public async Task CreateAssembly_Should_HaveTransloaditClient()
        {
            var createAssembly = new AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase>
                {
                    ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                }
            };
            var response = await TransloaditClient.Assemblies.CreateAsync(createAssembly);

            Assert.Equal(ResponseCodes.AssemblyExecuting, response.Base.Ok);
            Assert.Equal($"transloadit-sharp/{ClientVersion.Current}", response.TransloaditClient);
        }

        [Fact]
        public async Task CreateAssemblyWithSteps_Should_Succeed()
        {
            var imageResizeRobot = new TestImageResizeRobot
            {
                Use = ":original",
                Result = true,
                Width = 130,
                Height = 130
            };

            var createAssembly = new AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase>
                {
                    ["resize"] = imageResizeRobot
                }
            };

            var file = new ByteArrayContent(File.ReadAllBytes(@"TestData/snowflake.jpg"));
            var file1 = new ByteArrayContent(File.ReadAllBytes(@"TestData/flower-field.jpg"));
            var file2 = new ByteArrayContent(File.ReadAllBytes(@"TestData/flowers.jpg"));
            var formData = new MultipartFormDataContent
            {
                { file, "file-first", "snowflake.jpg" },
                { file1, "file-second", "flower-field.jpg" },
                { file2, "file-third", "flowers.jpg" },
            };

            var response = await TransloaditClient.Assemblies.CreateAsync(createAssembly, formData);

            Assert.Equal(ResponseCodes.AssemblyExecuting, response.Base.Ok);
            Assert.Equal(3, response.NumInputFiles);
            Assert.Equal(3, response.Uploads.Count);
        }

        [Fact]
        public async Task CreateAssemblyFromTemplateWithRequiredSignatureAuth_ShouldFail()
        {
            var templateRequest = new TemplateRequest
            {
                Name = $"my-test-generic-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                RequireSignatureAuth = true,
                Template = new TemplateRequestContent
                {
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                    }
                }
            };
            var createTemplateResponse = await TransloaditClient.Templates.CreateAsync(templateRequest);
            Assert.Equal(ResponseCodes.TemplateCreated, createTemplateResponse.Base.Ok);

            var createAssembly = new AssemblyRequest
            {
                TemplateId = createTemplateResponse.Id,
                Quiet = true,
            };
            createAssembly.DisableSignatureAuth();

            var assemblyResponse = await TransloaditClient.Assemblies.CreateAsync(createAssembly);
            Assert.Equal(ResponseCodes.NoAuthExpiresParameter, assemblyResponse.Base.Error);
            Assert.Equal(400, assemblyResponse.Base.HttpCode);

            var deleteTemplateResponse = await TransloaditClient.Templates.DeleteAsync(createTemplateResponse.Id);
            Assert.Equal(ResponseCodes.TemplateDeleted, deleteTemplateResponse.Base.Ok);
        }

        [Fact]
        public async Task CreateAssemblyWithStepsAndTemplateDisallowingStepsOverride_ShoulFail()
        {
            var imageResizeRobot = new TestImageResizeRobot
            {
                Use = "import",
                Result = true,
                Width = 130,
                Height = 130
            };

            var templateRequest = new TemplateRequest
            {
                Name = $"my-test-generic-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Template = new TemplateRequestContent
                {
                    AllowStepsOverride = false,
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                        ["resize"] = imageResizeRobot
                    }
                }
            };

            var templateResponse = await TransloaditClient.Templates.CreateAsync(templateRequest);
            var assemblyRequest = new AssemblyRequest
            {
                TemplateId = templateResponse.Id,
                Steps = new Dictionary<string, RobotBase>
                {
                    ["resize"] = new TestImageResizeRobot
                    {
                        Width = 200,
                        Height = 200,
                    }
                }
            };

            var assemblyResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
            Assert.Equal(ResponseCodes.TemplateDeniesStepsOverride, assemblyResponse.Base.Error);
            Assert.Equal(400, assemblyResponse.Base.HttpCode);

            var deleteTemplateResponse = await TransloaditClient.Templates.DeleteAsync(templateResponse.Id);
            Assert.Equal(ResponseCodes.TemplateDeleted, deleteTemplateResponse.Base.Ok);
        }

        [Fact]
        public async Task CreateAssemblyWithTemplateQuiet_ShouldSucceed()
        {
            var templateRequest = new TemplateRequest
            {
                Name = $"my-test-generic-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Template = new TemplateRequestContent
                {
                    Quiet = true,
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                    }
                }
            };

            var templateResponse = await TransloaditClient.Templates.CreateAsync(templateRequest);
            var assemblyRequest = new AssemblyRequest
            {
                TemplateId = templateResponse.Id,
            };
            assemblyRequest.DisableSignatureAuth();

            var assemblyResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
            Assert.Equal(ResponseCodes.AssemblyExecuting, assemblyResponse.Base.Ok);
            Assert.Null(assemblyResponse.TemplateId);

            var deleteTemplateResponse = await TransloaditClient.Templates.DeleteAsync(templateResponse.Id);
            Assert.Equal(ResponseCodes.TemplateDeleted, deleteTemplateResponse.Base.Ok);
        }

        [Fact(Skip = "Replaying assembly works weird. Not sure what to test here. NotifyUrl is not applied on replay," +
            "template is reparsed by default which doesn't correspond to docs and reparsing is not consistent between runs with different steps.")]
        public async Task ReplayAssembly_ShouldSucceed()
        {
            var templateRequest = new TemplateRequest
            {
                Name = $"test-replay-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Template = new TemplateRequestContent
                {
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                    }
                }
            };

            var templateResponse = await TransloaditClient.Templates.CreateAsync(templateRequest);
            var assemblyRequest = new AssemblyRequest
            {
                TemplateId = templateResponse.Id,
            };
            assemblyRequest.DisableSignatureAuth();

            var createAssemblyResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
            Assert.True(createAssemblyResponse.IsSuccessResponse());

            _ = await AssemblyTracker.WaitCompletionAsync(createAssemblyResponse);

            var updateTemplateRequest = new TemplateRequest
            {
                Template = new TemplateRequestContent
                {
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["download"] = new HttpImportRobot
                        {
                            Url = TestConstants.DemoImageUrl,
                            Headers = ["X-Test: Demo Image"],
                        }
                    }
                }
            };

            var updateTemplateReponse = await TransloaditClient.Templates.UpdateAsync(templateResponse.Id, updateTemplateRequest);

            var firstReplayResponse = await TransloaditClient.Assemblies.ReplayAsync(
                createAssemblyResponse.AssemblyId,
                new ReplayAssemblyRequest { ReparseTemplate = false });
            Assert.Equal(ResponseCodes.AssemblyReplaying, firstReplayResponse.Base.Ok);
            var firstAssembly = await AssemblyTracker.WaitCompletionAsync(firstReplayResponse.AssemblyId);
            var firstAssemblySteps = JsonConvert.DeserializeObject<TemplateContent>(firstAssembly.MergedParams);
            Assert.True(firstAssembly.IsSuccessResponse());
            //bug: first replay expicitly say to not reparse a template, but as the result first replay contains
            //new and old templates versions merged
            Assert.Equal(templateResponse.Content.Steps.Count, firstAssemblySteps.Steps.Count);
            Assert.Equal(templateResponse.Content.Steps["import"]["url"], firstAssemblySteps.Steps["import"]["url"]);

            var secondReplayResponse = await TransloaditClient.Assemblies.ReplayAsync(
                createAssemblyResponse.AssemblyId,
                new ReplayAssemblyRequest { ReparseTemplate = true, NotifyUrl = Configuration.NotifyUrl });
            Assert.Equal(ResponseCodes.AssemblyReplaying, secondReplayResponse.Base.Ok);
            Assert.Equal(Configuration.NotifyUrl, secondReplayResponse.NotifyUrl);
            var secondAssembly = await AssemblyTracker.WaitCompletionAsync(secondReplayResponse.AssemblyId);
            var secondAssemblySteps = JsonConvert.DeserializeObject<TemplateContent>(secondAssembly.MergedParams);
            Assert.True(secondAssembly.IsSuccessResponse());
            //bug: assembly url is empty while even the replay response contains the passed url
            Assert.Equal(Configuration.NotifyUrl, secondAssembly.NotifyUrl);
            Assert.Equal(updateTemplateReponse.Content.Steps.Count, secondAssemblySteps.Steps.Count);
            Assert.Equal(updateTemplateReponse.Content.Steps["download"]["url"], secondAssemblySteps.Steps["download"]["url"]);
            Assert.Equal(updateTemplateReponse.Content.Steps["download"]["headers"], secondAssemblySteps.Steps["download"]["headers"]);

            var thirdReplayResponse = await TransloaditClient.Assemblies.ReplayAsync(createAssemblyResponse.AssemblyId);
            Assert.Equal(ResponseCodes.AssemblyReplaying, firstReplayResponse.Base.Ok);
            var thirdAssembly = await AssemblyTracker.WaitCompletionAsync(thirdReplayResponse.AssemblyId);
            var thirdAssemblySteps = JsonConvert.DeserializeObject<TemplateContent>(thirdAssembly.MergedParams);
            Assert.True(thirdAssembly.IsSuccessResponse());
            Assert.Equal(templateResponse.Content.Steps.Count, thirdAssemblySteps.Steps.Count);
            //bug: according to the docs the template is not reparsed on a replay by default
            Assert.Equal(templateResponse.Content.Steps["import"]["url"], thirdAssemblySteps.Steps["import"]["url"]);

            var deleteTemplateResponse = await TransloaditClient.Templates.DeleteAsync(templateResponse.Id);
            Assert.Equal(ResponseCodes.TemplateDeleted, deleteTemplateResponse.Base.Ok);
        }
    }
}