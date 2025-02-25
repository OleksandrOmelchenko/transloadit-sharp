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
        public string Bucket { get; set; }

        /// <summary>
        /// Supabase host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Supabase bucket region.
        /// </summary>
        public string BucketRegion { get; set; }

        /// <summary>
        /// Supabase key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Supabase secret.
        /// </summary>
        public string Secret { get; set; }
    }
}
