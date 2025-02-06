using System.Threading.Tasks;
using Transloadit.Models;
using Transloadit.Tests.Configuration;
using Xunit;

namespace Transloadit.Tests
{
    public class TemplatesApiTests : TestBase
    {
        [Fact]
        public async Task GetTemplatesList()
        {
            var par = new PaginationParams
            {
                PageSize = 10,
                Page = 1,
                Order = "asc",
                Sort = "created"
            };
            var templates = await TransloaditClient.Templates.GetListAsync(par);

            // Assert.Equal("BILL_FOUND", billing.Ok);
        }

        [Theory]
        [InlineData("047e1008c1ec4ea3a719d57f3648eff8")]
        public async Task GetTemplate(string templateId)
        {
            var template = await TransloaditClient.Templates.GetAsync(templateId);
            Assert.Equal("TEMPLATE_FOUND", template.Base.Ok);
        }

    }
}