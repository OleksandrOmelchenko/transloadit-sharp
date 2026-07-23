#if !TRANSLOADIT_NEWTONSOFT
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Transloadit.Models;
using Transloadit.Models.Robots;

namespace Transloadit.Serialization
{
    /// <summary>
    /// System.Text.Json converter that serializes a <see cref="bool"/> as <c>1</c>/<c>0</c>.
    /// </summary>
    internal sealed class StjBooleanToIntConverter : JsonConverter<bool>
    {
        /// <inheritdoc />
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.TokenType == JsonTokenType.Number ? reader.GetInt32() != 0 : reader.GetBoolean();

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value ? 1 : 0);
    }

    /// <summary>
    /// System.Text.Json converter that serializes a nullable <see cref="bool"/> as <c>1</c>/<c>0</c>.
    /// </summary>
    internal sealed class StjNullableBooleanToIntConverter : JsonConverter<bool?>
    {
        /// <inheritdoc />
        public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            return reader.TokenType == JsonTokenType.Number ? reader.GetInt32() != 0 : reader.GetBoolean();
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteNumberValue(value.Value ? 1 : 0);
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }

    /// <summary>
    /// System.Text.Json converter that serializes a <see cref="DateTime"/> using a fixed format string.
    /// </summary>
    internal sealed class StjDateFormatConverter : JsonConverter<DateTime>
    {
        private readonly string _format;

        /// <summary>
        /// Initializes a new instance of the <see cref="StjDateFormatConverter"/> class with the date format.
        /// </summary>
        /// <param name="format">The .NET date/time format string.</param>
        public StjDateFormatConverter(string format)
        {
            _format = format;
        }

        /// <inheritdoc />
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateTime.Parse(reader.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_format, CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// System.Text.Json converter that serializes a nullable <see cref="DateTime"/> using a fixed format string.
    /// </summary>
    internal sealed class StjNullableDateFormatConverter : JsonConverter<DateTime?>
    {
        private readonly string _format;

        /// <summary>
        /// Initializes a new instance of the <see cref="StjNullableDateFormatConverter"/> class with the date format.
        /// </summary>
        /// <param name="format">The .NET date/time format string.</param>
        public StjNullableDateFormatConverter(string format)
        {
            _format = format;
        }

        /// <inheritdoc />
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            return DateTime.Parse(reader.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteStringValue(value.Value.ToString(_format, CultureInfo.InvariantCulture));
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }

    /// <summary>
    /// System.Text.Json converter factory that serializes <see cref="AnyOf"/> union values by emitting their inner value.
    /// </summary>
    internal sealed class StjAnyOfConverterFactory : JsonConverterFactory
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert)
            => typeof(AnyOf).IsAssignableFrom(typeToConvert);

        /// <inheritdoc />
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
            => (JsonConverter)Activator.CreateInstance(typeof(StjAnyOfConverter<>).MakeGenericType(typeToConvert));
    }

    /// <summary>
    /// System.Text.Json converter that writes an <see cref="AnyOf"/> union value as its inner value. Reading is not supported.
    /// </summary>
    /// <typeparam name="T">The concrete <see cref="AnyOf"/> type.</typeparam>
    internal sealed class StjAnyOfConverter<T> : JsonConverter<T>
        where T : AnyOf
    {
        /// <inheritdoc />
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => throw new NotSupportedException("Deserializing AnyOf<> values is not supported.");

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, value.Value, options);
    }

    /// <summary>
    /// System.Text.Json converter factory that serializes robot step values by their runtime type. Steps are declared
    /// as the abstract <see cref="RobotBase"/> (e.g. <c>Dictionary&lt;string, RobotBase&gt;</c>); without this, System.Text.Json
    /// would serialize only the base-class members, dropping every robot-specific parameter (Newtonsoft serializes by
    /// runtime type by default).
    /// </summary>
    internal sealed class StjPolymorphicRobotConverterFactory : JsonConverterFactory
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert)
            => typeof(RobotBase).IsAssignableFrom(typeToConvert) && typeToConvert.IsAbstract;

        /// <inheritdoc />
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
            => (JsonConverter)Activator.CreateInstance(typeof(StjPolymorphicRobotConverter<>).MakeGenericType(typeToConvert));
    }

    /// <summary>
    /// System.Text.Json converter that writes a robot step value using its concrete runtime type. Reading is not
    /// supported (robot steps are serialize-only; assembly/template responses model steps as untyped dictionaries).
    /// </summary>
    /// <typeparam name="T">The declared (abstract) robot base type.</typeparam>
    internal sealed class StjPolymorphicRobotConverter<T> : JsonConverter<T>
        where T : RobotBase
    {
        /// <inheritdoc />
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => throw new NotSupportedException("Deserializing robot step values is not supported.");

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            // re-dispatch to the concrete type; the concrete type is not abstract, so CanConvert returns false for it
            // and System.Text.Json serializes it through the normal contract (no recursion).
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
#endif
