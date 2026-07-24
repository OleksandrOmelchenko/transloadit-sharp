using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Transloadit.Models;
using Transloadit.Serialization;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit;

public class ResponseBaseTests
{
    [Fact]
    public void IsSuccessResponse_WhenOkPresent_ReturnsTrue()
    {
        var response = new ResponseBase();
        response.Base.Ok = "OK";
        Assert.True(response.IsSuccessResponse());
    }

    [Fact]
    public void IsSuccessResponse_WhenNeitherOkNorError_ReturnsTrue()
    {
        var response = new ResponseBase();
        Assert.True(response.IsSuccessResponse());
    }

    [Fact]
    public void IsSuccessResponse_WhenErrorPresentAndNoOk_ReturnsFalse()
    {
        var response = new ResponseBase();
        response.Base.Error = "SOME_ERROR";
        Assert.False(response.IsSuccessResponse());
    }

    [Fact]
    public void IsSuccessResponse_WhenBothOkAndError_ReturnsTrue()
    {
        var response = new ResponseBase();
        response.Base.Ok = "OK";
        response.Base.Error = "SOME_ERROR";
        Assert.True(response.IsSuccessResponse());
    }

    [Fact]
    public void TransloaditResponse_ExposesConstructorValues()
    {
        using var message = new HttpResponseMessage(HttpStatusCode.Accepted);
        var raw = new TransloaditResponse(HttpStatusCode.Accepted, message.Headers, "body");

        Assert.Equal(HttpStatusCode.Accepted, raw.StatusCode);
        Assert.Equal("body", raw.Content);
        Assert.NotNull(raw.Headers);
    }

    [Fact]
    public void PaginatedListResponse_DeserializesCountAndItems()
    {
        const string json = "{\"ok\":\"OK\",\"count\":2,\"items\":[1,2]}";
        var response = TestSerializer.Default.Deserialize<PaginatedListResponse<int>>(json);

        Assert.Equal(2, response.Count);
        Assert.Equal(new[] { 1, 2 }, response.Items);
        Assert.True(response.IsSuccessResponse());
    }
}
