using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Tests.Infrastructure
{
    // bug-finding helper: compares the keys a real API response actually contains against the keys a model type
    // maps via [TransloaditJsonName]. keys present in the JSON but absent from the model are data the client
    // silently drops (a missing-field bug or a newly-added API field). reflection walks the full hierarchy so
    // explicit-interface and inherited members count as mapped.
    internal static class ResponseCoverage
    {
        // top-level JSON object keys that `modelType` does not declare a [TransloaditJsonName] for
        public static IReadOnlyList<string> UnmappedTopLevelKeys(string json, Type modelType)
        {
            var mapped = MappedJsonNames(modelType);
            return JObject.Parse(json)
                .Properties()
                .Select(p => p.Name)
                .Where(key => !mapped.Contains(key))
                .OrderBy(key => key, StringComparer.Ordinal)
                .ToList();
        }

        public static ISet<string> MappedJsonNames(Type type)
        {
            var names = new HashSet<string>(StringComparer.Ordinal);
            for (var current = type; current != null && current != typeof(object); current = current.BaseType)
            {
                const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
                foreach (var property in current.GetProperties(flags))
                {
                    var attribute = property.GetCustomAttribute<TransloaditJsonNameAttribute>();
                    if (attribute != null)
                    {
                        names.Add(attribute.Name);
                    }
                }
            }

            return names;
        }
    }
}
