using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/wasabi/store</c> Robot.
    /// </summary>
    public class WasabiStoreRobot : StoreRobotBase
    {
        public string Acl { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Initializes <c>/wasabi/store</c> Robot.
        /// </summary>
        public WasabiStoreRobot()
        {
            Robot = "/wasabi/store";
        }
    }
}
