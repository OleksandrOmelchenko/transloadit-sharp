using System;
using Newtonsoft.Json;

namespace Transloadit.Serialization
{
    /// <summary>
    /// Represents <c>int</c> to <c>bool</c> converter used to convert <c>0</c> to <c>false</c> and other values to <c>true</c>.
    /// </summary>
    public class BooleanToIntConverter : JsonConverter
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((bool)value ? 1 : 0);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var integer = Convert.ToInt32(reader.Value);
            return integer != 0;
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => objectType == typeof(bool);
    }
}
