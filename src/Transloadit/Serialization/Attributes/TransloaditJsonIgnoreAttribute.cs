using System;

namespace Transloadit.Serialization.Attributes
{
    /// <summary>
    /// Marks a member to be excluded from JSON serialization, independent of the underlying JSON serializer.
    /// Each <see cref="ITransloaditSerializer"/> implementation maps this to its native ignore mechanism.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class TransloaditJsonIgnoreAttribute : Attribute
    {
    }
}
