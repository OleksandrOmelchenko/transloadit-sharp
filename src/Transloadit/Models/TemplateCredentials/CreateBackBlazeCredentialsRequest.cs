namespace Transloadit.Models.TemplateCredentials
{
    public class CreateBackBlazeCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateBackBlazeCredentialsRequest()
        {
            Type = "backblaze";
        }

        public BackBlazeCredentialsContent Content { get; set; }
    }

    public class BackBlazeCredentialsContent
    {
        public string Bucket { get; set; }
        public string AppKeyId { get; set; }
        public string AppKey { get; set; }
    }
}
