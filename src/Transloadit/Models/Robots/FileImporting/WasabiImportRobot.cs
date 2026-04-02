using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/wasabi/import</c> Robot.
    /// </summary>
    public class WasabiImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Wasabi host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Wasabi user.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        /// Wasabi password.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Initializes <c>/wasabi/import</c> Robot.
        /// </summary>
        public WasabiImportRobot()
        {
            Robot = "/wasabi/import";
        }
    }
}
