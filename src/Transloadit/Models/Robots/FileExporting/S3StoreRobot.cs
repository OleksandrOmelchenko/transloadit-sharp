using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/s3/store</c> Robot.
    /// </summary>
    public class S3StoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The URL prefix used for the returned URL, such as <c>http://my.cdn.com/some/path/</c>.
        /// <para>Default: <c>http://{bucket}.s3.amazonaws.com/</c>.</para>
        /// </summary>
        public string UrlPrefix { get; set; }

        /// <summary>
        /// The permissions used for this file.
        /// <para>Default: <c>public-read</c>.</para>
        /// </summary>
        public string Acl { get; set; }

        /// <summary>
        /// Calculate and submit the file's checksum in order for S3 to verify its integrity after uploading, which can help with occasional 
        /// file corruption issues. Enabling this option adds to the overall execution time, as integrity checking can be CPU intensive, 
        /// especially for larger files.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? CheckIntegrity { get; set; }

        /// <summary>
        /// An object containing a list of headers to be set for this file on S3, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// Object Metadata can be specified using <c>x-amz-meta-*</c> headers.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Object tagging allows you to categorize storage. You can associate up to 10 tags with an object. Tags that are associated with an object must have unique tag keys.
        /// </summary>
        public Dictionary<string, object> Tags { get; set; }

        /// <summary>
        /// The host of the storage service used. This only needs to be set when the storage service used is not Amazon S3, but has a compatible 
        /// API (such as hosteurope.de). The default protocol used is HTTP, for anything else the protocol needs to be explicitly specified. 
        /// For example, prefix the host with <c>https://</c> or <c>s3://</c> to use either respective protocol.
        /// <para>Default: <c>s3.amazonaws.com</c>.</para>
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Set to <c>true</c> if you use a custom host and run into access denied errors.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? NoVhost { get; set; }

        /// <summary>
        /// This parameter provides signed URLs in the result JSON (in the <c>signed_url</c> and <c>signed_ssl_url</c> properties). 
        /// The number that you set this parameter to is the URL expiry time in seconds. If this parameter is not used, no URL signing is done.
        /// </summary>
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Initializes <c>/s3/store</c> Robot.
        /// </summary>
        public S3StoreRobot()
        {
            Robot = "/s3/store";
        }
    }
}
