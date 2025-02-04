namespace Transloadit.Models.TemplateCredentials
{
    public class CreateSftpCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateSftpCredentialsRequest()
        {
            Type = "sftp";
        }

        public SftpCredentialsContent Content { get; set; }
    }

    public class SftpCredentialsContent
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string PublicKey { get; set; }
    }
}
