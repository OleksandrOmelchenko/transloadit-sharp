using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Transloadit.Tests.Configuration;
using Xunit;

namespace Transloadit.Tests
{
    public class AssembliesApiTests
    {
        [Fact]
        public async Task GetAssembliesList()
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);
           /* var par = new PaginationParams
            {
                PageSize = 10,
                Page = 0
            };*/
            var templates = await client.Assemblies.GetListAsync();

            // Assert.Equal("BILL_FOUND", billing.Ok);
        }

        [Theory]
        [InlineData("6c5ad8ac73024db381ce8a9f2de3f9e1")]
        [InlineData("06f4a4b760d84e6191d5d1b25b3190e1")]
        public async Task GetAssembly(string id)
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);
            var template = await client.Assemblies.GetAsync(id);

           // Assert.Equal("TEMPLATE_FOUND", template.Ok);
        }

    }
}