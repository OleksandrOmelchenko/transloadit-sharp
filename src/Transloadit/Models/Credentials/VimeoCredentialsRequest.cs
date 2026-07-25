using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents Vimeo credentials request. Vimeo uses OAuth, so the token values are normally obtained through the
/// OAuth flow when generating Template Credentials.
/// </summary>
public class VimeoCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes Vimeo credentials request.
    /// </summary>
    public VimeoCredentialsRequest()
    {
        Type = "vimeo";
    }

    /// <summary>
    /// Vimeo credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public VimeoCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents Vimeo credentials.
/// </summary>
public class VimeoCredentialsContent
{
    /// <summary>
    /// Vimeo OAuth access token.
    /// </summary>
    [TransloaditJsonName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Vimeo OAuth refresh token. Optional; used together with <see cref="AccessToken"/> for dynamic credentials.
    /// </summary>
    [TransloaditJsonName("refresh_token")]
    public string RefreshToken { get; set; }
}
