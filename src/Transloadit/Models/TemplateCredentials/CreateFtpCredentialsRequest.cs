namespace Transloadit.Models.TemplateCredentials
{
    public class CreateFtpCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateFtpCredentialsRequest()
        {
            Type = "ftp";
        }

        public FtpCredentialsContent Content { get; set; }
    }

    public class FtpCredentialsContent
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
