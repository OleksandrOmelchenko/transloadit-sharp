using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/swift-import/">/swift/import</a> Robot.
    /// </summary>
    public class SwiftImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Swift bucket.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// Swift host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Swift key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Swift secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/swift-import/">/swift/import</a> Robot.
        /// </summary>
        public SwiftImportRobot()
        {
            Robot = "/swift/import";
        }
    }
}
