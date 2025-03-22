namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/minio/import</c> Robot.
    /// </summary>
    public class MinioImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// MinIO bucket.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// MinIO key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// MinIO secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// MinIO host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Initializes <c>/minio/import</c> Robot.
        /// </summary>
        public MinioImportRobot()
        {
            Robot = "/minio/import";
        }
    }
}
