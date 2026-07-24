using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileExporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/cloudflare-store/">/cloudflare/store</a> Robot.
/// </summary>
public class CloudFlareStoreRobot : StoreRobotBase
{
    /// <summary>
    /// A JavaScript object containing a list of metadata to be set for this file on cloudflare Spaces, such as <c>{ FileURL: "${file.url_name}" }</c>. 
    /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
    /// Object Metadata can be specified using <c>x-amz-meta-*</c> headers.
    /// </summary>
    [TransloaditJsonName("headers")]
    public Dictionary<string, string> Headers { get; set; }

    /// <summary>
    /// This parameter provides signed URLs in the result JSON (in the <c>signed_ssl_url</c> property). The number that you set 
    /// this parameter to is the URL expiry time in seconds. If this parameter is not used, no URL signing is done.
    /// </summary>
    [TransloaditJsonName("sign_urls_for")]
    public int? SignUrlsFor { get; set; }

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

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/cloudflare-store/">/cloudflare/store</a> Robot.
    /// </summary>
    public CloudFlareStoreRobot()
    {
        Robot = "/cloudflare/store";
    }
}
