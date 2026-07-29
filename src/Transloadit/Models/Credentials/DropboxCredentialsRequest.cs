using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents Dropbox credentials request. Dropbox uses OAuth, so the token values are normally obtained through the
/// OAuth flow when generating Template Credentials.
/// </summary>
public class DropboxCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes Dropbox credentials request.
    /// </summary>
    public DropboxCredentialsRequest()
    {
        Type = "dropbox";
    }

    /// <summary>
    /// Dropbox credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public DropboxCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents Dropbox credentials.
/// </summary>
public class DropboxCredentialsContent
{
    /// <summary>
    /// Dropbox app key.
    /// </summary>
    [TransloaditJsonName("app_key")]
    public string AppKey { get; set; }

    /// <summary>
    /// Dropbox app secret.
    /// </summary>
    [TransloaditJsonName("app_secret")]
    public string AppSecret { get; set; }

    /// <summary>
    /// Dropbox OAuth access token.
    /// </summary>
    [TransloaditJsonName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Dropbox OAuth refresh token. Optional; used together with <see cref="AccessToken"/> for dynamic credentials.
    /// </summary>
    [TransloaditJsonName("refresh_token")]
    public string RefreshToken { get; set; }
}
