using Newtonsoft.Json.Linq;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Billing;
using Transloadit.Models.Templates;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit;

// response models must round-trip through the active serializer: deserialize -> serialize -> deserialize ->
// serialize should reach a fixed point. this catches asymmetric read/write mapping — a field that deserializes
// from one key but serializes to another, or a converter whose write format its own read can't parse back — which
// the separate read (deserialization) and write (wire-format) tests can't detect on their own. the override-heavy
// billing model (address_1, camelCase rawGb) and the date/bool-int converters are the main risk.
public class RoundTripStabilityTests
{
    private static void AssertStableRoundTrip<T>(string json)
    {
        var first = TestSerializer.Default.Deserialize<T>(json);
        var firstSerialized = TestSerializer.Default.Serialize(first);

        var second = TestSerializer.Default.Deserialize<T>(firstSerialized);
        var secondSerialized = TestSerializer.Default.Serialize(second);

        Assert.True(
            JToken.DeepEquals(JToken.Parse(firstSerialized), JToken.Parse(secondSerialized)),
            $"round-trip diverged:{System.Environment.NewLine}1st: {firstSerialized}{System.Environment.NewLine}2nd: {secondSerialized}");
    }

    [Fact]
    public void BillingResponse_RoundTripsStably()
    {
        const string json =
            "{\"ok\":\"BILL_FOUND\",\"invoice_id\":\"inv-1\",\"address_1\":\"line 1\",\"address_2\":\"line 2\"," +
            "\"created\":\"2025/02/20 01:52:04 GMT\"," +
            "\"robots\":{\"/image/resize\":{\"rawGb\":1.5,\"gbFactorApplied\":2,\"freeGb\":0.25}}}";

        AssertStableRoundTrip<BillingResponse>(json);
    }

    [Fact]
    public void AssemblyResponse_RoundTripsStably()
    {
        const string json =
            "{\"ok\":\"ASSEMBLY_COMPLETED\",\"assembly_id\":\"abc\",\"num_input_files\":2," +
            "\"execution_start\":\"2020/01/09 12:02:06 GMT\",\"execution_duration\":1.5," +
            "\"notify_url\":\"https://hook.test\",\"notify_response_code\":200," +
            "\"uploads\":[{\"size\":3221225472}]}";

        AssertStableRoundTrip<AssemblyResponse>(json);
    }

    [Fact]
    public void TemplateResponse_RoundTripsStably()
    {
        const string json =
            "{\"ok\":\"TEMPLATE_FOUND\",\"id\":\"t1\",\"name\":\"my-template\",\"require_signature_auth\":1}";

        AssertStableRoundTrip<TemplateResponse>(json);
    }
}
