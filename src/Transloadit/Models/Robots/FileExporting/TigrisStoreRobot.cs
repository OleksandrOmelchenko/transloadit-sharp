using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/tigris/store</c> Robot.
    /// </summary>
    public class TigrisStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The permissions used for this file: <c>private</c> or <c>public-read</c>.
        /// <para>Default: <c>public-read</c>.</para>
        /// </summary>
        public string Acl { get; set; }

        /// <summary>
        /// An object containing a list of headers to be set for this file on Tigris, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// Object Metadata can be specified using <c>x-amz-meta-*</c> headers.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// This parameter provides signed URLs in the result JSON (in the <c>signed_ssl_url</c> property). 
        /// The number that you set this parameter to is the URL expiry time in seconds.
        /// </summary>
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// The name of the bucket to which the file is exported.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// The custom domain for Tigris bucket location.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Tigris access key ID.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Tigris secret access Key.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <c>/tigris/store</c> Robot.
        /// </summary>
        public TigrisStoreRobot()
        {
            Robot = "/tigris/store";
        }
    }
}
