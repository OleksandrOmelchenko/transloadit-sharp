using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transloadit.Models;
using Transloadit.Models.Robots;
using Transloadit.Models.Templates;
using Xunit;

namespace Transloadit.Tests
{
    public class TemplatesApiTests : TestBase
    {
        [Fact]
        public async Task CreateGetUpdateListDeleteTemplate()
        {
            var httpImportRobot = new TestHttpImportRobot
            {
                Url = "https://demos.transloadit.com/66/01604e7d0248109df8c7cc0f8daef8/snowflake.jpg"
            };
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
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = httpImportRobot,
                        ["resize"] = imageResizeRobot
                    }
                }
            };

            var createResponse = await TransloaditClient.Templates.CreateAsync(templateRequest);
            Assert.Equal("TEMPLATE_CREATED", createResponse.Base.Ok);
            Assert.Equal(templateRequest.Name, createResponse.Name);
            Assert.Equal(templateRequest.RequireSignatureAuth, createResponse.RequireSignatureAuth);
            Assert.Equal(2, createResponse.Content.Steps.Count);
            Assert.Equal(httpImportRobot.Robot, createResponse.Content.Steps["import"]["robot"]);
            Assert.Equal(httpImportRobot.Url, createResponse.Content.Steps["import"]["url"]);
            Assert.Equal(imageResizeRobot.Robot, createResponse.Content.Steps["resize"]["robot"]);
            Assert.Equal(imageResizeRobot.Use.Value, createResponse.Content.Steps["resize"]["use"]);
            Assert.Equal(imageResizeRobot.Result, createResponse.Content.Steps["resize"]["result"]);
            Assert.Equal(imageResizeRobot.Width, Convert.ToInt32(createResponse.Content.Steps["resize"]["width"]));
            Assert.Equal(imageResizeRobot.Height, Convert.ToInt32(createResponse.Content.Steps["resize"]["height"]));

            var templateResponse = await TransloaditClient.Templates.GetAsync(createResponse.Id);
            Assert.Equal("TEMPLATE_FOUND", templateResponse.Base.Ok);
            Assert.Equal(templateRequest.Name, templateResponse.Name);
            Assert.Equal(templateRequest.RequireSignatureAuth, templateResponse.RequireSignatureAuth);
            Assert.Equal(2, templateResponse.Content.Steps.Count);
            Assert.Equal(httpImportRobot.Robot, templateResponse.Content.Steps["import"]["robot"]);
            Assert.Equal(httpImportRobot.Url, templateResponse.Content.Steps["import"]["url"]);
            Assert.Equal(imageResizeRobot.Robot, templateResponse.Content.Steps["resize"]["robot"]);
            Assert.Equal(imageResizeRobot.Use.Value, templateResponse.Content.Steps["resize"]["use"]);
            Assert.Equal(imageResizeRobot.Result, templateResponse.Content.Steps["resize"]["result"]);
            Assert.Equal(imageResizeRobot.Width, Convert.ToInt32(templateResponse.Content.Steps["resize"]["width"]));
            Assert.Equal(imageResizeRobot.Height, Convert.ToInt32(templateResponse.Content.Steps["resize"]["height"]));

            //always empty, why?
            var list = await TransloaditClient.Templates.GetListAsync();
            Assert.Equal(0, list.Count);

            var imageOptimizeRobot = new TestImageOptimizeRobot
            {
                Use = "load",
                PreserveMetaData = true,
                Priority = "conversion-speed"
            };
            var updateTemplateRequest = new TemplateRequest
            {
                Name = $"my-updated-generic-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                RequireSignatureAuth = 1,
                Template = new TemplateRequestContent
                {
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["load"] = httpImportRobot,
                        ["optimize"] = imageOptimizeRobot
                    }
                }
            };

            //sending update request 2 times because the first one fails for some reason on api side
            _ = await TransloaditClient.Templates.UpdateAsync(createResponse.Id, updateTemplateRequest);
            var updateResponse = await TransloaditClient.Templates.UpdateAsync(createResponse.Id, updateTemplateRequest);
            Assert.Equal("TEMPLATE_UPDATED", updateResponse.Base.Ok);
            Assert.Equal(updateTemplateRequest.Name, updateResponse.Name);
            Assert.Equal(updateTemplateRequest.RequireSignatureAuth, updateResponse.RequireSignatureAuth);
            Assert.Equal(2, updateResponse.Content.Steps.Count);
            Assert.Equal(httpImportRobot.Robot, updateResponse.Content.Steps["load"]["robot"]);
            Assert.Equal(httpImportRobot.Url, updateResponse.Content.Steps["load"]["url"]);
            Assert.Equal(imageOptimizeRobot.Robot, updateResponse.Content.Steps["optimize"]["robot"]);
            Assert.Equal(imageOptimizeRobot.Use, updateResponse.Content.Steps["optimize"]["use"]);
            Assert.Equal(imageOptimizeRobot.PreserveMetaData, updateResponse.Content.Steps["optimize"]["preserve_meta_data"]);
            Assert.Equal(imageOptimizeRobot.Priority, updateResponse.Content.Steps["optimize"]["priority"]);

            var deleteResponse = await TransloaditClient.Templates.DeleteAsync(createResponse.Id);
            Assert.Equal("TEMPLATE_DELETED", deleteResponse.Base.Ok);
            Assert.NotNull(deleteResponse.Base.Message);

            var getDeletedResponse = await TransloaditClient.Templates.GetAsync(createResponse.Id);
            Assert.Equal("TEMPLATE_NOT_FOUND", getDeletedResponse.Base.Error);
            Assert.NotNull(getDeletedResponse.Base.Message);
        }
    }

    public class TestImageResizeRobot : RobotBase
    {
        public AnyOf<string, List<string>> Use { get; set; }
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

    public class TestImageOptimizeRobot : RobotBase
    {
        public string Use { get; set; }
        public string Priority { get; set; }
        public bool PreserveMetaData { get; set; }

        public TestImageOptimizeRobot()
        {
            Robot = "/image/optimize";
        }
    }
}