using System;

namespace Transloadit.Models
{
    /// <summary>
    /// Represents a base union class.
    /// </summary>
    public abstract class AnyOf
    {
        /// <summary>
        /// Gets the current value.
        /// </summary>
        public abstract object Value { get; }

        /// <summary>
        /// Gets the current value type.
        /// </summary>
        public abstract Type Type { get; }
    }

    /// <summary>
    /// Represents a union of 2 types.
    /// </summary>
    /// <typeparam name="T1">First type.</typeparam>
    /// <typeparam name="T2">Second type.</typeparam>
    public class AnyOf<T1, T2> : AnyOf
    {
        private enum Values
        {
            First,
            Seconds
        }

        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly Values _values;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyOf{T1, T2}"/> class with type <see cref="T1"/>.
        /// </summary>
        /// <param name="value"><see cref="T1"/> value.</param>
        public AnyOf(T1 value)
        {
            _value1 = value;
            _values = Values.First;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyOf{T1, T2}"/> class with type <see cref="T2"/>.
        /// </summary>
        /// <param name="value"><see cref="T2"/> value.</param>
        public AnyOf(T2 value)
        {
            _value2 = value;
            _values = Values.Seconds;
        }

        public override object Value
        {
            get
            {
                return _values switch
                {
                    Values.First => _value1,
                    Values.Seconds => _value2,
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
                    Values.First => typeof(T1),
                    Values.Seconds => typeof(T2),
                    _ => throw new InvalidOperationException($"Unexpected value type: {_values}"),
                };
            }
        }

        public static implicit operator AnyOf<T1, T2>(T1 value) => value is null ? null : new AnyOf<T1, T2>(value);
        public static implicit operator AnyOf<T1, T2>(T2 value) => value is null ? null : new AnyOf<T1, T2>(value);

        public static implicit operator T1(AnyOf<T1, T2> anyOf) => anyOf._value1;
        public static implicit operator T2(AnyOf<T1, T2> anyOf) => anyOf._value2;
    }

    /// <summary>
    /// Represents a union of 3 types.
    /// </summary>
    /// <typeparam name="T1">First type.</typeparam>
    /// <typeparam name="T2">Second type.</typeparam>
    /// <typeparam name="T3">Third type.</typeparam>
    public class AnyOf<T1, T2, T3> : AnyOf
    {
        private enum Values
        {
            First,
            Second,
            Third,
        }

        private readonly T1 _firstValue;
        private readonly T2 _secondValue;
        private readonly T3 _thirdValue;
        private readonly Values _values;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyOf{T1, T2, T3}"/> class with type <see cref="T1"/>.
        /// </summary>
        /// <param name="value"><see cref="T1"/> value.</param>
        public AnyOf(T1 value)
        {
            _firstValue = value;
            _values = Values.First;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyOf{T1, T2, T3}"/> class with type <see cref="T2"/>.
        /// </summary>
        /// <param name="value"><see cref="T2"/> value.</param>
        public AnyOf(T2 value)
        {
            _secondValue = value;
            _values = Values.Second;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnyOf{T1, T2, T3}"/> class with type <see cref="T3"/>.
        /// </summary>
        /// <param name="value"><see cref="T3"/> value.</param>
        public AnyOf(T3 value)
        {
            _thirdValue = value;
            _values = Values.Third;
        }

        public override object Value
        {
            get
            {
                return _values switch
                {
                    Values.First => _firstValue,
                    Values.Second => _secondValue,
                    Values.Third => _thirdValue,
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
                    Values.First => typeof(T1),
                    Values.Second => typeof(T2),
                    Values.Third => typeof(T3),
                    _ => throw new InvalidOperationException($"Unexpected value type: {_values}"),
                };
            }
        }

        public static implicit operator AnyOf<T1, T2, T3>(T1 value) => value is null ? null : new AnyOf<T1, T2, T3>(value);
        public static implicit operator AnyOf<T1, T2, T3>(T2 value) => value is null ? null : new AnyOf<T1, T2, T3>(value);
        public static implicit operator AnyOf<T1, T2, T3>(T3 value) => value is null ? null : new AnyOf<T1, T2, T3>(value);

        public static implicit operator T1(AnyOf<T1, T2, T3> anyOf) => anyOf._firstValue;
        public static implicit operator T2(AnyOf<T1, T2, T3> anyOf) => anyOf._secondValue;
        public static implicit operator T3(AnyOf<T1, T2, T3> anyOf) => anyOf._thirdValue;
    }
}
