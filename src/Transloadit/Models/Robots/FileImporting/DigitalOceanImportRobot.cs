using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/digitalocean/import</c> Robot.
    /// </summary>
    public class DigitalOceanImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// DigitalOcean space name.
        /// </summary>
        [JsonProperty("space")]
        public string Space { get; set; }

        /// <summary>
        /// DigitalOcean space region.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// DigitalOcean space key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// DigitalOcean space secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <c>/digitalocean/import</c> Robot.
        /// </summary>
        public DigitalOceanImportRobot()
        {
            Robot = "/digitalocean/import";
        }
    }
}
