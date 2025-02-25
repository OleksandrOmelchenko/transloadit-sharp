namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/cloudflare/import</c> Robot.
    /// </summary>
    public class CloudFlareImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Initializes <c>/cloudflare/import</c> Robot.
        /// </summary>
        public CloudFlareImportRobot()
        {
            Robot = "/cloudflare/import";
        }
    }
}
