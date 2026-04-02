using Newtonsoft.Json;

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
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// MinIO key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// MinIO secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// MinIO host.
        /// </summary>
        [JsonProperty("host")]
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
