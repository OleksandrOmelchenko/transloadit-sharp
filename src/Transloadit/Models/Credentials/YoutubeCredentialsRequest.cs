using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents YouTube credentials request. YouTube uses OAuth, so the token values are normally obtained through the
/// OAuth flow when generating Template Credentials.
/// </summary>
public class YoutubeCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes YouTube credentials request.
    /// </summary>
    public YoutubeCredentialsRequest()
    {
        Type = "youtube";
    }

    /// <summary>
    /// YouTube credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public YoutubeCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents YouTube credentials.
/// </summary>
public class YoutubeCredentialsContent
{
    /// <summary>
    /// YouTube OAuth access token.
    /// </summary>
    [TransloaditJsonName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// YouTube OAuth refresh token. Optional; used together with <see cref="AccessToken"/> for dynamic credentials.
    /// </summary>
    [TransloaditJsonName("refresh_token")]
    public string RefreshToken { get; set; }
}
