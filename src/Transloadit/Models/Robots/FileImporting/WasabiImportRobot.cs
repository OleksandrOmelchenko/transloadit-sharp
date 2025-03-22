namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/wasabi/import</c> Robot.
    /// </summary>
    public class WasabiImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Wasabi host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Wasabi user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Wasabi password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Initializes <c>/wasabi/import</c> Robot.
        /// </summary>
        public WasabiImportRobot()
        {
            Robot = "/wasabi/import";
        }
    }
}
