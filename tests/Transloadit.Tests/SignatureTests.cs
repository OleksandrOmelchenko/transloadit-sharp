using Transloadit.Utilities;
using Xunit;

namespace Transloadit.Tests
{
    public class SignatureTests
    {
        [Theory]
        [InlineData(
            "{\"auth\":{\"key\":\"some-secret-key\",\"expires\":\"2025/02/20 01:52:04+00:00\"}}",
            "sha384:46759ef99a627c618b25207c105368b622814f55e89cf32adca1584e3c9a63f4792afecf2fffe070bd719756cbdd7c03",
            SignatureAlgorithm.Sha384)]
        [InlineData(
            "{\"auth\":{\"key\":\"some-secret-key\",\"expires\":\"2025/02/20 01:52:04+00:00\"}}",
            "sha256:bed10e9243c4fdc5498bf1637f5a88e469f1cdebdf5321769ed94e9d2c181b89",
            SignatureAlgorithm.Sha256)]
        [InlineData(
            "{\"auth\":{\"key\":\"some-secret-key\",\"expires\":\"2025/02/20 01:52:04+00:00\"}}",
            "1426bc584a4505656263e886414ae1a8ded10bf2",
            SignatureAlgorithm.Sha1)]
        public void TestCalculateSignature(string input, string expectedSignature, SignatureAlgorithm signatureAlgorithm)
        {
            var hashKey = "ZAoE63deFCA915LupzPqTyOv4WCZmuOwJioIxwF3";
            var signature = SignatureUtilities.CalculateSignature(input, hashKey, signatureAlgorithm);
            Assert.Equal(expectedSignature, signature);
        }

        [Theory]
        [InlineData(
            "{\"auth\":{\"key\":\"some-secret-key\",\"expires\":\"2025/02/20 01:52:04+00:00\"}}",
            "sha384:46759ef99a627c618b25207c105368b622814f55e89cf32adca1584e3c9a63f4792afecf2fffe070bd719756cbdd7c03")]
        [InlineData(
            "{\"auth\":{\"key\":\"some-secret-key\",\"expires\":\"2025/02/20 01:52:04+00:00\"}}",
            "sha256:bed10e9243c4fdc5498bf1637f5a88e469f1cdebdf5321769ed94e9d2c181b89")]
        [InlineData(
            "{\"auth\":{\"key\":\"some-secret-key\",\"expires\":\"2025/02/20 01:52:04+00:00\"}}",
            "1426bc584a4505656263e886414ae1a8ded10bf2")]
        public void TestValidateSignature(string input, string expectedSignature)
        {
            var hashKey = "ZAoE63deFCA915LupzPqTyOv4WCZmuOwJioIxwF3";
            var validated = SignatureUtilities.ValidateSignature(input, hashKey, expectedSignature);
            Assert.True(validated);
        }
    }
}