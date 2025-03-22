namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/s3/import</c> Robot.
    /// </summary>
    public class S3ImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// S3 key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// S3 secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// S3 bucket name.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// S3 bucket region.
        /// </summary>
        public string BucketRegion { get; set; }

        /// <summary>
        /// Initializes <c>/s3/import</c> Robot.
        /// </summary>
        public S3ImportRobot()
        {
            Robot = "/s3/import";
        }
    }
}
