#if TRANSLOADIT_NEWTONSOFT
using System.IO;
using Newtonsoft.Json;
using Transloadit.Serialization;
using Xunit;

namespace Transloadit.Tests.Tests.Unit.Serialization;

public class BooleanToIntConverterTests
{
    [Theory]
    [InlineData(true, "1")]
    [InlineData(false, "0")]
    public void WriteJson_WritesIntForBool(bool value, string expected)
    {
        var converter = new BooleanToIntConverter();
        using var writer = new StringWriter();
        using (var jsonWriter = new JsonTextWriter(writer))
        {
            converter.WriteJson(jsonWriter, value, JsonSerializer.CreateDefault());
        }

        Assert.Equal(expected, writer.ToString());
    }

    [Theory]
    [InlineData("0", false)]
    [InlineData("1", true)]
    [InlineData("5", true)]
    public void ReadJson_ConvertsIntToBool(string raw, bool expected)
    {
        var converter = new BooleanToIntConverter();
        using var reader = new JsonTextReader(new StringReader(raw));
        reader.Read();

        var result = converter.ReadJson(reader, typeof(bool), null, JsonSerializer.CreateDefault());

        Assert.Equal(expected, (bool)result);
    }

    [Fact]
    public void CanConvert_OnlyBool()
    {
        var converter = new BooleanToIntConverter();
        Assert.True(converter.CanConvert(typeof(bool)));
        Assert.False(converter.CanConvert(typeof(int)));
    }
}
#endif
