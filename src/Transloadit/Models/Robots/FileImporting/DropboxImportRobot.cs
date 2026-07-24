namespace Transloadit.Models.Robots.FileImporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/dropbox-import/">/dropbox/import</a> Robot.
/// </summary>
public class DropboxImportRobot : ImportRobotBase
{
    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/dropbox-import/">/dropbox/import</a> Robot.
    /// </summary>
    public DropboxImportRobot()
    {
        Robot = "/dropbox/import";
    }
}
