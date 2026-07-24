using System;

namespace Transloadit.Serialization.Attributes
{
    /// <summary>
    /// Specifies the JSON property name for a member, independent of the underlying JSON serializer.
    /// Each <see cref="ITransloaditSerializer"/> implementation maps this to its native naming mechanism.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class TransloaditJsonNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransloaditJsonNameAttribute"/> class with the JSON name.
        /// </summary>
        /// <param name="name">The JSON property name to use for the decorated member.</param>
        public TransloaditJsonNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The JSON property name to use for the decorated member.
        /// </summary>
        public string Name { get; }
    }
}
