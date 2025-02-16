using System.Collections.Generic;
using System.Threading.Tasks;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Xunit;

namespace Transloadit.Tests
{
    public class AssemblyNotificationsApiTests : TestBase
    {
        [Fact]
        public async Task ReplayNonExistentAssemblyNotification()
        {
            var response = await TransloaditClient.AssemblyNotifications.ReplayAsync("non-existent");

            Assert.Equal("SERVER_404", response.Base.Error);
            Assert.Equal(404, response.Base.HttpCode);
        }

        [Fact]
        public async Task ReplayAssemblyNotification()
        {
            var assemblyRequest = new AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase>
                {
                    ["import"] = new TestHttpImportRobot
                    {
                        Url = "https://demos.transloadit.com/66/01604e7d0248109df8c7cc0f8daef8/snowflake.jpg"
                    },
                },
                NotifyUrl = "https://localhost.com"
            };

            var createResponse = await TransloaditClient.Assemblies.CreateAsync(assemblyRequest);
            Assert.Equal("ASSEMBLY_EXECUTING", createResponse.Base.Ok);

            var response = await TransloaditClient.AssemblyNotifications.ReplayAsync(createResponse.AssemblyId);

            Assert.Equal("SERVER_404", response.Base.Error);
            Assert.Equal(404, response.Base.HttpCode);
        }
    }
}