using System.Net.Http;
using System.Threading.Tasks;
using Transloadit.Models.Credentials;
using Transloadit.Models.Templates;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit;

// exercises each service's endpoint mapping (verb + path) through the fake handler,
// so the SendRequest delegation is covered without live credentials
public class ServiceEndpointTests
{
    private const string Ok = "{\"ok\":\"OK\"}";
    private const string OkList = "{\"ok\":\"OK\",\"count\":0,\"items\":[]}";

    [Fact]
    public async Task Billing_Get_MapsToBillEndpoint()
    {
        var handler = FakeHttpMessageHandler.Json(Ok);
        var client = TestClientFactory.Create(handler);

        await client.Billing.GetAsync(2025, 2);

        Assert.Equal(HttpMethod.Get, handler.LastMethod);
        Assert.Equal("/bill/2025-02", handler.LastRequestUri.AbsolutePath);
    }

    [Fact]
    public async Task Queues_GetJobSlots_MapsToQueuesEndpoint()
    {
        var handler = FakeHttpMessageHandler.Json(Ok);
        var client = TestClientFactory.Create(handler);

        await client.Queues.GetJobSlotsAsync();

        Assert.Equal(HttpMethod.Get, handler.LastMethod);
        Assert.Equal("/queues/job_slots", handler.LastRequestUri.AbsolutePath);
    }

    [Fact]
    public async Task AssemblyNotifications_Replay_MapsToReplayEndpoint()
    {
        var handler = FakeHttpMessageHandler.Json(Ok);
        var client = TestClientFactory.Create(handler);

        await client.AssemblyNotifications.ReplayAsync("a1");

        Assert.Equal(HttpMethod.Post, handler.LastMethod);
        Assert.Equal("/assembly_notifications/a1/replay", handler.LastRequestUri.AbsolutePath);
    }

    [Theory]
    [InlineData("get")]
    [InlineData("list")]
    [InlineData("create")]
    [InlineData("update")]
    [InlineData("delete")]
    public async Task Templates_Methods_MapToTemplatesEndpoints(string operation)
    {
        var handler = FakeHttpMessageHandler.Json(operation == "list" ? OkList : Ok);
        var client = TestClientFactory.Create(handler);

        switch (operation)
        {
            case "get":
                await client.Templates.GetAsync("t1");
                Assert.Equal(HttpMethod.Get, handler.LastMethod);
                Assert.Equal("/templates/t1", handler.LastRequestUri.AbsolutePath);
                break;
            case "list":
                await client.Templates.GetListAsync();
                Assert.Equal(HttpMethod.Get, handler.LastMethod);
                Assert.Equal("/templates", handler.LastRequestUri.AbsolutePath);
                break;
            case "create":
                await client.Templates.CreateAsync(new TemplateRequest { Name = "n" });
                Assert.Equal(HttpMethod.Post, handler.LastMethod);
                Assert.Equal("/templates", handler.LastRequestUri.AbsolutePath);
                break;
            case "update":
                await client.Templates.UpdateAsync("t1", new TemplateRequest { Name = "n" });
                Assert.Equal(HttpMethod.Put, handler.LastMethod);
                Assert.Equal("/templates/t1", handler.LastRequestUri.AbsolutePath);
                break;
            case "delete":
                await client.Templates.DeleteAsync("t1");
                Assert.Equal(HttpMethod.Delete, handler.LastMethod);
                Assert.Equal("/templates/t1", handler.LastRequestUri.AbsolutePath);
                break;
        }
    }

    [Theory]
    [InlineData("get")]
    [InlineData("list")]
    [InlineData("create")]
    [InlineData("update")]
    [InlineData("delete")]
    public async Task Credentials_Methods_MapToCredentialsEndpoints(string operation)
    {
        var handler = FakeHttpMessageHandler.Json(operation == "list" ? OkList : Ok);
        var client = TestClientFactory.Create(handler);

        switch (operation)
        {
            case "get":
                await client.Credentials.GetAsync("c1");
                Assert.Equal(HttpMethod.Get, handler.LastMethod);
                Assert.Equal("/template_credentials/c1", handler.LastRequestUri.AbsolutePath);
                break;
            case "list":
                await client.Credentials.GetListAsync();
                Assert.Equal(HttpMethod.Get, handler.LastMethod);
                Assert.Equal("/template_credentials", handler.LastRequestUri.AbsolutePath);
                break;
            case "create":
                await client.Credentials.CreateAsync(new S3CredentialsRequest { Name = "n" });
                Assert.Equal(HttpMethod.Post, handler.LastMethod);
                Assert.Equal("/template_credentials", handler.LastRequestUri.AbsolutePath);
                break;
            case "update":
                await client.Credentials.UpdateAsync("c1", new S3CredentialsRequest { Name = "n" });
                Assert.Equal(HttpMethod.Put, handler.LastMethod);
                Assert.Equal("/template_credentials/c1", handler.LastRequestUri.AbsolutePath);
                break;
            case "delete":
                await client.Credentials.DeleteAsync("c1");
                Assert.Equal(HttpMethod.Delete, handler.LastMethod);
                Assert.Equal("/template_credentials/c1", handler.LastRequestUri.AbsolutePath);
                break;
        }
    }
}
