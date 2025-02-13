using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    public class BackBlazeStoreRobot : StoreRobotBase
    {
        public Dictionary<string, string> Headers { get; set; }

        public BackBlazeStoreRobot()
        {
            Robot = "/backblaze/store";
        }
    }
}
