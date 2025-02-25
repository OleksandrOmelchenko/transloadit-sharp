namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/digitalocean/import</c> Robot.
    /// </summary>
    public class DigitalOceanImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Initializes <c>/digitalocean/import</c> Robot.
        /// </summary>
        public DigitalOceanImportRobot()
        {
            Robot = "/digitalocean/import";
        }
    }
}
