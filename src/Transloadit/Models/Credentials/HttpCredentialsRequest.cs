using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents HTTP credentials request.
/// </summary>
public class HttpCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes HTTP credentials request.
    /// </summary>
    public HttpCredentialsRequest()
    {
        Type = "http";
    }

    /// <summary>
    /// HTTP credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public HttpCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents HTTP credentials.
/// </summary>
public class HttpCredentialsContent
{
    /// <summary>
    /// HTTP headers.
    /// </summary>
    [TransloaditJsonName("headers")]
    public string Headers { get; set; }
}
