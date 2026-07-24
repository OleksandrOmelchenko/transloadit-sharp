using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents base credentials request object.
/// </summary>
public abstract class CredentialsRequestBase : BaseParams
{
    /// <summary>
    /// Template credentials name.
    /// </summary>
    [TransloaditJsonName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Template credentials type.
    /// </summary>
    [TransloaditJsonName("type")]
    public string Type { get; protected set; }
}

/// <summary>
/// Represents generic credentials request.
/// </summary>
public class GenericCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes generic credentials request.
    /// </summary>
    public GenericCredentialsRequest(string type)
    {
        Type = type;
    }

    /// <summary>
    /// Generic credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public Dictionary<string, string> Content { get; set; }
}
