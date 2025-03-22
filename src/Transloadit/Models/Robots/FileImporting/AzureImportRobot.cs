namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/azure/import</c> Robot.
    /// </summary>
    public class AzureImportRobot : ImportRobotBase
    {
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

        //public bool Recursive { get; set; } //not in docs, but mentioned in other field

        /// <summary>
        /// Azure blob storage account.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Azure blob storage key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Azure blob storage container.
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// Initializes <c>/azure/import</c> Robot.
        /// </summary>
        public AzureImportRobot()
        {
            Robot = "/azure/import";
        }

    }
}
