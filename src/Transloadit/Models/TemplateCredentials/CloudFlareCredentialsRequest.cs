namespace Transloadit.Models.TemplateCredentials
{
    public class CloudFlareCredentialsRequest : CredentialsRequestBase
    {
        public CloudFlareCredentialsRequest()
        {
            Type = "cloudflare";
        }

        public CloudFlareCredentialsContent Content { get; set; }
    }

    public class CloudFlareCredentialsContent
    {
        public string Bucket { get; set; }
        public string Host { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
    }
}
