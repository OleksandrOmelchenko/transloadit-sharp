namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/google/store</c> Robot.
    /// </summary>
    public class GoogleStorageStoreRobot : StoreRobotBase
    {
        public string Acl { get; set; }
        public string CacheControl { get; set; }
        public string UrlTemplate { get; set; }
        public string SslUrlTemplate { get; set; }

        /// <summary>
        /// Initializes <c>/google/store</c> Robot.
        /// </summary>
        public GoogleStorageStoreRobot()
        {
            Robot = "/google/store";
        }
    }
}
