using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Transloadit.Models.Assemblies;
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
                TemplateId = "6d4a87848f8b4360880b77fea526289d"
            };

            var response = await TransloaditClient.Assemblies.CreateAsync(createAssembly);

            Assert.Equal("ASSEMBLY_EXECUTING", response.Base.Ok);
        }

        [Fact]
        public async Task CreateAssembly2()
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
        public async Task CreateAssembly3()
        {
            var createAssembly = new AssemblyRequest
            {
                TemplateId = "13b80ca8f14140d6b1c9bd6a41d61f42",
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

        [Theory]
        [InlineData("6c5ad8ac73024db381ce8a9f2de3f9e1")]
        [InlineData("06f4a4b760d84e6191d5d1b25b3190e1")]
        [InlineData("b4e2544a8346437ebc7bc0e86b67d1e1")]
        public async Task GetAssembly(string id)
        {
            var assembly = await TransloaditClient.Assemblies.GetAsync(id);

            // Assert.Equal("TEMPLATE_FOUND", template.Ok);
        }

    }
}