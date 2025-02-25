namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/minio/import</c> Robot.
    /// </summary>
    public class MinioImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Initializes <c>/minio/import</c> Robot.
        /// </summary>
        public MinioImportRobot()
        {
            Robot = "/minio/import";
        }
    }
}
