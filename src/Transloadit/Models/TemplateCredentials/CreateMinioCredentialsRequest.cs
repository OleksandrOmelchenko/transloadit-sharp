namespace Transloadit.Models.TemplateCredentials
{
    public class CreateMinioCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateMinioCredentialsRequest()
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
