using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/minio-store/">/minio/store</a> Robot.
    /// </summary>
    public class MinioStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The permissions used for this file.
        /// <para>Default: <c>public-read</c>.</para>
        /// </summary>
        [JsonProperty("acl")]
        public string Acl { get; set; }

        /// <summary>
        /// An object containing a list of headers to be set for this file on MinIO Spaces, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// Object Metadata can be specified using <c>x-amz-meta-*</c> headers.
        /// </summary>
        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// This parameter provides signed URLs in the result JSON (in the <c>signed_ssl_url</c> property). The number that you set this parameter to is the URL expiry time in seconds.
        /// </summary>
        [JsonProperty("sign_urls_for")]
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// MinIO bucket.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// MinIO key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// MinIO secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// MinIO host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/minio-store/">/minio/store</a> Robot.
        /// </summary>
        public MinioStoreRobot()
        {
            Robot = "/minio/store";
        }
    }
}
