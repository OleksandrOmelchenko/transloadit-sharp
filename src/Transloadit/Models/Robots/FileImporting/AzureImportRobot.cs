namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/azure/import</c> Robot.
    /// </summary>
    public class AzureImportRobot : ImportRobotBase
    {
        public string NextPageToken { get; set; }

        /// <summary>
        /// The pagination page size. This only works when <c>recursive</c> is <c>true</c> for now, in order to not break backwards 
        /// compatibility in non-recursive imports.
        /// <para>Default: <c>1000</c>.</para>
        /// </summary>
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
