using System;
using System.Reflection;
using Newtonsoft.Json;
using Transloadit.Models;

namespace Transloadit.Serialization
{
    /// <summary>
    /// Represents json converter used to serialize <see cref="AnyOf"/> objects.
    /// </summary>
    public class AnyOfConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanWrite => true;

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch (value)
            {
                case null:
                    serializer.Serialize(writer, null);
                    break;
                case AnyOf anyOf:
                    serializer.Serialize(writer, anyOf.Value);
                    break;
                default:
                    throw new JsonSerializationException($"Unexpected value type: {value.GetType()}");
            }
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return typeof(AnyOf).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
