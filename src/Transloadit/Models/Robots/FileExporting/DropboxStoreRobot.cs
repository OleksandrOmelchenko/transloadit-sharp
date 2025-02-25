namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/dropbox/store</c> Robot.
    /// </summary>
    public class DropboxStoreRobot : StoreRobotBase
    {
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
