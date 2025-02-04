namespace Transloadit.Models.TemplateCredentials
{
    public class CreateSwiftCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateSwiftCredentialsRequest()
        {
            Type = "swift";
        }

        public SwiftCredentialsContent Content { get; set; }
    }

    public class SwiftCredentialsContent
    {
        public string Bucket { get; set; }
        public string Host { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
    }
}
