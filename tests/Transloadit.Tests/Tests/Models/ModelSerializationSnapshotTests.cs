using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Transloadit.Models;
using Transloadit.Serialization.Attributes;
using Xunit;

namespace Transloadit.Tests.Tests.Models
{
    // characterization (golden-snapshot) test that pins the serialization contract shape of
    // every class under Models to a committed file. the shape is derived from the provider-neutral
    // Transloadit serialization attributes (not a specific JSON engine), so it is stable across
    // System.Text.Json and Newtonsoft. any change that alters how a class serializes (renamed/added/
    // removed property, changed type, added/removed converter) fails until regenerated with UPDATE_SNAPSHOTS=1.
    public class ModelSerializationSnapshotTests
    {
        [Fact]
        public void ModelsSerializationContract_MatchesSnapshot()
        {
            var snapshot = BuildSnapshot(out var typeCount);

            // guard so a broken discovery can't silently blank the snapshot in update mode
            Assert.True(typeCount > 120, $"expected many model types, discovered {typeCount}");

            var path = SnapshotPath();

            if (Environment.GetEnvironmentVariable("UPDATE_SNAPSHOTS") == "1")
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, snapshot);
                return;
            }

            Assert.True(File.Exists(path),
                $"snapshot file not found at {path}. regenerate it with UPDATE_SNAPSHOTS=1.");

            var expected = Normalize(File.ReadAllText(path));
            var actual = Normalize(snapshot);
            Assert.Equal(expected, actual);
        }

        private static string BuildSnapshot(out int typeCount)
        {
            var types = typeof(TransloaditClient).Assembly
                .GetTypes()
                .Where(IsSnapshotType)
                .OrderBy(t => t.FullName, StringComparer.Ordinal)
                .ToList();

            typeCount = types.Count;

            var models = new List<ModelContract>();
            foreach (var type in types)
            {
                var properties = new List<PropertyContract>();
                var seen = new HashSet<string>();

                for (var current = type; current != null && current != typeof(object); current = current.BaseType)
                {
                    foreach (var property in current.GetProperties(
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
                    {
                        if (property.GetIndexParameters().Length > 0 || property.GetMethod == null)
                        {
                            continue;
                        }

                        if (property.GetCustomAttribute<TransloaditJsonIgnoreAttribute>() != null)
                        {
                            continue;
                        }

                        var nameAttribute = property.GetCustomAttribute<TransloaditJsonNameAttribute>();

                        // public members are always serialized; non-public members only when they carry a neutral name
                        if (!property.GetMethod.IsPublic && nameAttribute == null)
                        {
                            continue;
                        }

                        if (!seen.Add(property.DeclaringType.FullName + "." + property.Name))
                        {
                            continue;
                        }

                        properties.Add(new PropertyContract
                        {
                            Name = nameAttribute != null ? nameAttribute.Name : ToSnakeCase(property.Name),
                            Type = FriendlyTypeName(property.PropertyType),
                            Converter = NeutralConverter(property),
                        });
                    }
                }

                models.Add(new ModelContract
                {
                    Type = type.FullName,
                    Properties = properties.OrderBy(p => p.Name, StringComparer.Ordinal).ToList(),
                });
            }

            var snapshotSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(models, Formatting.Indented, snapshotSettings);
        }

        private static bool IsSnapshotType(Type type)
        {
            return type.IsClass
                && !type.IsGenericTypeDefinition
                && (type.Namespace == "Transloadit.Models"
                    || (type.Namespace != null && type.Namespace.StartsWith("Transloadit.Models.")))
                && !typeof(AnyOf).IsAssignableFrom(type)
                && !type.Name.Contains("<");
        }

        private static string NeutralConverter(PropertyInfo property)
        {
            if (property.GetCustomAttribute<TransloaditBooleanToIntAttribute>() != null)
            {
                return "BooleanToInt";
            }

            if (property.GetCustomAttribute<TransloaditDateFormatAttribute>() != null)
            {
                return "DateFormat";
            }

            if (typeof(AnyOf).IsAssignableFrom(property.PropertyType))
            {
                return "AnyOf";
            }

            return null;
        }

        private static string ToSnakeCase(string name)
        {
            var builder = new System.Text.StringBuilder();
            for (var i = 0; i < name.Length; i++)
            {
                var c = name[i];
                if (char.IsUpper(c))
                {
                    if (i > 0)
                    {
                        builder.Append('_');
                    }

                    builder.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }

        private static string FriendlyTypeName(Type type)
        {
            var underlying = Nullable.GetUnderlyingType(type);
            if (underlying != null)
            {
                return $"Nullable<{FriendlyTypeName(underlying)}>";
            }

            if (type.IsArray)
            {
                return $"{FriendlyTypeName(type.GetElementType())}[]";
            }

            if (type.IsGenericType)
            {
                var name = type.Name;
                var tick = name.IndexOf('`');
                if (tick >= 0)
                {
                    name = name.Substring(0, tick);
                }

                var args = type.GetGenericArguments().Select(FriendlyTypeName);
                return $"{name}<{string.Join(", ", args)}>";
            }

            return type.Name;
        }

        private static string Normalize(string value)
            => value.Replace("\r\n", "\n").Replace("\r", "\n").TrimEnd('\n');

        private static string SnapshotPath([CallerFilePath] string thisFile = null)
        {
            var dir = Path.GetDirectoryName(thisFile);
            return Path.GetFullPath(Path.Combine(dir, "..", "..", "Snapshots", "models.serialization.snapshot.json"));
        }

        private sealed class ModelContract
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("properties")]
            public List<PropertyContract> Properties { get; set; }
        }

        private sealed class PropertyContract
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("converter")]
            public string Converter { get; set; }
        }
    }
}
