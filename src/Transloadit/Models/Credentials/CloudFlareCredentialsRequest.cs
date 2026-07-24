using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents Cloudflare credentials request.
/// </summary>
public class CloudflareCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes Cloudflare credentials request.
    /// </summary>
    public CloudflareCredentialsRequest()
    {
        Type = "cloudflare";
    }

    /// <summary>
    /// Cloudflare credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public CloudFlareCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents Cloudflare credentials.
/// </summary>
public class CloudFlareCredentialsContent
{
    /// <summary>
    /// Cloudflare bucket.
    /// </summary>
    [TransloaditJsonName("bucket")]
    public string Bucket { get; set; }

    /// <summary>
    /// Cloudflare host.
    /// </summary>
    [TransloaditJsonName("host")]
    public string Host { get; set; }

    /// <summary>
    /// Cloudflare key.
    /// </summary>
    [TransloaditJsonName("key")]
    public string Key { get; set; }

    /// <summary>
    /// Cloudflare secret.
    /// </summary>
    [TransloaditJsonName("secret")]
    public string Secret { get; set; }
}
