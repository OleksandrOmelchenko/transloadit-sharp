using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Models.AssemblyNotifications;
using Transloadit.Models.Robots;
using Transloadit.Models.Templates;
using Transloadit.Tests.Fixtures;
using Xunit;

namespace Transloadit.Tests.Tests.Api;

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
    public async Task ReplayAssemblyNotification_Should_Succeed()
    {
        var assemblyRequest = new AssemblyRequest
        {
            Steps = new Dictionary<string, RobotBase>
            {
                ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
            },
            NotifyUrl = Configuration.NotifyUrl,
        };

        var createResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
        Assert.True(createResponse.IsSuccessResponse());
        Assert.Equal(ResponseCodes.AssemblyExecuting, createResponse.Base.Ok);
        Assert.Equal(Configuration.NotifyUrl, createResponse.NotifyUrl);

        await AssemblyTracker.WaitCompletionAsync(createResponse);
        var assembly = await WaitForNotificationAsync(createResponse.AssemblyId);

        AssertNotificationSucceeded(assembly);

        var notificationReplayResponse = await TransloaditClient.AssemblyNotifications.ReplayAsync(assembly.AssemblyId);

        Assert.True(notificationReplayResponse.IsSuccessResponse());
        Assert.Equal(ResponseCodes.AssemblyNotificationReplayed, notificationReplayResponse.Base.Ok);
    }

    [Fact]
    public async Task ReplayAssemblyNotificationWithOptions_Should_Succeed()
    {
        var assemblyRequest = new AssemblyRequest
        {
            Steps = new Dictionary<string, RobotBase>
            {
                ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
            },
            NotifyUrl = Configuration.NotifyUrl,
        };

        var createResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
        await AssemblyTracker.WaitCompletionAsync(createResponse);

        // replay overriding the notify url and waiting for the replayed notification to finish
        var replayResponse = await TransloaditClient.AssemblyNotifications.ReplayAsync(
            createResponse.AssemblyId,
            new ReplayNotificationRequest { NotifyUrl = Configuration.NotifyUrl, Wait = true });

        Assert.True(replayResponse.IsSuccessResponse());
        Assert.Equal(ResponseCodes.AssemblyNotificationReplayed, replayResponse.Base.Ok);
    }

    [Fact]
    public async Task CreateAssemblyWithNotification_Should_ContainNotificationData()
    {
        var assemblyRequest = new AssemblyRequest
        {
            Steps = new Dictionary<string, RobotBase>
            {
                ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
            },
            NotifyUrl = Configuration.NotifyUrl,
        };

        var createResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
        Assert.True(createResponse.IsSuccessResponse());
        Assert.Equal(ResponseCodes.AssemblyExecuting, createResponse.Base.Ok);
        Assert.Equal(Configuration.NotifyUrl, createResponse.NotifyUrl);

        await AssemblyTracker.WaitCompletionAsync(createResponse);
        var assembly = await WaitForNotificationAsync(createResponse.AssemblyId);

        AssertNotificationSucceeded(assembly);
        // a successful notification never carries an error
        Assert.Null(assembly.NotifyError);
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
                    ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                },
                NotifyUrl = Configuration.NotifyUrl,
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
        Assert.Equal(Configuration.NotifyUrl, createResponse.NotifyUrl);

        await AssemblyTracker.WaitCompletionAsync(createResponse);
        var assembly = await WaitForNotificationAsync(createResponse.AssemblyId);
        AssertNotificationSucceeded(assembly);

        var deleteTemplateResponse = await TransloaditClient.Templates.DeleteAsync(templateResponse.Id);
        Assert.True(deleteTemplateResponse.IsSuccessResponse());
        Assert.Equal(ResponseCodes.TemplateDeleted, deleteTemplateResponse.Base.Ok);
    }

    private static void AssertNotificationSucceeded(AssemblyResponse assembly)
    {
        Assert.Equal(200, assembly.NotifyResponseCode);
        Assert.True(assembly.NotifyDuration > 0d);
        Assert.True(assembly.NotifyStart.HasValue);
        Assert.NotNull(assembly.NotifyResponseData);
    }

    // poll the assembly until the notification has been delivered (notify_response_code populated) rather than
    // waiting a fixed delay, which is flaky when the notification takes longer than expected
    private async Task<AssemblyResponse> WaitForNotificationAsync(string assemblyId, int maxAttempts = 15, int delayMs = 2000)
    {
        AssemblyResponse assembly = null;
        for (var attempt = 0; attempt < maxAttempts; attempt++)
        {
            assembly = await TransloaditClient.Assemblies.GetAsync(assemblyId);
            if (assembly.NotifyResponseCode.HasValue)
            {
                break;
            }

            await Task.Delay(delayMs);
        }

        return assembly;
    }
}
