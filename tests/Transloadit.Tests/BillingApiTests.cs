using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Transloadit.Tests.Configuration;
using Xunit;

namespace Transloadit.Tests
{
    public class BillingApiTests
    {
        [Fact]
        public async Task GetBillingDateTime()
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);
            var billing = await client.Billing.GetAsync(DateTime.Now);

            Assert.Equal("BILL_FOUND", billing.Ok);
        }

        [Fact]
        public async Task GetBillingYearMonth()
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);
            var billing = await client.Billing.GetAsync(2025, 2);

            Assert.Equal("BILL_FOUND", billing.Ok);
        }
    }
}