using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Cloudflare credentials request.
    /// </summary>
    public class CloudflareCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Cloudflare credentials request.
        /// </summary>
        public CloudflareCredentialsRequest()
        {
            Type = "cloudflare";
        }

        /// <summary>
        /// Cloudflare credentials content.
        /// </summary>
        [JsonProperty("content")]
        public CloudFlareCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Cloudflare credentials.
    /// </summary>
    public class CloudFlareCredentialsContent
    {
        /// <summary>
        /// Cloudflare bucket.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// Cloudflare host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Cloudflare key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Cloudflare secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
