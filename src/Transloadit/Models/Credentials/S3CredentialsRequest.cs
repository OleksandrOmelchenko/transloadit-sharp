using Newtonsoft.Json;

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
        [JsonProperty("content")]
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
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// S3 secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// S3 bucket name.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// S3 bucket region.
        /// </summary>
        [JsonProperty("bucket_region")]
        public string BucketRegion { get; set; }
    }
}
