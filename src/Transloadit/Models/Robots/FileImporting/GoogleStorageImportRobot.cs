namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/google/import</c> Robot.
    /// </summary>
    public class GoogleStorageImportRobot : ImportRobotBase
    {
        public bool? Recursive { get; set; }
        public string NextPageToken { get; set; }
        public int? FilesPerPage { get; set; }

        /// <summary>
        /// Initializes <c>/google/import</c> Robot.
        /// </summary>
        public GoogleStorageImportRobot()
        {
            Robot = "/google/import";
        }
    }
}
