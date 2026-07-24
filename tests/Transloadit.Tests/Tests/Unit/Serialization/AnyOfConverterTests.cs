#if TRANSLOADIT_NEWTONSOFT
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Transloadit.Models;
using Transloadit.Serialization;
using Xunit;

namespace Transloadit.Tests.Tests.Unit.Serialization;

public class AnyOfConverterTests
{
    [Fact]
    public void WriteJson_FirstType_SerializesInnerValue()
    {
        AnyOf<string, List<string>> anyOf = "hello";
        var json = JsonConvert.SerializeObject(anyOf, new AnyOfConverter());
        Assert.Equal("\"hello\"", json);
    }

    [Fact]
    public void WriteJson_SecondType_SerializesInnerValue()
    {
        AnyOf<string, List<string>> anyOf = new List<string> { "a", "b" };
        var json = JsonConvert.SerializeObject(anyOf, new AnyOfConverter());
        Assert.Equal("[\"a\",\"b\"]", json);
    }

    [Fact]
    public void WriteJson_Null_WritesNull()
    {
        var converter = new AnyOfConverter();
        using var writer = new StringWriter();
        using (var jsonWriter = new JsonTextWriter(writer))
        {
            converter.WriteJson(jsonWriter, null, JsonSerializer.CreateDefault());
        }

        Assert.Equal("null", writer.ToString());
    }

    [Fact]
    public void WriteJson_NonAnyOfValue_Throws()
    {
        var converter = new AnyOfConverter();
        using var writer = new StringWriter();
        using var jsonWriter = new JsonTextWriter(writer);

        Assert.Throws<JsonSerializationException>(
            () => converter.WriteJson(jsonWriter, "not an AnyOf", JsonSerializer.CreateDefault()));
    }

    [Fact]
    public void CanConvert_AnyOfTypes_ReturnsTrue()
    {
        var converter = new AnyOfConverter();
        Assert.True(converter.CanConvert(typeof(AnyOf<string, List<string>>)));
        Assert.False(converter.CanConvert(typeof(string)));
    }

    [Fact]
    public void ReadJson_IsNotSupported()
    {
        var converter = new AnyOfConverter();
        Assert.Throws<NotSupportedException>(
            () => converter.ReadJson(null, typeof(AnyOf<string, List<string>>), null, JsonSerializer.CreateDefault()));
    }
}
#endif
