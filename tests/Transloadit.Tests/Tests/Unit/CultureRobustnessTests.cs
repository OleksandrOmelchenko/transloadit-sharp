using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Newtonsoft.Json.Linq;
using Transloadit.Models;
using Transloadit.Models.Assemblies;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit;

// exercises the representative serialize/deserialize paths under hostile locales on both engines. tr-TR
// (the Turkish dotless-i) stresses case mapping in name matching; th-TH (Buddhist calendar), ar-SA (Umm
// al-Qura), and fa-IR (non-Latin digits) stress date/number formatting; de-DE uses a decimal comma. test
// parallelization is disabled globally, so swapping the ambient culture is safe when restored in a finally.
public class CultureRobustnessTests
{
    public static IEnumerable<object[]> Cultures() => new[]
    {
        new object[] { "tr-TR" },
        new object[] { "th-TH" },
        new object[] { "ar-SA" },
        new object[] { "fa-IR" },
        new object[] { "de-DE" },
    };

    [Theory]
    [MemberData(nameof(Cultures))]
    public void SerializeAndDeserialize_AreCultureInvariant(string culture)
    {
        RunInCulture(culture, () =>
        {
            // request dates must serialize as invariant Gregorian regardless of the ambient calendar/digits
            var expires = JObject.Parse(TestSerializer.Default.Serialize(
                new AuthParams { Expires = new DateTime(2025, 2, 20, 1, 52, 4, DateTimeKind.Utc) }));
            Assert.Equal("2025/02/20 01:52:04+00:00", (string)expires["expires"]);

            // case-insensitive name matching must not be broken by the Turkish-I
            var envelope = TestSerializer.Default.Deserialize<ResponseBase>("{\"OK\":\"DONE\",\"HTTP_CODE\":200}");
            Assert.Equal("DONE", envelope.Base.Ok);
            Assert.Equal(200, envelope.Base.HttpCode);

            // response date parsing must be invariant
            var assembly = TestSerializer.Default.Deserialize<AssemblyResponse>(
                "{\"ok\":\"ASSEMBLY_COMPLETED\",\"execution_start\":\"2020/01/09 12:02:06 GMT\"}");
            Assert.NotNull(assembly.ExecutionStart);
            Assert.Equal(2020, assembly.ExecutionStart.Value.Year);
            Assert.Equal(TimeSpan.Zero, assembly.ExecutionStart.Value.Offset);
        });
    }

    private static void RunInCulture(string culture, Action action)
    {
        var originalCulture = Thread.CurrentThread.CurrentCulture;
        var originalUiCulture = Thread.CurrentThread.CurrentUICulture;
        try
        {
            var cultureInfo = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            action();
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = originalCulture;
            Thread.CurrentThread.CurrentUICulture = originalUiCulture;
        }
    }
}
