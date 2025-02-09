using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transloadit.Models;
using Transloadit.Models.Templates;
using Xunit;

namespace Transloadit.Tests
{
    public class TemplatesApiTests : TestBase
    {
        [Fact]
        public async Task GetTemplatesList()
        {
            var par = new TemplateListRequest
            {
                PageSize = 10,
                Page = 1,
                Order = "asc",
                Sort = "created"
            };
            var templates = await TransloaditClient.Templates.GetListAsync(par);

            // Assert.Equal("BILL_FOUND", billing.Ok);
        }

        [Theory]
        [InlineData("047e1008c1ec4ea3a719d57f3648eff8")]
        public async Task GetTemplate(string templateId)
        {
            var template = await TransloaditClient.Templates.GetAsync(templateId);
            Assert.Equal("TEMPLATE_FOUND", template.Base.Ok);
        }

        [Fact]
        public async Task CreateTemplate()
        {
            var templateRequest = new TemplateRequest
            {
                Name = $"my-test-generic-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Template = new TemplateRequestContent
                {
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = new TestHttpImportRobot
                        {
                            Url = "https://demos.transloadit.com/66/01604e7d0248109df8c7cc0f8daef8/snowflake.jpg"
                        },
                        ["resize"] = new TestImageResizeRobot
                        {
                            Use = "import",
                            Result = true,
                            Width = 130,
                            Height = 130
                        }
                    }
                }
            };

            var template = await TransloaditClient.Templates.CreateAsync(templateRequest);

            Assert.Equal("TEMPLATE_CREATED", template.Base.Ok);

            var templateGet = await TransloaditClient.Templates.GetAsync(template.Id);

            Assert.Equal("TEMPLATE_FOUND", templateGet.Base.Ok);

            var list = await TransloaditClient.Templates.GetListAsync();



        }

    }

    public class TestImageResizeRobot : RobotBase
    {
        public string Use { get; set; }
        public bool Result { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public TestImageResizeRobot()
        {
            Robot = "/image/resize";
        }
    }

    public class TestHttpImportRobot : RobotBase
    {
        public string Url { get; set; }

        public TestHttpImportRobot()
        {
            Robot = "/http/import";
        }
    }
}