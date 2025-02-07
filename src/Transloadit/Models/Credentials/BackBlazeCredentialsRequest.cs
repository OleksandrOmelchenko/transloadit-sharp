namespace Transloadit.Models.Credentials
{
    public class BackBlazeCredentialsRequest : CredentialsRequestBase
    {
        public BackBlazeCredentialsRequest()
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
