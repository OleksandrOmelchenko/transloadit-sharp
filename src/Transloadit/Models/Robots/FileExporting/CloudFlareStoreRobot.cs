using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/cloudflare/store</c> Robot.
    /// </summary>
    public class CloudFlareStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// A JavaScript object containing a list of metadata to be set for this file on cloudflare Spaces, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// Object Metadata can be specified using <c>x-amz-meta-*</c> headers.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// This parameter provides signed URLs in the result JSON (in the <c>signed_ssl_url</c> property). The number that you set 
        /// this parameter to is the URL expiry time in seconds. If this parameter is not used, no URL signing is done.
        /// </summary>
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Cloudflare bucket.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// Cloudflare host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Cloudflare key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Cloudflare secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <c>/cloudflare/store</c> Robot.
        /// </summary>
        public CloudFlareStoreRobot()
        {
            Robot = "/cloudflare/store";
        }
    }
}
