using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Models.Templates;
using Xunit;

namespace Transloadit.Tests
{
    public class BaseParamsTests : TestBase
    {
        [Fact]
        public async Task SetInvalidAuthKey_Should_Fail()
        {
            var httpImportRobot = new TestHttpImportRobot
            {
                Url = "https://demos.transloadit.com/66/01604e7d0248109df8c7cc0f8daef8/snowflake.jpg"
            };

            var templateRequest = new TemplateRequest
            {
                Name = $"my-test-generic-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Template = new TemplateRequestContent
                {
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = httpImportRobot,
                    }
                }
            };
            templateRequest.SetAuth(new AuthParams
            {
                Key = "invalid key"
            });

            var createResponse = await TransloaditClient.Templates.CreateAsync(templateRequest);
            Assert.Equal(ResponseCodes.GetAccountUnknownAuthKey, createResponse.Base.Error);
            Assert.Equal(400, createResponse.Base.HttpCode);
        }

        [Fact]
        public async Task SetZeroMaxSize_Should_Fail()
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
            createAssembly.SetAuth(new AuthParams
            {
                MaxSize = 0
            });

            var file = new ByteArrayContent(File.ReadAllBytes(@"TestData/snowflake.jpg"));
            var formData = new MultipartFormDataContent
            {
                { file, "file-first", "snowflake.jpg" },
            };

            var response = await TransloaditClient.Assemblies.CreateAsync(createAssembly, formData);

            Assert.Equal(ResponseCodes.MaxSizeExceeded, response.Base.Error);
            Assert.Equal(400, response.Base.HttpCode);
        }

        [Fact]
        public async Task SetNonceAndExpires_Should_Succeed()
        {
            var listAssembliesRequest = new AssemblyListRequest();
            listAssembliesRequest.SetAuth(new AuthParams
            {
                Nonce = Guid.NewGuid().ToString(),
                Expires = DateTime.UtcNow.AddMinutes(5)
            });

            var response = await TransloaditClient.Assemblies.GetListAsync(listAssembliesRequest);

            Assert.Null(response.Base.Error);
        }
    }
}