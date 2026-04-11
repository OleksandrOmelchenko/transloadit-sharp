using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/tigris-import/">/tigris/import</a> Robot.
    /// </summary>
    public class TigrisImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// If set to <c>true</c>, the Robot will not yet import the actual files but instead return an empty file stub that includes a URL 
        /// from where the file can be imported by subsequent Robots. This is useful for cases where subsequent Steps need more control over 
        /// the import process, such as with 🤖/video/ondemand. This parameter should only be set if all subsequent Steps use Robots 
        /// that support file stubs.
        /// </summary>
        [JsonProperty("return_file_stubs")]
        public bool? ReturnFileStubs { get; set; }

        /// <summary>
        /// The name of the bucket to which the file is exported.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// The custom domain for Tigris bucket location.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Tigris access key ID.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Tigris secret access Key.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/tigris-import/">/tigris/import</a> Robot.
        /// </summary>
        public TigrisImportRobot()
        {
            Robot = "/tigris/import";
        }
    }
}
