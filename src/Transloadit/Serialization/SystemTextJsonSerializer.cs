#if !TRANSLOADIT_NEWTONSOFT
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Serialization;

/// <summary>
/// <see cref="ITransloaditSerializer"/> implementation backed by System.Text.Json. This is the default serializer
/// on all frameworks except net452. The provider-neutral Transloadit attributes are honored via a
/// <see cref="JsonTypeInfo"/> modifier; property names default to snake_case for members without an explicit name.
/// </summary>
public sealed class SystemTextJsonSerializer : ITransloaditSerializer
{
    private readonly JsonSerializerOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="SystemTextJsonSerializer"/> class with the default options.
    /// </summary>
    public SystemTextJsonSerializer()
        : this(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SystemTextJsonSerializer"/> class, allowing the default
    /// <see cref="JsonSerializerOptions"/> (naming, null handling, converters) to be customized — for example to
    /// register additional converters.
    /// </summary>
    /// <param name="configure">An optional callback that receives the default <see cref="JsonSerializerOptions"/> before use.</param>
    public SystemTextJsonSerializer(Action<JsonSerializerOptions> configure)
    {
        _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            // match Newtonsoft's DefaultContractResolver, which resolves property names case-insensitively
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { ApplyNeutralAttributes },
            },
        };
        _options.Converters.Add(new StjAnyOfConverterFactory());
        _options.Converters.Add(new StjPolymorphicRobotConverterFactory());
        _options.Converters.Add(new StjInferredTypeConverter());
        _options.Converters.Add(new StjDateTimeOffsetConverter());
        configure?.Invoke(_options);
    }

    /// <inheritdoc />
    public string Serialize(object value)
        => JsonSerializer.Serialize(value, value?.GetType() ?? typeof(object), _options);

    /// <inheritdoc />
    public T Deserialize<T>(string json)
        => JsonSerializer.Deserialize<T>(json, _options);

    private static void ApplyNeutralAttributes(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Kind != JsonTypeInfoKind.Object)
        {
            return;
        }

        // adjust the default (public) properties: apply neutral name/converter, drop ignored members
        for (var i = typeInfo.Properties.Count - 1; i >= 0; i--)
        {
            var jsonProperty = typeInfo.Properties[i];
            if (jsonProperty.AttributeProvider is not MemberInfo member)
            {
                continue;
            }

            if (member.GetCustomAttribute<TransloaditJsonIgnoreAttribute>() != null)
            {
                typeInfo.Properties.RemoveAt(i);
                continue;
            }

            var name = member.GetCustomAttribute<TransloaditJsonNameAttribute>();
            if (name != null)
            {
                jsonProperty.Name = name.Name;
            }

            ApplyConverter(jsonProperty, member);
        }

        // include non-public members that carry a neutral name attribute (explicit interface implementations,
        // internal properties) — these are not part of the default contract. walk the hierarchy declaring level by level.
        for (var type = typeInfo.Type; type != null && type != typeof(object); type = type.BaseType)
        {
            foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                var name = property.GetCustomAttribute<TransloaditJsonNameAttribute>();
                if (name == null || IsAlreadyMapped(typeInfo, property))
                {
                    continue;
                }

                var jsonProperty = typeInfo.CreateJsonPropertyInfo(property.PropertyType, name.Name);
                var captured = property;
                jsonProperty.Get = obj => captured.GetValue(obj);
                if (captured.GetSetMethod(true) != null)
                {
                    jsonProperty.Set = (obj, value) => captured.SetValue(obj, value);
                }

                ApplyConverter(jsonProperty, property);
                typeInfo.Properties.Add(jsonProperty);
            }
        }
    }

    private static bool IsAlreadyMapped(JsonTypeInfo typeInfo, PropertyInfo property)
    {
        foreach (var jsonProperty in typeInfo.Properties)
        {
            if (jsonProperty.AttributeProvider is MemberInfo member
                && member.Name == property.Name
                && member.DeclaringType == property.DeclaringType)
            {
                return true;
            }
        }

        return false;
    }

    private static void ApplyConverter(JsonPropertyInfo jsonProperty, MemberInfo member)
    {
        if (member.GetCustomAttribute<TransloaditBooleanToIntAttribute>() != null)
        {
            jsonProperty.CustomConverter = jsonProperty.PropertyType == typeof(bool?)
                ? new StjNullableBooleanToIntConverter()
                : (JsonConverter)new StjBooleanToIntConverter();
        }

        var dateFormat = member.GetCustomAttribute<TransloaditDateFormatAttribute>();
        if (dateFormat != null)
        {
            jsonProperty.CustomConverter = jsonProperty.PropertyType == typeof(DateTime?)
                ? new StjNullableDateFormatConverter(dateFormat.Format)
                : (JsonConverter)new StjDateFormatConverter(dateFormat.Format);
        }
    }
}
#endif
