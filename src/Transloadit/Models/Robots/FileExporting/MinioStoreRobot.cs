using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/minio/store</c> Robot.
    /// </summary>
    public class MinioStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The permissions used for this file.
        /// <para>Default: <c>public-read</c>.</para>
        /// </summary>
        public string Acl { get; set; }

        /// <summary>
        /// An object containing a list of headers to be set for this file on MinIO Spaces, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// Object Metadata can be specified using <c>x-amz-meta-*</c> headers.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// This parameter provides signed URLs in the result JSON (in the <c>signed_ssl_url</c> property). The number that you set this parameter to is the URL expiry time in seconds.
        /// </summary>
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Initializes <c>/minio/store</c> Robot.
        /// </summary>
        public MinioStoreRobot()
        {
            Robot = "/minio/store";
        }
    }
}
