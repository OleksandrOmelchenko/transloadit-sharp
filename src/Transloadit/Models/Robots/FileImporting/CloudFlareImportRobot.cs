namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/cloudflare/import</c> Robot.
    /// </summary>
    public class CloudFlareImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Cloudflare bucket.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// Cloudflare host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Cloudflare key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Cloudflare secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <c>/cloudflare/import</c> Robot.
        /// </summary>
        public CloudFlareImportRobot()
        {
            Robot = "/cloudflare/import";
        }
    }
}
