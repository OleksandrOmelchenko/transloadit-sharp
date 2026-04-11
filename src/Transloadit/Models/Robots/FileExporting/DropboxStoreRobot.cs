using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/dropbox-store/">/dropbox/store</a> Robot.
    /// </summary>
    public class DropboxStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// Whether to create a URL to this file for sharing with other people. This will overwrite the file's <c>url</c> property.
        /// </summary>
        [JsonProperty("create_sharing_link")]
        public bool? CreateSharingLink { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/dropbox-store/">/dropbox/store</a> Robot.
        /// </summary>
        public DropboxStoreRobot()
        {
            Robot = "/dropbox/store";
        }
    }
}

