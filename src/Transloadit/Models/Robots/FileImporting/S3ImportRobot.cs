namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/s3/import</c> Robot.
    /// </summary>
    public class S3ImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Initializes <c>/s3/import</c> Robot.
        /// </summary>
        public S3ImportRobot()
        {
            Robot = "/s3/import";
        }
    }
}
