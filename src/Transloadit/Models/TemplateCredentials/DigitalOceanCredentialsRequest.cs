namespace Transloadit.Models.TemplateCredentials
{
    public class DigitalOceanCredentialsRequest : CredentialsRequestBase
    {
        public DigitalOceanCredentialsRequest()
        {
            Type = "digitalocean";
        }

        public DigitalOceanCredentialsContent Content { get; set; }
    }

    public class DigitalOceanCredentialsContent
    {
        public string Space { get; set; }
        public string Region { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
    }
}
