using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

namespace Transloadit.Serialization
{
    public abstract class AnyOf
    {
        public abstract object Value { get; }
        public abstract Type Type { get; }
    }

    public class AnyOf<T1, T2> : AnyOf
    {
        private enum Values
        {
            T1,
            T2
        }

        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly Values _values;

        public AnyOf(T1 value)
        {
            _value1 = value;
            _values = Values.T1;
        }

        public AnyOf(T2 value)
        {
            _value2 = value;
            _values = Values.T2;
        }

        public override object Value
        {
            get
            {
                return _values switch
                {
                    Values.T1 => _value1,
                    Values.T2 => _value2,
                    _ => throw new InvalidOperationException($"Unexpected value type: {_values}"),
                };
            }
        }

        public override Type Type
        {
            get
            {
                return _values switch
                {
                    Values.T1 => typeof(T1),
                    Values.T2 => typeof(T2),
                    _ => throw new InvalidOperationException($"Unexpected value type: {_values}"),
                };
            }
        }

        public static implicit operator AnyOf<T1, T2>(T1 value) => value is null ? null : new AnyOf<T1, T2>(value);
        public static implicit operator AnyOf<T1, T2>(T2 value) => value is null ? null : new AnyOf<T1, T2>(value);

        public static implicit operator T1(AnyOf<T1, T2> anyOf) => anyOf._value1;
        public static implicit operator T2(AnyOf<T1, T2> anyOf) => anyOf._value2;

    }

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
