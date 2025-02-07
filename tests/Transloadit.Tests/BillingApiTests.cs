using System;
using System.Threading.Tasks;
using Xunit;

namespace Transloadit.Tests
{
    public class BillingApiTests : TestBase
    {
        [Fact]
        public async Task GetBillingDateTime()
        {
            var billing = await TransloaditClient.Billing.GetAsync(DateTime.Now);

            Assert.Equal("BILL_FOUND", billing.Base.Ok);
        }

        [Fact]
        public async Task GetBillingYearMonth()
        {
            var billing = await TransloaditClient.Billing.GetAsync(2025, 2);

            Assert.Equal("BILL_FOUND", billing.Base.Ok);
        }

        [Fact(Skip = "For some reason response is always successful")]
        public async Task GetNonExistingBilling()
        {
            var future = DateTime.Now.AddMonths(2);
            var billing = await TransloaditClient.Billing.GetAsync(future);
            Assert.Equal("BILL_ERROR_OR_SOMETHING", billing.Base.Ok);
        }
    }
}