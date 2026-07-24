using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileExporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/backblaze-store/">/backblaze/store</a> Robot.
/// </summary>
public class BackBlazeStoreRobot : StoreRobotBase
{
    /// <summary>
    /// A JavaScript object containing a list of metadata to be set for this file on backblaze, such as <c>{ FileURL: "${file.url_name}" }</c>. 
    /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
    /// </summary>
    [TransloaditJsonName("headers")]
    public Dictionary<string, string> Headers { get; set; }

    /// <summary>
    /// Backblaze bucket name.
    /// </summary>
    [TransloaditJsonName("bucket")]
    public string Bucket { get; set; }

    /// <summary>
    /// Backblaze App Key ID.
    /// </summary>
    [TransloaditJsonName("app_key_id")]
    public string AppKeyId { get; set; }

    /// <summary>
    /// Backblaze App Key.
    /// </summary>
    [TransloaditJsonName("app_key")]
    public string AppKey { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/backblaze-store/">/backblaze/store</a> Robot.
    /// </summary>
    public BackBlazeStoreRobot()
    {
        Robot = "/backblaze/store";
    }
}
