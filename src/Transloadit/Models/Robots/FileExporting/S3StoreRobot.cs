using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    public class S3StoreRobot : StoreRobotBase
    {
        public string UrlPrefix { get; set; }
        public string Acl { get; set; }
        public bool? CheckIntegrity { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, object> Tags { get; set; }
        public string Host { get; set; }
        public bool? NoVhost { get; set; }
        public int? SignUrlsFor { get; set; }

        public S3StoreRobot()
        {
            Robot = "/s3/store";
        }
    }
}
