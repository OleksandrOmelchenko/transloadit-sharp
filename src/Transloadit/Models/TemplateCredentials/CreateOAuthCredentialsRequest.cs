namespace Transloadit.Models.TemplateCredentials
{
    public class CreateOAuthCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateOAuthCredentialsRequest()
        {
            Type = "companion";
        }

        public OAuthCredentialsContent Content { get; set; }
    }

    public class OAuthCredentialsContent
    {
        public string Provider { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
    }
}
