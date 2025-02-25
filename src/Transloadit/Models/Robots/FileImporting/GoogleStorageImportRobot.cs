namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/google/import</c> Robot.
    /// </summary>
    public class GoogleStorageImportRobot : ImportRobotBase
    {
        /// <summary>
        /// Setting this to <c>true</c> will enable importing files from subdirectories and sub-subdirectories (etc.) of the given path.
        /// </summary>
        public bool? Recursive { get; set; }

        /// <summary>
        /// A string token used for pagination. The returned files of one paginated call have the next page token inside of their 
        /// meta data, which needs to be used for the subsequent paging call.
        /// </summary>
        public string NextPageToken { get; set; }

        /// <summary>
        /// The pagination page size. This only works when <c>recursive</c> is <c>true</c> for now, in order to not break backwards 
        /// compatibility in non-recursive imports.
        /// <para>Default: <c>1000</c>.</para>
        /// </summary>
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
