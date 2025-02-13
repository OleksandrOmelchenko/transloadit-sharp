namespace Transloadit.Models.Robots.FileExporting
{
    public class GoogleStorageStoreRobot : StoreRobotBase
    {
        public string Acl { get; set; }
        public string CacheControl { get; set; }
        public string UrlTemplate { get; set; }
        public string SslUrlTemplate { get; set; }

        public GoogleStorageStoreRobot()
        {
            Robot = "/google/store";
        }
    }
}
