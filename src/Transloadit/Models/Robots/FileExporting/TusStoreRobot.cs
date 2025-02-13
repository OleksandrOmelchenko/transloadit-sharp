using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    public class TusStoreRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Endpoint { get; set; }
        public string Credentials { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public string UrlTemplate { get; set; }
        public string SslUrlTemplate { get; set; }

        public TusStoreRobot()
        {
            Robot = "/tus/store";
        }
    }
}
