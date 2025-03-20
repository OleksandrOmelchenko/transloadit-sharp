using Transloadit.Constants;
using Xunit;

namespace Transloadit.Tests
{
    public class ProjectTests
    {
        [Fact]
        public void TestAssemblyVersion_ShouldMatch_ClientVersionCurrent()
        {
            var assembly = typeof(TransloaditClient).Assembly;
            var version = assembly.GetName().Version;

            Assert.Equal(ClientVersion.Current, version.ToString(3));
        }
    }
}