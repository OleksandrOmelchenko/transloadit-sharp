using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    public class DigitalOceanStoreRobot : StoreRobotBase
    {
        public string UrlPrefix { get; set; }
        public string Acl { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        public DigitalOceanStoreRobot()
        {
            Robot = "/digitalocean/store";
        }
    }
}
