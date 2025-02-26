using System.Threading.Tasks;
using Transloadit.Constants;
using Xunit;

namespace Transloadit.Tests
{
    public class QueuesApiTests : TestBase
    {
        [Fact]
        public async Task GetQueue_Should_Succeed()
        {
            var jobSlots = await TransloaditClient.Queues.GetJobSlotsAsync();

            Assert.Equal(ResponseCodes.PriorityJobSlotsFound, jobSlots.Base.Ok);
            Assert.True(jobSlots.IsSuccessResponse());
        }
    }
}