using System;
using System.IO;
using System.Runtime.CompilerServices;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Serialization;
using Transloadit.Tests.Infrastructure;
using Transloadit.Utilities;
using Xunit;

namespace Transloadit.Tests.Tests.Unit;

// pins the receiving side of an Assembly notification. Transloadit POSTs multipart form data to the notify_url with
// a `transloadit` field (the Assembly Status JSON) and a `signature` field (HMAC of that exact string, keyed with
// the auth secret). a receiver must verify the signature and then deserialize the payload, so these tests cover
// that flow with the same primitives the library exposes.
public class NotificationHandlingTests
{
    private const string Secret = "my-auth-secret";

    // a realistic status payload: non-ISO date, a >2 GB result file, nested results
    private const string Payload =
        "{\"ok\":\"ASSEMBLY_COMPLETED\",\"assembly_id\":\"abc\"," +
        "\"execution_start\":\"2020/01/09 12:02:06 GMT\",\"execution_duration\":1.5," +
        "\"results\":{\"resize\":[{\"id\":\"f1\",\"size\":3221225472}]}}";

    [Theory]
    [InlineData(SignatureAlgorithm.Sha384)]
    [InlineData(SignatureAlgorithm.Sha256)]
    [InlineData(SignatureAlgorithm.Sha1)] // legacy: emitted without an "algo:" prefix
    public void Notification_SignatureValidates_ForEveryAlgorithm(SignatureAlgorithm algorithm)
    {
        var signature = SignatureUtilities.CalculateSignature(Payload, Secret, algorithm);

        Assert.True(SignatureUtilities.ValidateSignature(Payload, Secret, signature));
    }

    [Fact]
    public void Notification_TamperedPayload_IsRejected()
    {
        var signature = SignatureUtilities.CalculateSignature(Payload, Secret);

        // a single trailing space is enough to invalidate the payload
        Assert.False(SignatureUtilities.ValidateSignature(Payload + " ", Secret, signature));
    }

    [Fact]
    public void Notification_WrongSecret_IsRejected()
    {
        var signature = SignatureUtilities.CalculateSignature(Payload, Secret);

        Assert.False(SignatureUtilities.ValidateSignature(Payload, "not-the-secret", signature));
    }

    [Fact]
    public void Notification_PayloadDeserializesIntoAssemblyResponse()
    {
        var assembly = TestSerializer.Default.Deserialize<AssemblyResponse>(Payload);

        Assert.True(assembly.IsSuccessResponse());
        Assert.Equal("abc", assembly.AssemblyId);
        Assert.Equal(1.5d, assembly.ExecutionDuration);

        // the notification carries the API's non-ISO date format and file sizes beyond int range
        Assert.NotNull(assembly.ExecutionStart);
        Assert.Equal(2020, assembly.ExecutionStart.Value.Year);
        Assert.Equal(TimeSpan.Zero, assembly.ExecutionStart.Value.Offset);
        Assert.Equal(3221225472L, assembly.Results["resize"][0].Size);
    }

    [Fact]
    public void Client_ExposesSignatureService_WhichVerifiesNotifications()
    {
        var client = TestClientFactory.Create(FakeHttpMessageHandler.Json("{}"));
        var signature = SignatureUtilities.CalculateSignature(Payload, TestClientFactory.Secret);

        // the service closes over the client's secret, so a receiver does not pass it around
        Assert.True(client.Signature.ValidateSignature(Payload, signature));
        Assert.False(client.Signature.ValidateSignature(Payload + " ", signature));
    }

    [Fact]
    public void Client_ExposesSmartCdnService()
    {
        var client = TestClientFactory.Create(FakeHttpMessageHandler.Json("{}"));

        var url = client.SmartCdn.GetSignedSmartCdnUrl("ws", "tpl", "input", DateTimeOffset.FromUnixTimeMilliseconds(1700000000000));

        Assert.StartsWith("https://ws.tlcdn.com/tpl/input?", url);
        Assert.Contains("&sig=sha256:", url);
    }

    [Fact]
    public void Client_WithoutSecret_ThrowsForSecretRequiringServices()
    {
        var client = TestClientFactory.Create(FakeHttpMessageHandler.Json("{}"), withSecret: false);

        // signing and verifying are impossible without a secret; fail loudly instead of producing bogus signatures
        Assert.Throws<InvalidOperationException>(() => client.Signature);
        Assert.Throws<InvalidOperationException>(() => client.SmartCdn);
    }

    [Fact]
    public void RecordedNotification_ParsesAndMapsEveryReturnedKey()
    {
        // a real notification body captured from the API (identifiers sanitized). guards against the model drifting
        // from what Transloadit actually posts — this payload is what revealed notify_status and import_url were
        // being silently dropped.
        var json = File.ReadAllText(FixturePath());

        var assembly = TestSerializer.Default.Deserialize<AssemblyResponse>(json);

        Assert.True(assembly.IsSuccessResponse());
        Assert.Equal("processing", assembly.NotifyStatus);
        Assert.NotNull(assembly.NotifyStart);
        Assert.Equal(1, assembly.NumInputFiles);

        var file = assembly.Results["import"][0];
        Assert.Equal("snowflake.jpg", file.Name);
        Assert.Equal(133788L, file.Size);
        Assert.StartsWith("https://demos.transloadit.com/", file.ImportUrl);
        // meta is untyped, so exotic keys survive without a model change
        Assert.Equal(1152L, file.Meta["width"]);

        var unmapped = ResponseCoverage.UnmappedTopLevelKeys(json, typeof(AssemblyResponse));
        Assert.True(unmapped.Count == 0, "AssemblyResponse drops keys a real notification contains: " + string.Join(", ", unmapped));
    }

    private static string FixturePath([CallerFilePath] string thisFile = null)
    {
        // <tests>/Tests/Unit/NotificationHandlingTests.cs -> <tests>/Fixtures/...
        var testsRoot = Directory.GetParent(thisFile).Parent.Parent.FullName;
        return Path.Combine(testsRoot, "Fixtures", "notification-assembly-completed.json");
    }

    [Fact]
    public void Notification_VerifyThenParse_EndToEnd()
    {
        // what a webhook endpoint does: read both form fields, verify, then deserialize
        var signature = SignatureUtilities.CalculateSignature(Payload, Secret);

        Assert.True(SignatureUtilities.ValidateSignature(Payload, Secret, signature));

        var assembly = TransloaditSerializerFactory.CreateDefault().Deserialize<AssemblyResponse>(Payload);

        Assert.Equal(ResponseCodes.AssemblyCompleted, assembly.Base.Ok);
    }
}
