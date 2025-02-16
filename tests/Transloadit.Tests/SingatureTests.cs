using Transloadit.Utilities;
using Xunit;

namespace Transloadit.Tests
{
    public class SingatureTests : TestBase
    {
        [Fact]
        public void TestSignature()
        {
            var input = "";
            var signature = "84648864";

            Assert.True(SignatureUtilities.ValidateSignature(input, Transloadit.AuthSecret, signature));
        }
    }
}