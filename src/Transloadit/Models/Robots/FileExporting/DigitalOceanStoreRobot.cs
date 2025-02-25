using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/digitalocean/store</c> Robot.
    /// </summary>
    public class DigitalOceanStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The URL prefix used for the returned URL, such as <c>https://my.cdn.com/some/path</c>.
        /// <para>Default: <c>https://{space}.{region}.digitaloceanspaces.com/</c>.</para>
        /// </summary>
        public string UrlPrefix { get; set; }

        /// <summary>
        /// The permissions used for this file.
        /// <para>Default: <c>public-read</c>.</para>
        /// </summary>
        public string Acl { get; set; }

        /// <summary>
        /// An object containing a list of headers to be set for this file on DigitalOcean Spaces, such as <c>{ FileURL: "${file.url_name}" }</c>. 
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
        /// Initializes <c>/digitalocean/store</c> Robot.
        /// </summary>
        public DigitalOceanStoreRobot()
        {
            Robot = "/digitalocean/store";
        }
    }
}
