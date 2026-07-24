using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/box-import/">/box/import</a> Robot.
/// </summary>
public class BoxImportRobot : ImportRobotBase
{
    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/box-import/">/box/import</a> Robot.
    /// </summary>
    public BoxImportRobot()
    {
        Robot = "/box/import";
    }
}
