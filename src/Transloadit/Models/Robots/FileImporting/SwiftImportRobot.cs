namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/swift/import</c> Robot.
    /// </summary>
    public class SwiftImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Swift bucket.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// Swift host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Swift key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Swift secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <c>/swift/import</c> Robot.
        /// </summary>
        public SwiftImportRobot()
        {
            Robot = "/swift/import";
        }
    }
}
