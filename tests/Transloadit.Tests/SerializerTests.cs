using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using Transloadit.Models.Billing;
using Xunit;

namespace Transloadit.Tests
{
    public class SerializerTests
    {
        [Fact]
        public void TestDeserialize() {

            var json = File.ReadAllText(@"billing.json");

            var settings = new JsonSerializerSettings
            {
               // NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
            var r = JsonConvert.DeserializeObject<BillingResponse>(json, settings);
        }

    }
}
