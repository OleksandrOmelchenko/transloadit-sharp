using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/google/store</c> Robot.
    /// </summary>
    public class GoogleStorageStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The permissions used for this file.
        /// <para>Default: <c>public-read</c>.</para>
        /// </summary>
        [JsonProperty("acl")]
        public string Acl { get; set; }

        /// <summary>
        /// The <c>Cache-Control</c> header determines how long browsers are allowed to cache your object for. Values specified with 
        /// this parameter will be added to the object's metadata under the <c>Cache-Control</c> header.
        /// </summary>
        [JsonProperty("cache_control")]
        public string CacheControl { get; set; }

        /// <summary>
        /// The URL of the file in the result JSON.
        /// </summary>
        [JsonProperty("url_template")]
        public string UrlTemplate { get; set; }

        /// <summary>
        /// The SSL URL of the file in the result JSON.
        /// </summary>
        [JsonProperty("ssl_url_template")]
        public string SslUrlTemplate { get; set; }

        /// <summary>
        /// Initializes <c>/google/store</c> Robot.
        /// </summary>
        public GoogleStorageStoreRobot()
        {
            Robot = "/google/store";
        }
    }
}
