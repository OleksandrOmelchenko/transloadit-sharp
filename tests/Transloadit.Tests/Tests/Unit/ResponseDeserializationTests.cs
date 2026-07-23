using Transloadit.Models.Assemblies;
using Transloadit.Models.Billing;
using Transloadit.Models.Tokens;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit
{
    // offline deserialization of the response models from canned JSON, via the active serializer
    // (System.Text.Json on net6+, Newtonsoft on net461). Covers the explicit-interface envelope fields
    // (ok/http_code), nested collections, and the billing camelCase / address_1 override names.
    public class ResponseDeserializationTests
    {
        [Fact]
        public void AssemblyResponse_Deserializes_EnvelopeAndNestedResults()
        {
            const string json =
                "{\"ok\":\"ASSEMBLY_COMPLETED\",\"http_code\":200,\"assembly_id\":\"abc\",\"num_input_files\":2," +
                "\"template_id\":\"t1\",\"results\":{\"resized\":[{\"id\":\"f1\"},{\"id\":\"f2\"}]}}";

            var response = TestSerializer.Default.Deserialize<AssemblyResponse>(json);

            Assert.True(response.IsSuccessResponse());
            Assert.Equal("ASSEMBLY_COMPLETED", response.Base.Ok);
            Assert.Equal(200, response.Base.HttpCode);
            Assert.Equal("abc", response.AssemblyId);
            Assert.Equal(2, response.NumInputFiles);
            Assert.Equal("t1", response.TemplateId);
            Assert.Equal(2, response.Results["resized"].Count);
        }

        [Fact]
        public void BillingResponse_Deserializes_CamelCaseAndOverrideNames()
        {
            const string json =
                "{\"ok\":\"BILL_FOUND\",\"invoice_id\":\"inv-1\",\"address_1\":\"line 1\",\"address_2\":\"line 2\"," +
                "\"robots\":{\"/image/resize\":{\"rawGb\":1.5,\"gbFactorApplied\":2,\"freeGb\":0.25}}}";

            var response = TestSerializer.Default.Deserialize<BillingResponse>(json);

            Assert.Equal("inv-1", response.InvoiceId);
            Assert.Equal("line 1", response.Address1);
            Assert.Equal("line 2", response.Address2);

            var robot = response.Robots["/image/resize"];
            Assert.Equal(1.5m, robot.RawGb);
            Assert.Equal(2m, robot.GbFactorApplied);
            Assert.Equal(0.25m, robot.FreeGb);
        }

        [Fact]
        public void TokenResponse_Deserializes()
        {
            const string json =
                "{\"access_token\":\"tok\",\"token_type\":\"Bearer\",\"expires_in\":3600,\"scope\":\"s\"}";

            var response = TestSerializer.Default.Deserialize<TokenResponse>(json);

            Assert.Equal("tok", response.AccessToken);
            Assert.Equal("Bearer", response.TokenType);
            Assert.Equal(3600, response.ExpiresIn);
            Assert.Equal("s", response.Scope);
        }
    }
}
