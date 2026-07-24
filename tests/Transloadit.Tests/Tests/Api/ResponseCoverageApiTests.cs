using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Transloadit;
using Transloadit.Models.Billing;
using Transloadit.Models.Queues;
using Transloadit.Tests.Infrastructure;
using Xunit;
using Xunit.Abstractions;

namespace Transloadit.Tests.Tests.Api.Coverage
{
    // permanent regression guards that the response models keep mapping every key the live API returns. reuses the
    // ResponseCoverage bug-finder against real bodies captured with CapturingHandler; a newly-added API field (or a
    // dropped mapping) makes the model's unmapped set grow beyond the reviewed allowlist and fails the test.
    public class ResponseCoverageApiTests : TestBase
    {
        private readonly ITestOutputHelper _output;

        public ResponseCoverageApiTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private TransloaditClient CapturingClient(CapturingHandler handler)
            => new TransloaditClient(
                Configuration.AuthKey,
                Configuration.AuthSecret,
                new TransloaditClientOptions { HttpClient = new HttpClient(handler) });

        private void AssertMapped(string label, string body, System.Type model, params string[] allowlist)
        {
            var unmapped = ResponseCoverage.UnmappedTopLevelKeys(body, model);
            _output.WriteLine($"{label} [{model.Name}] unmapped: {string.Join(", ", unmapped)}");
            var allowed = new HashSet<string>(allowlist);
            var unexpected = unmapped.Where(k => !allowed.Contains(k)).ToList();
            Assert.True(unexpected.Count == 0, $"{model.Name} silently drops API keys: {string.Join(", ", unexpected)}");
        }

        [Fact]
        public async Task BillingResponse_MapsAllReturnedKeys()
        {
            var handler = new CapturingHandler();
            await CapturingClient(handler).Billing.GetAsync(2025, 2);
            var body = handler.LastResponseBody;

            AssertMapped("billing", body, typeof(BillingResponse));

            var billing = JObject.Parse(body);
            if (billing["plan"] is JObject plan)
            {
                AssertMapped("billing.plan", plan.ToString(), typeof(BillingPlan));
            }

            if (billing["robots"] is JObject robots && robots.Properties().Any())
            {
                AssertMapped("billing.robots[*]", robots.Properties().First().Value.ToString(), typeof(RobotBilling));
            }
        }

        [Fact]
        public async Task QueueResponse_MapsAllReturnedKeys()
        {
            var handler = new CapturingHandler();
            await CapturingClient(handler).Queues.GetJobSlotsAsync();
            AssertMapped("queues", handler.LastResponseBody, typeof(QueueResponse));
        }
    }
}
