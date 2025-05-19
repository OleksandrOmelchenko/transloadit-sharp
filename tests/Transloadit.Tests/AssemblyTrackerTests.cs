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
        [Fact]
        public async Task TestWaitCompletion_ShouldReturnCompletedAssembly()
        {
            var assemblyTracker = new AssemblyTracker(TransloaditClient);

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

            var createAssemblyResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
            Assert.True(createAssemblyResponse.IsSuccessResponse());

            var completedAssembly = await assemblyTracker.WaitCompletionAsync(createAssemblyResponse.AssemblyId);
            Assert.Equal(ResponseCodes.AssemblyCompleted, completedAssembly.Base.Ok);
        }
    }
}