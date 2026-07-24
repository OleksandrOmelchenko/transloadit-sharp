using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Transloadit.Tests.Tests.Constants;

// reflection-driven coverage over the public constant classes: every string
// constant must be non-empty. cheaply guards against blank/placeholder values.
public class ConstantsTests
{
    public static IEnumerable<object[]> ConstantClassNames()
    {
        return typeof(TransloaditClient).Assembly
            .GetTypes()
            .Where(t => t.Namespace == "Transloadit.Constants"
                && t.IsPublic
                && t.IsAbstract
                && t.IsSealed) // static class
            .Select(t => new object[] { t.FullName });
    }

    [Theory]
    [MemberData(nameof(ConstantClassNames))]
    public void StringConstants_AreNonEmpty(string typeName)
    {
        var type = typeof(TransloaditClient).Assembly.GetType(typeName, throwOnError: true);

        var stringConstants = type
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string));

        foreach (var field in stringConstants)
        {
            var value = (string)field.GetRawConstantValue();
            Assert.False(string.IsNullOrEmpty(value), $"{typeName}.{field.Name} must be non-empty");
        }
    }

    [Fact]
    public void Discovers_ConstantClasses()
    {
        Assert.NotEmpty(ConstantClassNames());
    }
}
