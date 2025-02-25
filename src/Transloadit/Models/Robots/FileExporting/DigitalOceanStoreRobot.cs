using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/digitalocean/store</c> Robot.
    /// </summary>
    public class DigitalOceanStoreRobot : StoreRobotBase
    {
        public string UrlPrefix { get; set; }
        public string Acl { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Initializes <c>/digitalocean/store</c> Robot.
        /// </summary>
        public DigitalOceanStoreRobot()
        {
            Robot = "/digitalocean/store";
        }
    }
}
