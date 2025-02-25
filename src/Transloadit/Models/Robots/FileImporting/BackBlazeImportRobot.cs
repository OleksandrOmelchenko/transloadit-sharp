namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/backblaze/import</c> Robot.
    /// </summary>
    public class BackBlazeImportRobot : ImportRobotBase
    {
        /// <summary>
        /// Setting this to <c>true</c> will enable importing files from subdirectories and sub-subdirectories (etc.) of the given path.
        /// </summary>
        public bool? Recursive { get; set; }

        /// <summary>
        /// The name of the last file from the previous paging call. This tells the Robot to ignore all files up to and including this file.
        /// </summary>
        public string StartFileName { get; set; }

        /// <summary>
        /// The pagination page size. This only works when <c>recursive</c> is <c>true</c> for now, in order to not break backwards 
        /// compatibility in non-recursive imports.
        /// <para>Default: <c>1000</c>.</para>
        /// </summary>
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
