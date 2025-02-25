namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/backblaze/import</c> Robot.
    /// </summary>
    public class BackBlazeImportRobot : ImportRobotBase
    {
        public bool? Recursive { get; set; }
        public string StartFileName { get; set; }
        public int? FilesPerPage { get; set; }

        /// <summary>
        /// Initializes <c>/backblaze/import</c> Robot.
        /// </summary>
        public BackBlazeImportRobot()
        {
            Robot = "/backblaze/import";
        }
    }
}
