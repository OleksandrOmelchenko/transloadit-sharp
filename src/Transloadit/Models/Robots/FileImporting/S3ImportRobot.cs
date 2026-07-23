using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/s3-import/">/s3/import</a> Robot.
    /// </summary>
    public class S3ImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// S3 key.
        /// </summary>
        [TransloaditJsonName("key")]
        public string Key { get; set; }

        /// <summary>
        /// S3 secret.
        /// </summary>
        [TransloaditJsonName("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// S3 bucket name.
        /// </summary>
        [TransloaditJsonName("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// S3 bucket region.
        /// </summary>
        [TransloaditJsonName("bucket_region")]
        public string BucketRegion { get; set; }

        /// <summary>
        /// If set to <c>true</c>, the Robot will not import the actual files yet, but instead returns an empty file stub that includes a URL from where the file can be imported by subsequent Robots.
        /// This should only be set if all subsequent Steps use Robots that support file stubs.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [TransloaditJsonName("return_file_stubs")]
        public bool? ReturnFileStubs { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/s3-import/">/s3/import</a> Robot.
        /// </summary>
        public S3ImportRobot()
        {
            Robot = "/s3/import";
        }
    }
}
