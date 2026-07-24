using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents OAuth (companion) credentials request.
/// </summary>
public class OAuthCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes OAuth (companion) credentials request.
    /// </summary>
    public OAuthCredentialsRequest()
    {
        Type = "companion";
    }

    /// <summary>
    /// OAuth (companion) credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public OAuthCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents OAuth (companion) credentials.
/// </summary>
public class OAuthCredentialsContent
{
    /// <summary>
    /// OAuth provider.
    /// </summary>
    [TransloaditJsonName("provider")]
    public string Provider { get; set; }

    /// <summary>
    /// OAuth key.
    /// </summary>
    [TransloaditJsonName("key")]
    public string Key { get; set; }

    /// <summary>
    /// OAuth secret.
    /// </summary>
    [TransloaditJsonName("secret")]
    public string Secret { get; set; }
}
