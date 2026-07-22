using System;
using System.Collections.Generic;
using Transloadit.Services;
using Transloadit.Utilities;
using Xunit;

namespace Transloadit.Tests.Tests.Unit
{
    public class SmartCdnServiceTests
    {
        private const string Key = "my-key";
        private const string Secret = "my-secret";

        // a fixed expiration keeps the produced url deterministic
        private static readonly DateTimeOffset Expiration = DateTimeOffset.FromUnixTimeMilliseconds(1700000000000);

        [Fact]
        public void GetSignedSmartCdnUrl_ProducesDeterministicSignedUrl()
        {
            var service = new SmartCdnService(Key, Secret);

            var url = service.GetSignedSmartCdnUrl(
                "ws",
                "tpl",
                "input",
                Expiration,
                new Dictionary<string, string> { ["width"] = "100" });

            // params are sorted by key: auth_key, exp, width
            const string query = "auth_key=my-key&exp=1700000000000&width=100";
            var stringToSign = $"ws/tpl/input?{query}";
            var expectedSignature = SignatureUtilities.CalculateSignature(stringToSign, Secret, SignatureAlgorithm.Sha256);

            Assert.Equal($"https://ws.tlcdn.com/tpl/input?{query}&sig={expectedSignature}", url);
        }

        [Fact]
        public void GetSignedSmartCdnUrl_UsesSha256Signature()
        {
            var service = new SmartCdnService(Key, Secret);
            var url = service.GetSignedSmartCdnUrl("ws", "tpl", "input", Expiration);
            Assert.Contains("&sig=sha256:", url);
        }

        [Fact]
        public void GetSignedSmartCdnUrl_WorksWithoutExtraParameters()
        {
            var service = new SmartCdnService(Key, Secret);
            var url = service.GetSignedSmartCdnUrl("ws", "tpl", "input", Expiration);

            Assert.Contains("auth_key=my-key", url);
            Assert.Contains("exp=1700000000000", url);
        }

        [Fact]
        public void GetSignedSmartCdnUrl_UrlEncodesParameterValues()
        {
            var service = new SmartCdnService(Key, Secret);
            var url = service.GetSignedSmartCdnUrl(
                "ws",
                "tpl",
                "input",
                Expiration,
                new Dictionary<string, string> { ["path"] = "/a b" });

            Assert.Contains("path=%2Fa+b", url);
        }
    }
}
