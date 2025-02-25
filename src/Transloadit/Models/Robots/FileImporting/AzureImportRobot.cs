namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/azure/import</c> Robot.
    /// </summary>
    public class AzureImportRobot : ImportRobotBase
    {
        public string NextPageToken { get; set; }
        public int? FilesPerPage { get; set; }

        //public bool Recursive { get; set; } //not in docs, but mentioned in other field

        /// <summary>
        /// Initializes <c>/azure/import</c> Robot.
        /// </summary>
        public AzureImportRobot()
        {
            Robot = "/azure/import";
        }

    }
}
