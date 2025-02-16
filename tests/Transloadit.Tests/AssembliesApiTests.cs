using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Xunit;

namespace Transloadit.Tests
{
    public class AssembliesApiTests : TestBase
    {
        [Fact]
        public async Task CreateAssembly()
        {
            var createAssembly = new AssemblyRequest
            {
                TemplateId = "6d4a87848f8b4360880b77fea526289d",
                Quiet = true,
            };

            var response = await TransloaditClient.Assemblies.CreateAsync(createAssembly);

            Assert.Equal("ASSEMBLY_EXECUTING", response.Base.Ok);
        }

        [Fact]
        public async Task CreateAssemblyWithSteps()
        {
            var imageResizeRobot = new TestImageResizeRobot
            {
                Use = ":original",
                Result = true,
                Width = 130,
                Height = 130
            };

            var createAssembly = new AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase>
                {
                    ["resize"] = imageResizeRobot
                }
            };

            var file = new ByteArrayContent(File.ReadAllBytes(@"TestData/snowflake.jpg"));
            var file1 = new ByteArrayContent(File.ReadAllBytes(@"TestData/flower-field.jpg"));
            var file2 = new ByteArrayContent(File.ReadAllBytes(@"TestData/flowers.jpg"));
            var formData = new MultipartFormDataContent
            {
                { file, "file-first", "snowflake.jpg" },
                { file1, "file-second", "flower-field.jpg" },
                { file2, "file-third", "flowers.jpg" },
            };

            var response = await TransloaditClient.Assemblies.CreateAsync(createAssembly, formData);

            Assert.Equal("ASSEMBLY_EXECUTING", response.Base.Ok);
            Assert.Equal(3, response.NumInputFiles);
            Assert.Equal(3, response.Uploads.Count);
        }


        [Fact]
        public async Task GetAssembliesList()
        {
            const int assemblyCount = 10;

            var listRequest = new AssemblyListRequest
            {
                PageSize = assemblyCount,
            };
            var assemblies = await TransloaditClient.Assemblies.GetListAsync(listRequest);

            Assert.Equal(assemblyCount, assemblies.Items.Count);
            Assert.True(assemblyCount < assemblies.Count);
        }
    }
}