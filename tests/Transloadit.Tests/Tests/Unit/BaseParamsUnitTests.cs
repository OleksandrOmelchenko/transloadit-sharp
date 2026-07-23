using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transloadit.Models;
using Transloadit.Serialization;
using Xunit;

using Transloadit.Tests.Infrastructure;

namespace Transloadit.Tests.Tests.Unit
{
    public class BaseParamsUnitTests
    {
        [Fact]
        public void EnableSignatureAuth_DefaultsToTrue()
        {
            var parameters = new BaseParams();
            Assert.True(parameters.EnableSignatureAuth);
        }

        [Fact]
        public void DisableSignatureAuth_SetsFlagFalse()
        {
            var parameters = new BaseParams();
            parameters.DisableSignatureAuth();
            Assert.False(parameters.EnableSignatureAuth);
        }

        [Fact]
        public void SetAuth_StoresAuthParams()
        {
            var parameters = new BaseParams();
            var auth = new AuthParams { Key = "k" };

            parameters.SetAuth(auth);

            Assert.Same(auth, parameters.Auth);
        }

        [Fact]
        public void AuthParams_Serializes_WithSnakeCaseAndDateFormat()
        {
            var auth = new AuthParams
            {
                Key = "k",
                Expires = new DateTime(2025, 2, 20, 1, 52, 4, DateTimeKind.Utc),
                MaxSize = 100,
            };

            var json = TestSerializer.Default.Serialize(auth);
            var parsed = JObject.Parse(json);

            Assert.Equal("k", (string)parsed["key"]);
            Assert.Equal("2025/02/20 01:52:04+00:00", (string)parsed["expires"]);
            Assert.Equal(100, (int)parsed["max_size"]);
            // NullValueHandling.Ignore drops unset properties
            Assert.Null(parsed["nonce"]);
            Assert.Null(parsed["referer"]);
        }

        [Fact]
        public void PaginationParams_Serializes_WithSnakeCaseAndDateFormat()
        {
            var pagination = new PaginationParams
            {
                Page = 2,
                PageSize = 10,
                FromDate = new DateTime(2025, 2, 20, 1, 52, 4, DateTimeKind.Utc),
                Keywords = new List<string> { "alpha" },
            };

            var json = TestSerializer.Default.Serialize(pagination);
            var parsed = JObject.Parse(json);

            Assert.Equal(2, (int)parsed["page"]);
            Assert.Equal(10, (int)parsed["pagesize"]);
            Assert.Equal("2025-02-20 01:52:04", (string)parsed["fromdate"]);
            Assert.Equal("alpha", (string)parsed["keywords"][0]);
        }
    }
}
