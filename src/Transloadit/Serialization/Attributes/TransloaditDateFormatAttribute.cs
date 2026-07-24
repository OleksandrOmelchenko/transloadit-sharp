using System;

namespace Transloadit.Serialization.Attributes
{
    /// <summary>
    /// Specifies a .NET date/time format string used to serialize a <see cref="DateTime"/> member,
    /// independent of the underlying JSON serializer.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class TransloaditDateFormatAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransloaditDateFormatAttribute"/> class with the date format.
        /// </summary>
        /// <param name="format">The .NET date/time format string (for example <c>yyyy-MM-dd HH:mm:ss</c>).</param>
        public TransloaditDateFormatAttribute(string format)
        {
            Format = format;
        }

        /// <summary>
        /// The .NET date/time format string used to serialize the decorated member.
        /// </summary>
        public string Format { get; }
    }
}
