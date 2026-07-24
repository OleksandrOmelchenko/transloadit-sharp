using System;

namespace Transloadit.Serialization.Attributes;

/// <summary>
/// Marks a <see cref="bool"/> member to be serialized as an integer (<c>1</c> for <c>true</c>, <c>0</c> for <c>false</c>),
/// independent of the underlying JSON serializer.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public sealed class TransloaditBooleanToIntAttribute : Attribute
{
}
