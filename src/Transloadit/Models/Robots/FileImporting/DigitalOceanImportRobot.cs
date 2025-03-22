namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/digitalocean/import</c> Robot.
    /// </summary>
    public class DigitalOceanImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// DigitalOcean space name.
        /// </summary>
        public string Space { get; set; }

        /// <summary>
        /// DigitalOcean space region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// DigitalOcean space key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// DigitalOcean space secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <c>/digitalocean/import</c> Robot.
        /// </summary>
        public DigitalOceanImportRobot()
        {
            Robot = "/digitalocean/import";
        }
    }
}
