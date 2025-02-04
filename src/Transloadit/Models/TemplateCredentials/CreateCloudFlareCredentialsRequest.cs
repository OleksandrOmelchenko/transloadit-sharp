namespace Transloadit.Models.TemplateCredentials
{
    public class CreateCloudFlareCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateCloudFlareCredentialsRequest()
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
