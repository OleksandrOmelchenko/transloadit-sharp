using System;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Tests.Infrastructure;
using Transloadit.Utilities;
using Xunit;

namespace Transloadit.Tests.Tests.Unit
{
    public class AssemblyTrackerOfflineTests
    {
        private const string Executing = "{\"ok\":\"ASSEMBLY_EXECUTING\",\"assembly_id\":\"abc\"}";
        private const string Completed = "{\"ok\":\"ASSEMBLY_COMPLETED\",\"assembly_id\":\"abc\"}";

        [Fact]
        public async Task WaitCompletionAsync_PollsUntilCompleted()
        {
            // first poll returns executing, subsequent polls return completed
            var handler = FakeHttpMessageHandler.Sequence(Executing, Completed);
            var client = TestClientFactory.Create(handler);
            var tracker = new AssemblyTracker(client);

            var completed = await tracker.WaitCompletionAsync("abc", millisecondsDelay: 1);

            Assert.Equal(ResponseCodes.AssemblyCompleted, completed.Base.Ok);
            Assert.True(handler.CallCount >= 2);
        }

        [Fact]
        public async Task WaitCompletionAsync_WhenNeverCompletes_TimesOut()
        {
            // always executing, so the tracker keeps polling until the timeout cancels it
            var handler = FakeHttpMessageHandler.Json(Executing);
            var client = TestClientFactory.Create(handler);
            var tracker = new AssemblyTracker(client, new AssemblyTrackerOptions { WaitCompletionTimeout = 50 });

            await Assert.ThrowsAnyAsync<OperationCanceledException>(
                () => tracker.WaitCompletionAsync("abc", millisecondsDelay: 20));
        }
    }
}
