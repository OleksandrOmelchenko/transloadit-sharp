namespace Transloadit.Models.TemplateCredentials
{
    public class CreateHttpCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateHttpCredentialsRequest()
        {
            Type = "http";
        }

        public HttpCredentialsContent Content { get; set; }
    }

    public class HttpCredentialsContent
    {
        public string Headers { get; set; }
    }
}
