namespace Transloadit.Models.TemplateCredentials
{
    public class CreateDigitalOceanCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateDigitalOceanCredentialsRequest()
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
