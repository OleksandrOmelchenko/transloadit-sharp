using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/azure-import/">/azure/import</a> Robot.
    /// </summary>
    public class AzureImportRobot : ImportRobotBase
    {
        /// <summary>
        /// A string token used for pagination. The returned files of one paginated call have the next page token inside of their 
        /// meta data, which needs to be used for the subsequent paging call.
        /// </summary>
        [JsonProperty("next_page_token")]
        public string NextPageToken { get; set; }

        /// <summary>
        /// The pagination page size.
        /// <para>Default: <c>1000</c>.</para>
        /// </summary>
        [JsonProperty("files_per_page")]
        public int? FilesPerPage { get; set; }

        /// <summary>
        /// Azure blob storage account.
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// Azure blob storage key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Azure blob storage container.
        /// </summary>
        [JsonProperty("container")]
        public string Container { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/azure-import/">/azure/import</a> Robot.
        /// </summary>
        public AzureImportRobot()
        {
            Robot = "/azure/import";
        }
    }
}
