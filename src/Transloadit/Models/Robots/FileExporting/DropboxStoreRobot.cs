namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/dropbox/store</c> Robot.
    /// </summary>
    public class DropboxStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// Whether to create a URL to this file for sharing with other people. This will overwrite the file's <c>url</c> property.
        /// </summary>
        public bool? CreateSharingLink { get; set; }

        /// <summary>
        /// Initializes <c>/dropbox/store</c> Robot.
        /// </summary>
        public DropboxStoreRobot()
        {
            Robot = "/dropbox/store";
        }
    }
}
