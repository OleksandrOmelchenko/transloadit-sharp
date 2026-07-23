using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit
{
    public class TransloaditClientPipelineTests
    {
        private const string AssemblyJson = "{\"ok\":\"ASSEMBLY_COMPLETED\",\"assembly_id\":\"abc\"}";
        private const string ListJson = "{\"ok\":\"ASSEMBLIES_FOUND\",\"count\":0,\"items\":[]}";

        [Fact]
        public async Task Get_UnsignedEndpoint_PutsParamsInQueryWithoutSignature()
        {
            var handler = FakeHttpMessageHandler.Json(AssemblyJson);
            var client = TestClientFactory.Create(handler);

            var response = await client.Assemblies.GetAsync("abc");

            Assert.Equal(HttpMethod.Get, handler.LastMethod);
            Assert.StartsWith("https://api.test/assemblies/abc?", handler.LastRequestUri.ToString());
            Assert.Contains("params=", handler.LastRequestUri.Query);
            Assert.DoesNotContain("signature=", handler.LastRequestUri.Query);
            Assert.True(response.IsSuccessResponse());
            Assert.Equal("abc", response.AssemblyId);
        }

        [Fact]
        public async Task Get_SignedEndpoint_PutsSignatureInQuery()
        {
            var handler = FakeHttpMessageHandler.Json(ListJson);
            var client = TestClientFactory.Create(handler);

            await client.Assemblies.GetListAsync();

            Assert.Contains("params=", handler.LastRequestUri.Query);
            Assert.Contains("signature=", handler.LastRequestUri.Query);
        }

        [Fact]
        public async Task Get_SignedEndpoint_WithoutSecret_OmitsSignature()
        {
            var handler = FakeHttpMessageHandler.Json(ListJson);
            var client = TestClientFactory.Create(handler, withSecret: false);

            await client.Assemblies.GetListAsync();

            Assert.Contains("params=", handler.LastRequestUri.Query);
            Assert.DoesNotContain("signature=", handler.LastRequestUri.Query);
        }

        [Fact]
        public async Task Post_PutsParamsAndSignatureInMultipartBody()
        {
            var handler = FakeHttpMessageHandler.Json(AssemblyJson);
            var client = TestClientFactory.Create(handler);

            await client.Assemblies.CreateAsync(new AssemblyRequest { TemplateId = "tpl" });

            Assert.Equal(HttpMethod.Post, handler.LastMethod);
            Assert.Contains("template_id", handler.LastRequestContent);
            Assert.Contains("params", handler.LastRequestContent);
            Assert.Contains("signature", handler.LastRequestContent);
        }

        [Fact]
        public async Task Request_SetsTransloaditClientHeader()
        {
            var handler = FakeHttpMessageHandler.Json(AssemblyJson);
            var client = TestClientFactory.Create(handler);

            await client.Assemblies.GetAsync("abc");

            Assert.True(handler.LastRequest.Headers.Contains("Transloadit-Client"));
            var value = string.Join(string.Empty, handler.LastRequest.Headers.GetValues("Transloadit-Client"));
            Assert.Equal($"transloadit-sharp/{ClientVersion.Current}", value);
        }

        [Fact]
        public async Task Response_AttachesRawTransloaditResponse()
        {
            var handler = FakeHttpMessageHandler.Json(AssemblyJson, HttpStatusCode.OK);
            var client = TestClientFactory.Create(handler);

            var response = await client.Assemblies.GetAsync("abc");

            Assert.NotNull(response.TransloaditResponse);
            Assert.Equal(HttpStatusCode.OK, response.TransloaditResponse.StatusCode);
            Assert.Equal(AssemblyJson, response.TransloaditResponse.Content);
        }

        [Fact]
        public async Task Post_DoesNotMutateCallerAuth()
        {
            var handler = FakeHttpMessageHandler.Json(AssemblyJson);
            var client = TestClientFactory.Create(handler);
            var request = new AssemblyRequest { TemplateId = "tpl" };

            await client.Assemblies.CreateAsync(request);

            // the signed request injects auth.key + expires only for the wire payload; it must not persist them on the
            // caller's object, or reusing the request would freeze `expires` and later calls would be rejected as expired
            Assert.Null(request.Auth);
        }

        [Fact]
        public async Task Response_EmptyBody_DoesNotThrowAndSurfacesStatus()
        {
            var handler = FakeHttpMessageHandler.Json(string.Empty, HttpStatusCode.BadGateway);
            var client = TestClientFactory.Create(handler);

            var response = await client.Assemblies.GetAsync("abc");

            // an empty gateway-error body must not throw; the caller can still read the HTTP status
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.BadGateway, response.TransloaditResponse.StatusCode);
        }

        [Fact]
        public async Task Token_UsesBasicAuthAndGrantType()
        {
            var handler = FakeHttpMessageHandler.Json(
                "{\"access_token\":\"tok\",\"token_type\":\"Bearer\",\"expires_in\":3600}");
            var client = TestClientFactory.Create(handler);

            await client.Tokens.CreateAsync();

            Assert.Equal(HttpMethod.Post, handler.LastMethod);
            Assert.EndsWith("/token", handler.LastRequestUri.AbsolutePath);
            Assert.Contains("grant_type=client_credentials", handler.LastRequestContent);

            var authorization = handler.LastRequest.Headers.Authorization;
            Assert.Equal("Basic", authorization.Scheme);
            var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(authorization.Parameter));
            Assert.Equal($"{TestClientFactory.Key}:{TestClientFactory.Secret}", decoded);
        }

        [Fact]
        public async Task Token_WithoutSecret_Throws()
        {
            var handler = FakeHttpMessageHandler.Json("{}");
            var client = TestClientFactory.Create(handler, withSecret: false);

            await Assert.ThrowsAsync<InvalidOperationException>(() => client.Tokens.CreateAsync());
        }
    }
}
