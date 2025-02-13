using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    public class AzureStoreRobot : StoreRobotBase
    {
        public string ContentType { get; set; }
        public string ContentEncoding { get; set; }
        public string ContentLanguage { get; set; }
        public string CacheControl { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public int? SasExpiresIn { get; set; }
        public string SasPermissions { get; set; }

        public AzureStoreRobot()
        {
            Robot = "/azure/store";
        }
    }
}
