using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/backblaze/store</c> Robot.
    /// </summary>
    public class BackBlazeStoreRobot : StoreRobotBase
    {
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Initializes <c>/backblaze/store</c> Robot.
        /// </summary>
        public BackBlazeStoreRobot()
        {
            Robot = "/backblaze/store";
        }
    }
}
