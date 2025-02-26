using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Models.Templates;
using Xunit;

namespace Transloadit.Tests
{
    public class AssemblyNotificationsApiTests : TestBase
    {
        [Fact]
        public async Task ReplayNonExistentAssemblyNotification_Should_Fail()
        {
            var response = await TransloaditClient.AssemblyNotifications.ReplayAsync("non-existent");

            Assert.Equal(ResponseCodes.Server404, response.Base.Error);
            Assert.Equal(404, response.Base.HttpCode);
        }

        [Fact]
        public async Task CreateAssemblyWithNotification_Should_ContainNotificationData()
        {
            var assemblyRequest = new AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase>
                {
                    ["import"] = new TestHttpImportRobot
                    {
                        Url = "https://demos.transloadit.com/66/01604e7d0248109df8c7cc0f8daef8/snowflake.jpg"
                    },
                },
                NotifyUrl = Transloadit.NotifyUrl,
            };

            var createResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
            Assert.True(createResponse.IsSuccessResponse());
            Assert.Equal(ResponseCodes.AssemblyExecuting, createResponse.Base.Ok);
            Assert.Equal(Transloadit.NotifyUrl, createResponse.NotifyUrl);

            AssemblyResponse assembly;
            while (true)
            {
                await Task.Delay(1000);
                assembly = await TransloaditClient.Assemblies.GetAsync(createResponse.AssemblyId);

                if (assembly.Base.Ok != ResponseCodes.AssemblyExecuting)
                {
                    break;
                }
            }

            //waiting 2 second allowing notification to finish
            await Task.Delay(2000);
            assembly = await TransloaditClient.Assemblies.GetAsync(createResponse.AssemblyId);

            Assert.Equal(Transloadit.NotifyUrl, assembly.NotifyUrl);
            Assert.Equal(200, assembly.NotifyResponseCode);
            Assert.True(assembly.NotifyDuration > 0d);
            Assert.True(assembly.NotifyStart.HasValue);
            Assert.NotNull(assembly.NotifyResponseData);
        }

        [Fact]
        public async Task CreateAssemblyWithTemplateWithNotificationUrl_Should_ContainNotificationData()
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
                    },
                    NotifyUrl = Transloadit.NotifyUrl,
                }
            };
            var templateResponse = await TransloaditClient.Templates.CreateAsync(templateRequest);
            Assert.True(templateResponse.IsSuccessResponse());
            Assert.Equal(ResponseCodes.TemplateCreated, templateResponse.Base.Ok);

            var assemblyRequest = new AssemblyRequest
            {
                TemplateId = templateResponse.Id
            };

            var createResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
            Assert.True(createResponse.IsSuccessResponse());
            Assert.Equal(ResponseCodes.AssemblyExecuting, createResponse.Base.Ok);
            Assert.Equal(Transloadit.NotifyUrl, createResponse.NotifyUrl);

            AssemblyResponse assembly;
            while (true)
            {
                await Task.Delay(1000);
                assembly = await TransloaditClient.Assemblies.GetAsync(createResponse.AssemblyId);

                if (assembly.Base.Ok != ResponseCodes.AssemblyExecuting)
                {
                    break;
                }
            }

            //waiting 2 second allowing notification to finish
            await Task.Delay(2000);
            assembly = await TransloaditClient.Assemblies.GetAsync(createResponse.AssemblyId);

            Assert.Equal(Transloadit.NotifyUrl, assembly.NotifyUrl);
            Assert.Equal(200, assembly.NotifyResponseCode);
            Assert.True(assembly.NotifyDuration > 0d);
            Assert.True(assembly.NotifyStart.HasValue);
            Assert.NotNull(assembly.NotifyResponseData);

            var deleteTemplateResponse = await TransloaditClient.Templates.DeleteAsync(templateResponse.Id);
            Assert.True(deleteTemplateResponse.IsSuccessResponse());
            Assert.Equal(ResponseCodes.TemplateDeleted, deleteTemplateResponse.Base.Ok);
        }
    }
}