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
    }
}
