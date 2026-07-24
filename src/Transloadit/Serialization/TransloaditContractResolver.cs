#if TRANSLOADIT_NEWTONSOFT
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Serialization;

/// <summary>
/// Newtonsoft.Json contract resolver that maps the provider-neutral Transloadit serialization attributes
/// (<see cref="TransloaditJsonNameAttribute"/>, <see cref="TransloaditJsonIgnoreAttribute"/>,
/// <see cref="TransloaditBooleanToIntAttribute"/>, <see cref="TransloaditDateFormatAttribute"/>) to Newtonsoft behavior.
/// </summary>
internal sealed class TransloaditContractResolver : DefaultContractResolver
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransloaditContractResolver"/> class.
    /// </summary>
    public TransloaditContractResolver()
    {
        NamingStrategy = new SnakeCaseNamingStrategy();
    }

    /// <inheritdoc />
    protected override List<MemberInfo> GetSerializableMembers(Type objectType)
    {
        var members = base.GetSerializableMembers(objectType);

        // base already includes public members; additionally include non-public members that carry a neutral name
        // attribute (e.g. explicit interface implementations and internal properties). these are not inherited via
        // GetProperties on a derived type, so walk the whole hierarchy declaring level by level.
        for (var type = objectType; type != null && type != typeof(object); type = type.BaseType)
        {
            foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                if (property.GetCustomAttribute<TransloaditJsonNameAttribute>() != null && !members.Contains(property))
                {
                    members.Add(property);
                }
            }
        }

        return members;
    }

    /// <inheritdoc />
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        var name = member.GetCustomAttribute<TransloaditJsonNameAttribute>();
        if (name != null)
        {
            property.PropertyName = name.Name;
            property.Readable = true;
            property.Writable = true;
        }

        if (member.GetCustomAttribute<TransloaditJsonIgnoreAttribute>() != null)
        {
            property.Ignored = true;
        }

        if (member.GetCustomAttribute<TransloaditBooleanToIntAttribute>() != null)
        {
            property.Converter = new BooleanToIntConverter();
        }

        var dateFormat = member.GetCustomAttribute<TransloaditDateFormatAttribute>();
        if (dateFormat != null)
        {
            // pin invariant culture so dates never format with a locale calendar/digits (e.g. Thai Buddhist year,
            // Arabic-Indic digits), which would corrupt the signed `expires`/pagination values
            property.Converter = new IsoDateTimeConverter
            {
                DateTimeFormat = dateFormat.Format,
                Culture = CultureInfo.InvariantCulture,
            };
        }

        return property;
    }
}
#endif
