using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/cloudflare/import</c> Robot.
    /// </summary>
    public class CloudFlareImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Cloudflare bucket.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// Cloudflare host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Cloudflare key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Cloudflare secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <c>/cloudflare/import</c> Robot.
        /// </summary>
        public CloudFlareImportRobot()
        {
            Robot = "/cloudflare/import";
        }
    }
}
