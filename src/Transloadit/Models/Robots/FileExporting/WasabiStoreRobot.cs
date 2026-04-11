using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/wasabi-store/">/wasabi/store</a> Robot.
    /// </summary>
    public class WasabiStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The permissions used for this file.
        /// <para>Default: <c>public-read</c>.</para>
        /// </summary>
        [JsonProperty("acl")]
        public string Acl { get; set; }

        /// <summary>
        /// An object containing a list of headers to be set for this file on Wasabi Spaces, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// Object Metadata can be specified using <c>x-amz-meta-*</c> headers.
        /// </summary>
        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// This parameter provides signed URLs in the result JSON (in the <c>signed_ssl_url</c> property). The number that you set this parameter 
        /// to is the URL expiry time in seconds. If this parameter is not used, no URL signing is done.
        /// </summary>
        [JsonProperty("sign_urls_for")]
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Wasabi host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Wasabi user.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        /// Wasabi password.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/wasabi-store/">/wasabi/store</a> Robot.
        /// </summary>
        public WasabiStoreRobot()
        {
            Robot = "/wasabi/store";
        }
    }
}
