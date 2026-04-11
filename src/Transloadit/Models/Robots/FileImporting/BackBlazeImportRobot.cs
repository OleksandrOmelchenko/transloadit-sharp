using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/backblaze-import/">/backblaze/import</a> Robot.
    /// </summary>
    public class BackBlazeImportRobot : ImportRobotBase
    {
        /// <summary>
        /// Setting this to <c>true</c> will enable importing files from subdirectories and sub-subdirectories (etc.) of the given path.
        /// </summary>
        [JsonProperty("recursive")]
        public bool? Recursive { get; set; }

        /// <summary>
        /// The name of the last file from the previous paging call. This tells the Robot to ignore all files up to and including this file.
        /// </summary>
        [JsonProperty("start_file_name")]
        public string StartFileName { get; set; }

        /// <summary>
        /// The pagination page size. This only works when <c>recursive</c> is <c>true</c> for now, in order to not break backwards 
        /// compatibility in non-recursive imports.
        /// <para>Default: <c>1000</c>.</para>
        /// </summary>
        [JsonProperty("files_per_page")]
        public int? FilesPerPage { get; set; }

        /// <summary>
        /// Backblaze bucket name.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// Backblaze App Key ID.
        /// </summary>
        [JsonProperty("app_key_id")]
        public string AppKeyId { get; set; }

        /// <summary>
        /// Backblaze App Key.
        /// </summary>
        [JsonProperty("app_key")]
        public string AppKey { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/backblaze-import/">/backblaze/import</a> Robot.
        /// </summary>
        public BackBlazeImportRobot()
        {
            Robot = "/backblaze/import";
        }
    }
}
