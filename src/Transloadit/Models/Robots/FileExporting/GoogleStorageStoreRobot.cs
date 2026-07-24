using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileExporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/google-store/">/google/store</a> Robot.
/// </summary>
public class GoogleStorageStoreRobot : StoreRobotBase
{
    /// <summary>
    /// The permissions used for this file.
    /// <para>Default: <c>public-read</c>.</para>
    /// </summary>
    [TransloaditJsonName("acl")]
    public string Acl { get; set; }

    /// <summary>
    /// The <c>Cache-Control</c> header determines how long browsers are allowed to cache your object for. Values specified with 
    /// this parameter will be added to the object's metadata under the <c>Cache-Control</c> header.
    /// </summary>
    [TransloaditJsonName("cache_control")]
    public string CacheControl { get; set; }

    /// <summary>
    /// The URL of the file in the result JSON.
    /// </summary>
    [TransloaditJsonName("url_template")]
    public string UrlTemplate { get; set; }

    /// <summary>
    /// The SSL URL of the file in the result JSON.
    /// </summary>
    [TransloaditJsonName("ssl_url_template")]
    public string SslUrlTemplate { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/google-store/">/google/store</a> Robot.
    /// </summary>
    public GoogleStorageStoreRobot()
    {
        Robot = "/google/store";
    }
}
