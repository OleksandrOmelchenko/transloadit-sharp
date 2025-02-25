namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/wasabi/import</c> Robot.
    /// </summary>
    public class WasabiImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Initializes <c>/wasabi/import</c> Robot.
        /// </summary>
        public WasabiImportRobot()
        {
            Robot = "/wasabi/import";
        }
    }
}
