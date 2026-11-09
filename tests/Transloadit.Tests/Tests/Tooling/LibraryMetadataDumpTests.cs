using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transloadit.Models.Credentials;
using Transloadit.Models.Robots;
using Transloadit.Serialization.Attributes;
using Xunit;

namespace Transloadit.Tests.Tests.Tooling;

// opt-in tooling for the transloadit-docs-sync skill: dumps what the library models (robot paths and params, the
// credential type discriminators, every model's JSON fields with the model each field nests) as JSON, so the docs
// can be diffed against it. reflection rather than source parsing, so inherited, explicit-interface and generic
// members count exactly as the serializers see them. runs only when DOCS_SYNC_DUMP is set to an output path.
public class LibraryMetadataDumpTests
{
    private const BindingFlags DeclaredMembers =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

    private static readonly Assembly Library = typeof(TransloaditClient).Assembly;

    [Fact]
    public void DumpLibraryMetadata()
    {
        var output = Environment.GetEnvironmentVariable("DOCS_SYNC_DUMP");
        if (string.IsNullOrWhiteSpace(output))
        {
            return; // disabled — set DOCS_SYNC_DUMP=<path> to run
        }

        var dump = new JObject
        {
            ["schema"] = 1,
            ["robots"] = Robots(),
            ["robot_base_params"] = RobotBaseParams(),
            ["credential_types"] = CredentialTypes(),
            ["types"] = ModelTypes(),
        };

        File.WriteAllText(output, dump.ToString(Formatting.Indented) + "\n");
    }

    private static JObject Robots()
    {
        var robots = new SortedDictionary<string, JObject>(StringComparer.Ordinal);
        foreach (var type in ConcreteSubclassesOf(typeof(RobotBase)))
        {
            var robot = (RobotBase)Activator.CreateInstance(type);
            robots[robot.Robot] = new JObject
            {
                ["class"] = type.Name,
                ["bases"] = new JArray(BaseChain(type).Select(t => t.Name)),
                ["params"] = new JArray(Fields(type).Keys),
            };
        }

        return new JObject(robots.Select(pair => new JProperty(pair.Key, pair.Value)));
    }

    // params each robot base class declares itself, so the diff can tell a base-level gap from a per-robot one
    private static JObject RobotBaseParams()
    {
        var bases = Library.GetTypes()
            .Where(t => t.IsClass && t.IsAbstract && typeof(RobotBase).IsAssignableFrom(t))
            .OrderBy(t => t.Name, StringComparer.Ordinal);

        return new JObject(bases.Select(t => new JProperty(t.Name, new JArray(DeclaredJsonNames(t)))));
    }

    private static JObject CredentialTypes()
    {
        var types = new SortedDictionary<string, string>(StringComparer.Ordinal);
        foreach (var type in ConcreteSubclassesOf(typeof(CredentialsRequestBase)))
        {
            types[((CredentialsRequestBase)Activator.CreateInstance(type)).Type] = type.Name;
        }

        return new JObject(types.Select(pair => new JProperty(pair.Key, pair.Value)));
    }

    // every model with at least one mapped field: field -> the model it nests (null for scalars and untyped values)
    private static JObject ModelTypes()
    {
        var types = Library.GetTypes()
            .Where(t => t.IsClass && t.IsPublic && t.Namespace != null && t.Namespace.StartsWith("Transloadit.Models", StringComparison.Ordinal))
            .Select(t => (Name: t.Name, Fields: Fields(t)))
            .Where(t => t.Fields.Count > 0)
            .OrderBy(t => t.Name, StringComparer.Ordinal);

        return new JObject(types.Select(t => new JProperty(
            t.Name,
            new JObject(t.Fields.Select(field => new JProperty(field.Key, field.Value))))));
    }

    private static SortedDictionary<string, string> Fields(Type type)
    {
        var fields = new SortedDictionary<string, string>(StringComparer.Ordinal);
        for (var current = type; current != null && current != typeof(object); current = current.BaseType)
        {
            foreach (var property in current.GetProperties(DeclaredMembers))
            {
                var name = property.GetCustomAttribute<TransloaditJsonNameAttribute>()?.Name;
                if (name != null && !fields.ContainsKey(name))
                {
                    fields[name] = NestedModel(property.PropertyType);
                }
            }
        }

        return fields;
    }

    private static IEnumerable<string> DeclaredJsonNames(Type type)
        => type.GetProperties(DeclaredMembers)
            .Select(p => p.GetCustomAttribute<TransloaditJsonNameAttribute>()?.Name)
            .Where(name => name != null)
            .OrderBy(name => name, StringComparer.Ordinal);

    // unwraps nullable, arrays, lists and dictionary values down to a library model (or a generic parameter of the
    // declaring type, emitted as $T0..), so the diff can descend into nested response objects
    private static string NestedModel(Type type)
    {
        for (var depth = 0; depth < 8; depth++)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
            if (type.IsArray)
            {
                type = type.GetElementType();
                continue;
            }

            if (type.IsGenericType && type != typeof(string) && typeof(IEnumerable).IsAssignableFrom(type))
            {
                var dictionary = type.GetInterfaces().Concat(new[] { type })
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>));
                type = dictionary != null ? dictionary.GetGenericArguments()[1] : type.GetGenericArguments()[0];
                continue;
            }

            break;
        }

        if (type.IsGenericParameter)
        {
            return "$T" + type.GenericParameterPosition;
        }

        var isModel = type.IsClass && type.Assembly == Library && !type.Name.StartsWith("AnyOf", StringComparison.Ordinal);
        return isModel && HasJsonFields(type) ? type.Name : null;
    }

    // deliberately not Fields(type): models nest themselves (an assembly status carries its parent's status)
    private static bool HasJsonFields(Type type)
    {
        for (var current = type; current != null && current != typeof(object); current = current.BaseType)
        {
            if (DeclaredJsonNames(current).Any())
            {
                return true;
            }
        }

        return false;
    }

    private static IEnumerable<Type> ConcreteSubclassesOf(Type baseType)
        => Library.GetTypes()
            .Where(t => baseType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null)
            .OrderBy(t => t.FullName, StringComparer.Ordinal);

    private static IEnumerable<Type> BaseChain(Type type)
    {
        for (var current = type.BaseType; current != null && current != typeof(object); current = current.BaseType)
        {
            yield return current;
        }
    }
}
