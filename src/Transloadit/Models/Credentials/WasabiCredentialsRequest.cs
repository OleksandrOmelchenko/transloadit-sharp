using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents Wasabi credentials request.
/// </summary>
public class WasabiCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes Wasabi credentials request.
    /// </summary>
    public WasabiCredentialsRequest()
    {
        Type = "wasabi";
    }

    /// <summary>
    /// Wasabi credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public WasabiCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents Wasabi credentials.
/// </summary>
public class WasabiCredentialsContent
{
    /// <summary>
    /// Wasabi host.
    /// </summary>
    [TransloaditJsonName("host")]
    public string Host { get; set; }

    /// <summary>
    /// Wasabi user.
    /// </summary>
    [TransloaditJsonName("user")]
    public string User { get; set; }

    /// <summary>
    /// Wasabi password.
    /// </summary>
    [TransloaditJsonName("password")]
    public string Password { get; set; }
}
