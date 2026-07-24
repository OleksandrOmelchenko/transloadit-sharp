using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileExporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/box-store/">/box/store</a> Robot.
/// </summary>
public class BoxStoreRobot : StoreRobotBase
{
    /// <summary>
    /// Whether to create a sharing URL.
    /// </summary>
    [TransloaditJsonName("create_sharing_link")]
    public bool? CreateSharingLink { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/box-store/">/box/store</a> Robot.
    /// </summary>
    public BoxStoreRobot()
    {
        Robot = "/box/store";
    }
}
