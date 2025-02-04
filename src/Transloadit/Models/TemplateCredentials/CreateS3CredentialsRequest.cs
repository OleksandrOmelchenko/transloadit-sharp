namespace Transloadit.Models.TemplateCredentials
{
    public class CreateS3CredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateS3CredentialsRequest()
        {
            Type = "s3";
        }

        public S3CredentialsContent Content { get; set; }
    }

    public class S3CredentialsContent
    {
        public string Key { get; set; }
        public string Secret { get; set; }
        public string Bucket { get; set; }
        public string BucketRegion { get; set; }
    }
}
