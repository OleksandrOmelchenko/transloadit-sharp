using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transloadit.Models;
using Transloadit.Models.Robots;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Models;

// scaled cross-provider golden: every concrete robot is filled with deterministic values by reflection, serialized
// through the active engine, and compared structurally (JToken.DeepEquals) to a committed golden. regenerate on
// net8/System.Text.Json via UPDATE_ROBOT_GOLDEN=1; the net461/Newtonsoft leg then validates that the two engines
// agree on the full serialized value of every robot — not just the discriminator key the smoke test checks.
//
// non-integral numbers are used on purpose: an integral double/decimal renders as "2" (STJ) vs "2.0" (Newtonsoft),
// which is the one known cross-engine formatting difference and would otherwise produce false divergence.
public class AutoPopulatedRobotGoldenTests
{
    private static readonly DateTime FixedDate = new DateTime(2025, 2, 20, 1, 52, 4, DateTimeKind.Utc);

    public static IEnumerable<object[]> RobotTypeNames()
        => typeof(TransloaditClient).Assembly
            .GetTypes()
            .Where(type => typeof(RobotBase).IsAssignableFrom(type) && !type.IsAbstract && type.GetConstructor(Type.EmptyTypes) != null)
            .OrderBy(type => type.FullName, StringComparer.Ordinal)
            .Select(type => new object[] { type.FullName });

    [Theory]
    [MemberData(nameof(RobotTypeNames))]
    public void PopulatedRobot_MatchesCrossProviderGolden(string typeName)
    {
        var type = typeof(TransloaditClient).Assembly.GetType(typeName, throwOnError: true);
        var robot = (RobotBase)Activator.CreateInstance(type);
        Populate(robot, depth: 0);

        var actual = JToken.Parse(TestSerializer.Default.Serialize(robot));
        var path = GoldenPath();

        if (Environment.GetEnvironmentVariable("UPDATE_ROBOT_GOLDEN") == "1")
        {
            var store = File.Exists(path) ? JObject.Parse(File.ReadAllText(path)) : new JObject();
            store[typeName] = actual;
            File.WriteAllText(path, store.ToString(Formatting.Indented).Replace("\r\n", "\n") + "\n");
            return;
        }

        Assert.True(File.Exists(path), $"robot golden missing: {path} (regenerate with UPDATE_ROBOT_GOLDEN=1)");
        var golden = JObject.Parse(File.ReadAllText(path));
        Assert.True(golden.TryGetValue(typeName, out var expected), $"robot golden has no case '{typeName}' (regenerate with UPDATE_ROBOT_GOLDEN=1)");
        Assert.True(
            JToken.DeepEquals(expected, actual),
            $"{type.Name} diverged from golden.{Environment.NewLine}expected: {expected}{Environment.NewLine}actual:   {actual}");
    }

    private static void Populate(object target, int depth)
    {
        foreach (var property in target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            // only public setters — this skips RobotBase.Robot (protected set), whose ctor value must be preserved
            if (property.GetSetMethod() == null)
            {
                continue;
            }

            try
            {
                var value = MakeValue(property.PropertyType, depth);
                if (value != null)
                {
                    property.SetValue(target, value);
                }
            }
            catch
            {
                // skip anything that can't be populated deterministically
            }
        }
    }

    private static object MakeValue(Type declaredType, int depth)
    {
        var type = Nullable.GetUnderlyingType(declaredType) ?? declaredType;

        if (type == typeof(string) || type == typeof(object))
        {
            return "s";
        }

        if (type == typeof(bool))
        {
            return true;
        }

        if (type == typeof(int))
        {
            return 7;
        }

        if (type == typeof(long))
        {
            return 7L;
        }

        if (type == typeof(double))
        {
            return 1.5d;
        }

        if (type == typeof(decimal))
        {
            return 1.5m;
        }

        if (type == typeof(float))
        {
            return 1.5f;
        }

        if (type == typeof(DateTime))
        {
            return FixedDate;
        }

        if (type == typeof(DateTimeOffset))
        {
            return new DateTimeOffset(FixedDate);
        }

        if (type.IsEnum)
        {
            return Enum.GetValues(type).GetValue(0);
        }

        if (depth >= 2)
        {
            return null;
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
        {
            var element = MakeValue(type.GetGenericArguments()[0], depth + 1);
            var list = (IList)Activator.CreateInstance(type);
            if (element != null)
            {
                list.Add(element);
            }

            return list;
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            var arguments = type.GetGenericArguments();
            var key = arguments[0] == typeof(string) ? "k" : MakeValue(arguments[0], depth + 1);
            var value = MakeValue(arguments[1], depth + 1);
            var dictionary = (IDictionary)Activator.CreateInstance(type);
            if (key != null && value != null)
            {
                dictionary[key] = value;
            }

            return dictionary;
        }

        // AnyOf<...>: build the first arm
        if (typeof(AnyOf).IsAssignableFrom(type))
        {
            var arm = MakeValue(type.GetGenericArguments()[0], depth + 1);
            return arm == null ? null : Activator.CreateInstance(type, new[] { arm });
        }

        // nested model with a parameterless constructor
        if (type.IsClass && type.GetConstructor(Type.EmptyTypes) != null)
        {
            var nested = Activator.CreateInstance(type);
            Populate(nested, depth + 1);
            return nested;
        }

        return null;
    }

    private static string GoldenPath([CallerFilePath] string thisFile = null)
    {
        var testsRoot = Directory.GetParent(thisFile).Parent.Parent.FullName;
        return Path.Combine(testsRoot, "Snapshots", "robots.golden.json");
    }
}
