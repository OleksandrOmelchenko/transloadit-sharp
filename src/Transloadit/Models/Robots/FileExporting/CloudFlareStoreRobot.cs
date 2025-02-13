using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    public class CloudFlareStoreRobot : StoreRobotBase
    {
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        public CloudFlareStoreRobot()
        {
            Robot = "/cloudflare/store";
        }
    }
}
