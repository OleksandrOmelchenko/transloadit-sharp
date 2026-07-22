using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Transloadit.Models;
using Transloadit.Serialization;
using Xunit;

namespace Transloadit.Tests.Tests.Models
{
    // characterization (golden-snapshot) test that pins the serialization contract shape of
    // every class under Models to a committed file. any future change that alters how a class
    // serializes (renamed/added/removed property, changed type, added/removed converter) fails
    // this test until the snapshot is intentionally regenerated with UPDATE_SNAPSHOTS=1.
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
            var settings = TransloaditSerializerSettings.CreateDefault();
            var resolver = (DefaultContractResolver)settings.ContractResolver;

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
                if (resolver.ResolveContract(type) is JsonObjectContract objectContract)
                {
                    foreach (var property in objectContract.Properties)
                    {
                        if (property.Ignored)
                        {
                            continue;
                        }

                        properties.Add(new PropertyContract
                        {
                            Name = property.PropertyName,
                            Type = FriendlyTypeName(property.PropertyType),
                            Converter = EffectiveConverter(property, settings.Converters),
                        });
                    }

                    properties = properties.OrderBy(p => p.Name, StringComparer.Ordinal).ToList();
                }

                models.Add(new ModelContract { Type = type.FullName, Properties = properties });
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
                // AnyOf unions serialize via the settings-level AnyOfConverter, not an object contract
                && !typeof(AnyOf).IsAssignableFrom(type)
                // skip compiler-generated closures/state machines
                && !type.Name.Contains("<");
        }

        private static string EffectiveConverter(JsonProperty property, IList<JsonConverter> settingsConverters)
        {
            if (property.Converter != null)
            {
                return property.Converter.GetType().Name;
            }

            foreach (var converter in settingsConverters)
            {
                if (converter.CanConvert(property.PropertyType))
                {
                    return converter.GetType().Name;
                }
            }

            return null;
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
            // this file lives in tests/Transloadit.Tests/Tests/Models; the snapshot lives in
            // tests/Transloadit.Tests/Snapshots (two directories up).
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
