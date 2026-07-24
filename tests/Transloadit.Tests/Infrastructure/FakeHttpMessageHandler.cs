using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Transloadit.Tests.Infrastructure;

// captures outgoing requests and returns canned responses so the client
// request/response pipeline can be exercised without touching the network
internal sealed class FakeHttpMessageHandler : HttpMessageHandler
{
    private readonly Func<HttpRequestMessage, int, HttpResponseMessage> _responder;
    private int _callCount;

    public FakeHttpMessageHandler(Func<HttpRequestMessage, int, HttpResponseMessage> responder)
    {
        _responder = responder;
    }

    public int CallCount => _callCount;
    public HttpRequestMessage LastRequest { get; private set; }
    public Uri LastRequestUri { get; private set; }
    public HttpMethod LastMethod { get; private set; }
    public string LastRequestContent { get; private set; }
    public List<string> RequestContents { get; } = new List<string>();
    public List<Uri> RequestUris { get; } = new List<Uri>();

    // always responds with the same json body
    public static FakeHttpMessageHandler Json(string json, HttpStatusCode status = HttpStatusCode.OK)
        => new FakeHttpMessageHandler((_, __) => Respond(json, status));

    // responds with each body in order; repeats the last one once exhausted
    public static FakeHttpMessageHandler Sequence(params string[] jsonBodies)
        => new FakeHttpMessageHandler((_, i) => Respond(jsonBodies[Math.Min(i, jsonBodies.Length - 1)]));

    private static HttpResponseMessage Respond(string json, HttpStatusCode status = HttpStatusCode.OK)
        => new HttpResponseMessage(status)
        {
            Content = new StringContent(json ?? string.Empty, Encoding.UTF8, "application/json"),
        };

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var index = _callCount++;
        LastRequest = request;
        LastRequestUri = request.RequestUri;
        LastMethod = request.Method;
        RequestUris.Add(request.RequestUri);

        string content = null;
        if (request.Content != null)
        {
            content = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        LastRequestContent = content;
        RequestContents.Add(content);

        return _responder(request, index);
    }
}
