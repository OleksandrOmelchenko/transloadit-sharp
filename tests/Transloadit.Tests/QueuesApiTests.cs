using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Transloadit.Tests.Configuration;
using Xunit;

namespace Transloadit.Tests
{
    public class QueuesApiTests
    {
        [Fact]
        public async Task GetQueue()
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);
            /* var par = new PaginationParams
             {
                 PageSize = 10,
                 Page = 0
             };*/
            var templates = await client.Queues.GetAsync();

            // Assert.Equal("BILL_FOUND", billing.Ok);
        }

    }
}