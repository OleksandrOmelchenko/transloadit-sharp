using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Transloadit.Models;
using Transloadit.Serialization.Attributes;
using Xunit;

namespace Transloadit.Tests.Tests.Models;

// every public model property must declare an explicit [TransloaditJsonName] (or be excluded with
// [TransloaditJsonIgnore]). making every name explicit means the two serializer engines — System.Text.Json's
// SnakeCaseLower policy and Newtonsoft's SnakeCaseNamingStrategy — can never diverge on a property name, and a
// newly-added model property can't silently rely on the default naming.
public class ModelPropertyNamingTests
{
    [Fact]
    public void EveryPublicModelProperty_DeclaresJsonNameOrIsIgnored()
    {
        var violations = new List<string>();

        foreach (var type in SerializableModelTypes())
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<TransloaditJsonIgnoreAttribute>() != null)
                {
                    continue;
                }

                if (property.GetCustomAttribute<TransloaditJsonNameAttribute>() == null)
                {
                    violations.Add($"{type.FullName}.{property.Name}");
                }
            }
        }

        Assert.True(
            violations.Count == 0,
            "these public model properties must be marked with [TransloaditJsonName] (or [TransloaditJsonIgnore]):" +
            Environment.NewLine + string.Join(Environment.NewLine, violations));
    }

    private static IEnumerable<Type> SerializableModelTypes()
    {
        return typeof(TransloaditClient).Assembly
            .GetTypes()
            .Where(type => type.IsClass
                && type.IsVisible
                && !type.IsGenericTypeDefinition
                && (type.Namespace == "Transloadit.Models" || (type.Namespace?.StartsWith("Transloadit.Models.", StringComparison.Ordinal) ?? false))
                // AnyOf<> is serialized by a dedicated converter, not property-by-property
                && !typeof(AnyOf).IsAssignableFrom(type)
                // TransloaditResponse is the raw HTTP wrapper; it is attached via an ignored property and never serialized
                && type != typeof(TransloaditResponse));
    }
}
