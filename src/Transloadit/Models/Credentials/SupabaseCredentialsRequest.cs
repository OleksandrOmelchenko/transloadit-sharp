namespace Transloadit.Models.Credentials
{
    public class SupabaseCredentialsRequest : CredentialsRequestBase
    {
        public SupabaseCredentialsRequest()
        {
            Type = "supabase";
        }

        public SupabaseCredentialsContent Content { get; set; }
    }

    public class SupabaseCredentialsContent
    {
        public string Bucket { get; set; }
        public string Host { get; set; }
        public string BucketRegion { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
    }
}
