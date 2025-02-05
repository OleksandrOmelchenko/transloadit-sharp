using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Transloadit.Tests.Configuration;
using Xunit;

namespace Transloadit.Tests
{
    public class TemplatesApiTests
    {
        [Fact]
        public async Task GetTemplatesList()
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);
            var par = new PaginationParams
            {
                PageSize = 10,
                Page = 1
            };
            var templates = await client.Templates.GetListAsync();

            // Assert.Equal("BILL_FOUND", billing.Ok);
        }

        [Theory]
        [InlineData("047e1008c1ec4ea3a719d57f3648eff8")]
        public async Task GetTemplate(string templateId)
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);
            var template = await client.Templates.GetAsync(templateId);
            Assert.Equal("TEMPLATE_FOUND", template.Base.Ok);
        }

    }
}