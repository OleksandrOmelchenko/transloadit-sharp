using System.Collections.Generic;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Tests.Fixtures;
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
                    ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
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