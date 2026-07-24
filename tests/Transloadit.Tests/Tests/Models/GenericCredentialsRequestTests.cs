using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transloadit.Models.Credentials;
using Transloadit.Serialization;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Models;

// GenericCredentialsRequest has no parameterless ctor, so the reflection smoke
// test skips it; cover it explicitly here.
public class GenericCredentialsRequestTests
{
    [Fact]
    public void Serializes_TypeNameAndContent()
    {
        var credentials = new GenericCredentialsRequest("mytype")
        {
            Name = "cred-name",
            Content = new Dictionary<string, string> { ["key"] = "value" },
        };

        var json = TestSerializer.Default.Serialize(credentials);
        var parsed = JObject.Parse(json);

        Assert.Equal("mytype", (string)parsed["type"]);
        Assert.Equal("cred-name", (string)parsed["name"]);
        Assert.Equal("value", (string)parsed["content"]["key"]);
    }
}
