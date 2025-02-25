namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents S3 credentials request.
    /// </summary>
    public class S3CredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes S3 credentials request.
        /// </summary>
        public S3CredentialsRequest()
        {
            Type = "s3";
        }

        /// <summary>
        /// S3 credentials content.
        /// </summary>
        public S3CredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents S3 credentials.
    /// </summary>
    public class S3CredentialsContent
    {
        /// <summary>
        /// S3 key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// S3 secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// S3 bucket name.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// S3 bucket region.
        /// </summary>
        public string BucketRegion { get; set; }
    }
}
