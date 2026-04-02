using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Supabase credentials request.
    /// </summary>
    public class SupabaseCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Supabase credentials request.
        /// </summary>
        public SupabaseCredentialsRequest()
        {
            Type = "supabase";
        }

        /// <summary>
        /// Supabase credentials content.
        /// </summary>
        [JsonProperty("content")]
        public SupabaseCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Supabase credentials.
    /// </summary>
    public class SupabaseCredentialsContent
    {
        /// <summary>
        /// Supabase bucket.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// Supabase host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Supabase bucket region.
        /// </summary>
        [JsonProperty("bucket_region")]
        public string BucketRegion { get; set; }

        /// <summary>
        /// Supabase key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Supabase secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
