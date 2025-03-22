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
        public string AccountType { get; set; }

        /// <summary>
        /// Rackspace Cloud Files data center.
        /// </summary>
        public string DataCenter { get; set; }

        /// <summary>
        /// Rackspace Cloud Files container.
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// Rackspace Cloud Files user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Rackspace Cloud Files key.
        /// </summary>
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
