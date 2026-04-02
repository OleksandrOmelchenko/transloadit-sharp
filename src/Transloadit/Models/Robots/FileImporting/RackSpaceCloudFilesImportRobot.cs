using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/cloudfiles/import</c> Robot.
    /// </summary>
    public class RackSpaceCloudFilesImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Rackspace Cloud Files account type.
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// Rackspace Cloud Files data center.
        /// </summary>
        [JsonProperty("data_center")]
        public string DataCenter { get; set; }

        /// <summary>
        /// Rackspace Cloud Files container.
        /// </summary>
        [JsonProperty("container")]
        public string Container { get; set; }

        /// <summary>
        /// Rackspace Cloud Files user.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        /// Rackspace Cloud Files key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Initializes <c>/cloudfiles/import</c> Robot.
        /// </summary>
        public RackSpaceCloudFilesImportRobot()
        {
            Robot = "/cloudfiles/import";
        }
    }
}
