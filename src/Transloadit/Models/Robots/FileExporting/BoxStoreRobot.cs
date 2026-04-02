using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/box/store</c> Robot.
    /// </summary>
    public class BoxStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// Whether to create a sharing URL.
        /// </summary>
        [JsonProperty("create_sharing_link")]
        public bool? CreateSharingLink { get; set; }

        /// <summary>
        /// Initializes <c>/box/store</c> Robot.
        /// </summary>
        public BoxStoreRobot()
        {
            Robot = "/box/store";
        }
    }
}
