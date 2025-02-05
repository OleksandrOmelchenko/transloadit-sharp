namespace Transloadit.Models.TemplateCredentials
{
    public class CreateWasabiCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateWasabiCredentialsRequest()
        {
            Type = "wasabi";
        }

        public WasabiCredentialsContent Content { get; set; }
    }

    public class WasabiCredentialsContent
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
