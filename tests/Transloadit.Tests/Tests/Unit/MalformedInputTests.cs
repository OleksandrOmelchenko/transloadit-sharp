using System;
using System.Linq;
using Transloadit.Models.Assemblies;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit;

// deserializing a malformed body must fail predictably on both engines — a thrown exception, never a hang, a
// stack overflow, or a silently half-populated object. the client's empty-body handling is covered separately;
// this pins the behavior for genuinely-broken payloads.
public class MalformedInputTests
{
    [Theory]
    [InlineData("{")]                                  // truncated object
    [InlineData("{\"ok\":")]                           // truncated mid-value
    [InlineData("[1, 2, 3]")]                          // array where an object is expected
    [InlineData("not json at all")]                   // plain garbage
    [InlineData("@#$%^")]                              // non-json symbols
    [InlineData("{\"num_input_files\": \"not-a-number\"}")] // wrong scalar type for an int
    public void Deserialize_MalformedBody_Throws(string body)
    {
        Assert.ThrowsAny<Exception>(() => TestSerializer.Default.Deserialize<AssemblyResponse>(body));
    }

    [Fact]
    public void Deserialize_DeeplyNestedBody_ThrowsInsteadOfCrashing()
    {
        // both engines cap nesting depth; the payload must be rejected, not overflow the stack
        const int depth = 5000;
        var deeplyNested = string.Concat(Enumerable.Repeat("{\"meta\":", depth)) + "1" + new string('}', depth);

        Assert.ThrowsAny<Exception>(() => TestSerializer.Default.Deserialize<AssemblyResponse>(deeplyNested));
    }
}
