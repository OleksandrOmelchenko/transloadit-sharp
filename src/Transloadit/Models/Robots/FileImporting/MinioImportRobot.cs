using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/minio-import/">/minio/import</a> Robot.
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
        /// Initializes <a href="https://transloadit.com/docs/robots/minio-import/">/minio/import</a> Robot.
        /// </summary>
        public MinioImportRobot()
        {
            Robot = "/minio/import";
        }
    }
}
