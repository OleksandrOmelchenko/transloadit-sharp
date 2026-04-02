using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/cloudfiles/store</c> Robot.
    /// </summary>
    public class RackSpaceCloudFilesStoreRobot : StoreRobotBase
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
        /// Initializes <c>/cloudfiles/store</c> Robot.
        /// </summary>
        public RackSpaceCloudFilesStoreRobot()
        {
            Robot = "/cloudfiles/store";
        }

    }
}
