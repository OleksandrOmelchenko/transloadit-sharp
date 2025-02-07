namespace Transloadit.Models.Credentials
{
    public class FtpCredentialsRequest : CredentialsRequestBase
    {
        public FtpCredentialsRequest()
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
