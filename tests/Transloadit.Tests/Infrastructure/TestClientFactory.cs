using System;
using System.Net.Http;

namespace Transloadit.Tests.Infrastructure;

// builds a TransloaditClient wired to a fake handler, so no network is touched
internal static class TestClientFactory
{
    public const string Key = "test-key";
    public const string Secret = "test-secret";

    public static readonly Uri ApiBase = new Uri("https://api.test/");

    public static TransloaditClient Create(FakeHttpMessageHandler handler, bool withSecret = true)
    {
        var options = new TransloaditClientOptions
        {
            ApiBase = ApiBase,
            HttpClient = new HttpClient(handler),
        };

        return withSecret
            ? new TransloaditClient(Key, Secret, options)
            : new TransloaditClient(Key, options);
    }
}
