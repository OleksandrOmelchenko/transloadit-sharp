using System.Threading.Tasks;
using Transloadit.Tests.Configuration;
using Xunit;

namespace Transloadit.Tests
{
    public class AssemblyNotificationsApiTests : TestBase
    {
        [Theory]
        [InlineData("6c5ad8ac73024db381ce8a9f2de3f9e1")]
        [InlineData("non-existent-id")]
        public async Task ReplayAssemblyNotification(string assemblyId)
        {
            var templates = await TransloaditClient.AssemblyNotifications.ReplayAsync(assemblyId);

            // Assert.Equal("BILL_FOUND", billing.Ok);
        }
    }
}