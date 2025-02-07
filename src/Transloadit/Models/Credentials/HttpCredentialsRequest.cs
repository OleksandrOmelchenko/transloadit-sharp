namespace Transloadit.Models.Credentials
{
    public class HttpCredentialsRequest : CredentialsRequestBase
    {
        public HttpCredentialsRequest()
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
