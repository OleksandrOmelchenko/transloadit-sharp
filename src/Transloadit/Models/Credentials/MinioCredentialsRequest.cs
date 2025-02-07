namespace Transloadit.Models.Credentials
{
    public class MinioCredentialsRequest : CredentialsRequestBase
    {
        public MinioCredentialsRequest()
        {
            Type = "minio";
        }

        public MinioCredentialsContent Content { get; set; }
    }

    public class MinioCredentialsContent
    {
        public string Bucket { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public string Host { get; set; }
    }
}
