using System;
using System.Threading.Tasks;
using Transloadit.Constants;
using Xunit;

namespace Transloadit.Tests
{
    public class BillingApiTests : TestBase
    {
        [Fact]
        public async Task GetBillingByDateTime_Should_Succeed()
        {
            var billing = await TransloaditClient.Billing.GetAsync(DateTime.Now);

            Assert.Equal(ResponseCodes.BillFound, billing.Base.Ok);
            Assert.True(billing.IsSuccessResponse());
        }

        [Fact]
        public async Task GetBillingByYearAndMonth_Should_Succeed()
        {
            var billing = await TransloaditClient.Billing.GetAsync(2025, 2);

            Assert.Equal(ResponseCodes.BillFound, billing.Base.Ok);
            Assert.True(billing.IsSuccessResponse());
        }

        [Fact(Skip = "For some reason response is always successful")]
        public async Task GetNonExistingBilling_Should_Fail()
        {
            var future = DateTime.Now.AddMonths(2);
            var billing = await TransloaditClient.Billing.GetAsync(future);
            Assert.Equal("BILL_ERROR_OR_SOMETHING", billing.Base.Error);
            Assert.False(billing.IsSuccessResponse());
        }
    }
}