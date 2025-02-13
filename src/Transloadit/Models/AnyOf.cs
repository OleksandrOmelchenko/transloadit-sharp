using System;

namespace Transloadit.Models
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

    public class AnyOf<T1, T2, T3> : AnyOf
    {
        private enum Values
        {
            T1,
            T2,
            T3,
        }

        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
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

        public AnyOf(T3 value)
        {
            _value3 = value;
            _values = Values.T3;
        }

        public override object Value
        {
            get
            {
                return _values switch
                {
                    Values.T1 => _value1,
                    Values.T2 => _value2,
                    Values.T3 => _value3,
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
                    Values.T3 => typeof(T3),
                    _ => throw new InvalidOperationException($"Unexpected value type: {_values}"),
                };
            }
        }

        public static implicit operator AnyOf<T1, T2, T3>(T1 value) => value is null ? null : new AnyOf<T1, T2, T3>(value);
        public static implicit operator AnyOf<T1, T2, T3>(T2 value) => value is null ? null : new AnyOf<T1, T2, T3>(value);
        public static implicit operator AnyOf<T1, T2, T3>(T3 value) => value is null ? null : new AnyOf<T1, T2, T3>(value);

        public static implicit operator T1(AnyOf<T1, T2, T3> anyOf) => anyOf._value1;
        public static implicit operator T2(AnyOf<T1, T2, T3> anyOf) => anyOf._value2;
        public static implicit operator T3(AnyOf<T1, T2, T3> anyOf) => anyOf._value3;
    }
}
