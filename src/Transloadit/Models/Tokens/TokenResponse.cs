using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Tokens;

/// <summary>
/// Represents bearer token response payload.
/// </summary>
public class TokenResponse : ResponseBase
{
    /// <summary>
    /// Access token value.
    /// </summary>
    [TransloaditJsonName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Token type.
    /// </summary>
    [TransloaditJsonName("token_type")]
    public string TokenType { get; set; }

    /// <summary>
    /// Token lifetime in seconds.
    /// </summary>
    [TransloaditJsonName("expires_in")]
    public int? ExpiresIn { get; set; }

    /// <summary>
    /// Granted scope list.
    /// </summary>
    [TransloaditJsonName("scope")]
    public string Scope { get; set; }
}
