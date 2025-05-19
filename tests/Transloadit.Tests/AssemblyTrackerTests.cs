using System.Collections.Generic;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Models.Robots.FileImporting;
using Transloadit.Utilities;
using Xunit;

namespace Transloadit.Tests
{
    public class AssemblyTrackerTests : TestBase
    {
        private async Task<AssemblyResponse> CreateAssemblyAsync()
        {
            var assemblyRequest = new AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase>
                {
                    ["import"] = new HttpImportRobot
                    {
                        Url = "https://demos.transloadit.com/66/01604e7d0248109df8c7cc0f8daef8/snowflake.jpg",
                    }
                }
            };

            return await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
        }

        [Fact]
        public async Task TestWaitCompletion_ShouldReturnCompletedAssembly()
        {
            var assemblyTracker = new AssemblyTracker(TransloaditClient);

            var createAssemblyResponse = await CreateAssemblyAsync();
            Assert.True(createAssemblyResponse.IsSuccessResponse());

            var completedAssembly = await assemblyTracker.WaitCompletionAsync(createAssemblyResponse.AssemblyId);
            Assert.Equal(ResponseCodes.AssemblyCompleted, completedAssembly.Base.Ok);
        }

        [Fact]
        public async Task TestWaitCompletionLong_ShouldReturnCompletedAssembly()
        {
            var assemblyTracker = new AssemblyTracker(TransloaditClient);

            var createAssemblyResponse = await CreateAssemblyAsync();
            Assert.True(createAssemblyResponse.IsSuccessResponse());

            var completedAssembly = await assemblyTracker.WaitCompletionAsync(createAssemblyResponse.AssemblyId, 5000);
            Assert.Equal(ResponseCodes.AssemblyCompleted, completedAssembly.Base.Ok);
        }

        [Fact]
        public async Task TestLongDelay_ShortTimeout_ShouldFail()
        {
            var options = new AssemblyTrackerOptions
            {
                WaitCompletionTimeout = 1000
            };
            var assemblyTracker = new AssemblyTracker(TransloaditClient, options);

            var createAssemblyResponse = await CreateAssemblyAsync();
            Assert.True(createAssemblyResponse.IsSuccessResponse());

            await Assert.ThrowsAsync<TaskCanceledException>(async () =>
            {
                _ = await assemblyTracker.WaitCompletionAsync(createAssemblyResponse.AssemblyId, 3000);
            });
        }
    }
}