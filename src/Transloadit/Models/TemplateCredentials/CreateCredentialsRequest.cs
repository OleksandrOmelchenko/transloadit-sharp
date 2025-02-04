using System.Collections.Generic;

namespace Transloadit.Models.TemplateCredentials
{
    public abstract class CreateCredentialsRequestBase : BaseParams
    {
        public string Name { get; set; }
        public string Type { get; protected set; }
    }

    public class CreateGenericCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateGenericCredentialsRequest(string type)
        {
            Type = type;
        }

        public Dictionary<string, string> Content { get; set; }
    }

    public class CreateCredentialsRequest<T> : CreateCredentialsRequestBase
    {
        public T Content { get; set; }
    }

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

    public class CreateFtpCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateFtpCredentialsRequest()
        {
            Type = "ftp";
        }

        public S3CredentialsContent Content { get; set; }
    }

    public class FtpCredentialsContent
    {
        public string Key { get; set; }
        public string Secret { get; set; }
        public string Bucket { get; set; }
        public string BucketRegion { get; set; }
    }
}
