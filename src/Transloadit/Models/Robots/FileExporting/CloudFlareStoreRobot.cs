using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/cloudflare/store</c> Robot.
    /// </summary>
    public class CloudFlareStoreRobot : StoreRobotBase
    {
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Initializes <c>/cloudflare/store</c> Robot.
        /// </summary>
        public CloudFlareStoreRobot()
        {
            Robot = "/cloudflare/store";
        }
    }
}
