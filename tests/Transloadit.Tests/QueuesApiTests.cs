using System.Threading.Tasks;
using Xunit;

namespace Transloadit.Tests
{
    public class QueuesApiTests : TestBase
    {
        [Fact]
        public async Task GetQueue()
        {
            var jobSlots = await TransloaditClient.Queues.GetJobSlotsAsync();

            Assert.Equal("PRIORITY_JOB_SLOTS_FOUND", jobSlots.Base.Ok);
        }
    }
}