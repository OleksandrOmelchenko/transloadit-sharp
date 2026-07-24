using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileExporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/tigris-store/">/tigris/store</a> Robot.
/// </summary>
public class TigrisStoreRobot : StoreRobotBase
{
    /// <summary>
    /// The permissions used for this file: <c>private</c> or <c>public-read</c>.
    /// <para>Default: <c>public-read</c>.</para>
    /// </summary>
    [TransloaditJsonName("acl")]
    public string Acl { get; set; }

    /// <summary>
    /// An object containing a list of headers to be set for this file on Tigris, such as <c>{ FileURL: "${file.url_name}" }</c>. 
    /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
    /// Object Metadata can be specified using <c>x-amz-meta-*</c> headers.
    /// </summary>
    [TransloaditJsonName("headers")]
    public Dictionary<string, string> Headers { get; set; }

    /// <summary>
    /// This parameter provides signed URLs in the result JSON (in the <c>signed_ssl_url</c> property). 
    /// The number that you set this parameter to is the URL expiry time in seconds.
    /// </summary>
    [TransloaditJsonName("sign_urls_for")]
    public int? SignUrlsFor { get; set; }

    /// <summary>
    /// The name of the bucket to which the file is exported.
    /// </summary>
    [TransloaditJsonName("bucket")]
    public string Bucket { get; set; }

    /// <summary>
    /// The custom domain for Tigris bucket location.
    /// </summary>
    [TransloaditJsonName("host")]
    public string Host { get; set; }

    /// <summary>
    /// Tigris access key ID.
    /// </summary>
    [TransloaditJsonName("key")]
    public string Key { get; set; }

    /// <summary>
    /// Tigris secret access Key.
    /// </summary>
    [TransloaditJsonName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/tigris-store/">/tigris/store</a> Robot.
    /// </summary>
    public TigrisStoreRobot()
    {
        Robot = "/tigris/store";
    }
}
