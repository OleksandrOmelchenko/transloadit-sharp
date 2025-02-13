using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    public class WasabiStoreRobot : StoreRobotBase
    {
        public string Acl { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        public WasabiStoreRobot()
        {
            Robot = "/wasabi/store";
        }
    }
}
