using System;
using System.Threading.Tasks;
using Transloadit.Models.Tokens;
using Xunit;
using Transloadit.Tests.Tests;

namespace Transloadit.Tests.Tests.Api
{
    public class TokensApiTests : TestBase
    {
        [Fact]
        public async Task CreateAsync_WithSecret_Should_ReturnBearerToken()
        {
            var response = await TransloaditClient.Tokens.CreateAsync();

            Assert.True(response.IsSuccessResponse());
            Assert.NotNull(response.TransloaditResponse);
            Assert.True((int)response.TransloaditResponse.StatusCode < 400);
            Assert.False(string.IsNullOrWhiteSpace(response.AccessToken));
            Assert.Equal("Bearer", response.TokenType);
            Assert.True(response.ExpiresIn > 0);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("assemblies:read", "api2")]
        [InlineData("assemblies:read assemblies:write", "api2")]
        public async Task CreateAsync_WithDifferentScopeAndAud_Should_ReturnBearerToken(string scope, string aud)
        {
            var response = await TransloaditClient.Tokens.CreateAsync(new TokenRequest
            {
                Scope = scope,
                Aud = aud,
            });

            Assert.True(response.IsSuccessResponse());
            Assert.NotNull(response.TransloaditResponse);
            Assert.True((int)response.TransloaditResponse.StatusCode < 400);
            Assert.False(string.IsNullOrWhiteSpace(response.AccessToken));
            Assert.Equal("Bearer", response.TokenType);
            Assert.True(response.ExpiresIn > 0);

            if (scope != null)
            {
                Assert.Equal(scope, response.Scope);
            }
        }

        [Fact]
        public async Task CreateAsync_WithoutSecret_Should_Throw()
        {
            var client = new TransloaditClient(Configuration.AuthKey);

            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => client.Tokens.CreateAsync());
            Assert.Contains("both key and secret", ex.Message);
        }
    }
}
