using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/cloudfiles-store/">/cloudfiles/store</a> Robot.
    /// </summary>
    public class RackSpaceCloudFilesStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// Rackspace Cloud Files account type.
        /// </summary>
        [TransloaditJsonName("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// Rackspace Cloud Files data center.
        /// </summary>
        [TransloaditJsonName("data_center")]
        public string DataCenter { get; set; }

        /// <summary>
        /// Rackspace Cloud Files container.
        /// </summary>
        [TransloaditJsonName("container")]
        public string Container { get; set; }

        /// <summary>
        /// Rackspace Cloud Files user.
        /// </summary>
        [TransloaditJsonName("user")]
        public string User { get; set; }

        /// <summary>
        /// Rackspace Cloud Files key.
        /// </summary>
        [TransloaditJsonName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/cloudfiles-store/">/cloudfiles/store</a> Robot.
        /// </summary>
        public RackSpaceCloudFilesStoreRobot()
        {
            Robot = "/cloudfiles/store";
        }

    }
}
