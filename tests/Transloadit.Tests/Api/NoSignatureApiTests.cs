using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Models.Templates;
using Transloadit.Tests.Fixtures;
using Xunit;

namespace Transloadit.Tests.Api
{
    public class NoSignatureApiTests : TestBase
    {
        [Fact]
        public async Task GetBilling_Should_Fail()
        {
            var billing = await TransloaditClientNoAuth.Billing.GetAsync(2025, 2);

            Assert.Equal(ResponseCodes.NoSignatureField, billing.Base.Error);
            Assert.Equal(400, billing.Base.HttpCode);
            Assert.False(billing.IsSuccessResponse());
        }

        [Fact]
        public async Task GetQueue_Should_Fail()
        {
            var jobSlots = await TransloaditClientNoAuth.Queues.GetJobSlotsAsync();

            Assert.Equal(ResponseCodes.NoSignatureField, jobSlots.Base.Error);
            Assert.Equal(400, jobSlots.Base.HttpCode);
            Assert.False(jobSlots.IsSuccessResponse());
        }

        [Fact]
        public async Task CreateAssemblyWithSteps_Should_Succeed()
        {
            var createAssembly = new AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase>
                {
                    ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                }
            };
            var response = await TransloaditClientNoAuth.Assemblies.CreateAsync(createAssembly);

            Assert.True(response.IsSuccessResponse());
            Assert.Equal(ResponseCodes.AssemblyExecuting, response.Base.Ok);
            var statusResponse = await TransloaditClientNoAuth.Assemblies.GetAsync(response.AssemblyId);

            Assert.True(statusResponse.IsSuccessResponse());
            Assert.Equal(response.AssemblyId, statusResponse.AssemblyId);

            var statusResponse2 = await TransloaditClientNoAuth.Assemblies.GetAsync(new Uri(response.AssemblySslUrl));
            Assert.True(statusResponse2.IsSuccessResponse());
            Assert.Equal(response.AssemblyId, statusResponse2.AssemblyId);
        }

        [Fact]
        public async Task CreateAssemblyWithTemplateAuthNotRequired_Should_Succeed()
        {
            var createTemplate = new TemplateRequest
            {
                Name = $"test-no-auth-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                RequireSignatureAuth = false,
                Template = new TemplateRequestContent
                {
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                    }
                }
            };

            var templateResponse = await TransloaditClient.Templates.CreateAsync(createTemplate);
            Assert.True(templateResponse.IsSuccessResponse());
            Assert.Equal(ResponseCodes.TemplateCreated, templateResponse.Base.Ok);

            var createAssembly = new AssemblyRequest
            {
                TemplateId = templateResponse.Id,
            };
            var assemblyResponse = await TransloaditClientNoAuth.Assemblies.CreateAsync(createAssembly);

            Assert.True(assemblyResponse.IsSuccessResponse());
            Assert.Equal(ResponseCodes.AssemblyExecuting, assemblyResponse.Base.Ok);

            var deleteTemplateResponse = await TransloaditClient.Templates.DeleteAsync(templateResponse.Id);
            Assert.True(deleteTemplateResponse.IsSuccessResponse());
            Assert.Equal(ResponseCodes.TemplateDeleted, deleteTemplateResponse.Base.Ok);
        }

        [Fact]
        public async Task CreateAssemblyWithTemplateAuthRequired_Should_Fail()
        {
            var createTemplate = new TemplateRequest
            {
                Name = $"test-no-auth-template-{DateTime.UtcNow:yyyyMMddHHmmss}",
                RequireSignatureAuth = true,
                Template = new TemplateRequestContent
                {
                    Steps = new Dictionary<string, RobotBase>
                    {
                        ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                    }
                }
            };

            var templateResponse = await TransloaditClient.Templates.CreateAsync(createTemplate);
            Assert.True(templateResponse.IsSuccessResponse());
            Assert.Equal(ResponseCodes.TemplateCreated, templateResponse.Base.Ok);

            var createAssembly = new AssemblyRequest
            {
                TemplateId = templateResponse.Id,
            };
            var assemblyResponse = await TransloaditClientNoAuth.Assemblies.CreateAsync(createAssembly);

            Assert.Equal(ResponseCodes.NoAuthExpiresParameter, assemblyResponse.Base.Error);
            Assert.Equal(400, assemblyResponse.Base.HttpCode);
            Assert.False(assemblyResponse.IsSuccessResponse());

            var deleteTemplateResponse = await TransloaditClient.Templates.DeleteAsync(templateResponse.Id);
            Assert.True(deleteTemplateResponse.IsSuccessResponse());
            Assert.Equal(ResponseCodes.TemplateDeleted, deleteTemplateResponse.Base.Ok);
        }
    }
}