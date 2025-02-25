namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/cloudfiles/import</c> Robot.
    /// </summary>
    public class RackSpaceCloudFilesImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Initializes <c>/cloudfiles/import</c> Robot.
        /// </summary>
        public RackSpaceCloudFilesImportRobot()
        {
            Robot = "/cloudfiles/import";
        }
    }
}
