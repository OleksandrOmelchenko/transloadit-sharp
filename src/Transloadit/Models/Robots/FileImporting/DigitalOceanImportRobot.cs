using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/digitalocean-import/">/digitalocean/import</a> Robot.
    /// </summary>
    public class DigitalOceanImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// DigitalOcean space name.
        /// </summary>
        [JsonProperty("space")]
        public string Space { get; set; }

        /// <summary>
        /// DigitalOcean space region.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// DigitalOcean space key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// DigitalOcean space secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// If set to <c>true</c>, the Robot will not import the actual files yet, but instead returns an empty file stub that includes a URL from where the file can be imported by subsequent Robots.
        /// This should only be set if all subsequent Steps use Robots that support file stubs.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [JsonProperty("return_file_stubs")]
        public bool? ReturnFileStubs { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/digitalocean-import/">/digitalocean/import</a> Robot.
        /// </summary>
        public DigitalOceanImportRobot()
        {
            Robot = "/digitalocean/import";
        }
    }
}
