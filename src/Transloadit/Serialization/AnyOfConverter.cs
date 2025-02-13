using Newtonsoft.Json;
using System;
using System.Reflection;
using Transloadit.Models;

namespace Transloadit.Serialization
{
    public class AnyOfConverter : JsonConverter
    {
        public override bool CanWrite => true;

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

        public override bool CanConvert(Type objectType)
        {
            return typeof(AnyOf).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
