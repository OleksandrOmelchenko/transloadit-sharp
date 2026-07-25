using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents Box credentials request. Box uses OAuth, so the token values are normally obtained through the OAuth
/// flow when generating Template Credentials.
/// </summary>
public class BoxCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes Box credentials request.
    /// </summary>
    public BoxCredentialsRequest()
    {
        Type = "box";
    }

    /// <summary>
    /// Box credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public BoxCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents Box credentials.
/// </summary>
public class BoxCredentialsContent
{
    /// <summary>
    /// Box OAuth access token.
    /// </summary>
    [TransloaditJsonName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Box OAuth refresh token. Optional; used together with <see cref="AccessToken"/> for dynamic credentials.
    /// </summary>
    [TransloaditJsonName("refresh_token")]
    public string RefreshToken { get; set; }
}
