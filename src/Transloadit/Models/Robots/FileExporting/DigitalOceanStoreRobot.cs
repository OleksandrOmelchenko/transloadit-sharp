using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileExporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/digitalocean-store/">/digitalocean/store</a> Robot.
/// </summary>
public class DigitalOceanStoreRobot : StoreRobotBase
{
    /// <summary>
    /// The URL prefix used for the returned URL, such as <c>https://my.cdn.com/some/path</c>.
    /// <para>Default: <c>https://{space}.{region}.digitaloceanspaces.com/</c>.</para>
    /// </summary>
    [TransloaditJsonName("url_prefix")]
    public string UrlPrefix { get; set; }

    /// <summary>
    /// The permissions used for this file.
    /// <para>Default: <c>public-read</c>.</para>
    /// </summary>
    [TransloaditJsonName("acl")]
    public string Acl { get; set; }

    /// <summary>
    /// An object containing a list of headers to be set for this file on DigitalOcean Spaces, such as <c>{ FileURL: "${file.url_name}" }</c>. 
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
    /// DigitalOcean space name.
    /// </summary>
    [TransloaditJsonName("space")]
    public string Space { get; set; }

    /// <summary>
    /// DigitalOcean space region.
    /// </summary>
    [TransloaditJsonName("region")]
    public string Region { get; set; }

    /// <summary>
    /// DigitalOcean space key.
    /// </summary>
    [TransloaditJsonName("key")]
    public string Key { get; set; }

    /// <summary>
    /// DigitalOcean space secret.
    /// </summary>
    [TransloaditJsonName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/digitalocean-store/">/digitalocean/store</a> Robot.
    /// </summary>
    public DigitalOceanStoreRobot()
    {
        Robot = "/digitalocean/store";
    }
}
