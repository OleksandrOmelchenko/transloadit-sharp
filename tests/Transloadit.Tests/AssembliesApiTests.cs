using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Models.Robots.FileCompressing;
using Transloadit.Models.Robots.FileImporting;
using Transloadit.Models.Templates;
using Xunit;

namespace Transloadit.Tests
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
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = new HttpImportRobot
                        {
                            Url = "https://demos.transloadit.com/66/${fields.image_guid}/${fields.image}",
                        },
                    }
                }
            };
            var createTemplateResponse = await TransloaditClient.Templates.CreateAsync(templateRequest);
            Assert.Equal(ResponseCodes.TemplateCreated, createTemplateResponse.Base.Ok);

            var createAssembly = new AssemblyRequest
            {
                TemplateId = createTemplateResponse.Id,
                Quiet = true,
                Fields = new Dictionary<string, object> { ["image"] = "snowflake.jpg" }
            };
            createAssembly.DisableSignatureAuth();
            var formData = new MultipartFormDataContent
            {
                { new StringContent("01604e7d0248109df8c7cc0f8daef8"), "image_guid" }
            };

            var assemblyResponse = await TransloaditClient.Assemblies.CreateAsync(createAssembly, formData);
            Assert.Equal(ResponseCodes.AssemblyExecuting, assemblyResponse.Base.Ok);
            Assert.Null(assemblyResponse.TemplateId);

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
            Assert.Equal("transloadit-sharp/0.8.0", response.TransloaditClient);
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
        public async Task GetAssembliesList()
        {
            const int assemblyCount = 10;

            var listRequest = new AssemblyListRequest
            {
                PageSize = assemblyCount,
            };
            var assemblies = await TransloaditClient.Assemblies.GetListAsync(listRequest);

            Assert.Equal(assemblyCount, assemblies.Items.Count);
            Assert.True(assemblyCount < assemblies.Count);
        }
    }
}