using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/swift/store</c> Robot.
    /// </summary>
    public class SwiftStoreRobot : StoreRobotBase
    {
        public string Acl { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Initializes <c>/swift/store</c> Robot.
        /// </summary>
        public SwiftStoreRobot()
        {
            Robot = "/swift/store";
        }
    }
}
