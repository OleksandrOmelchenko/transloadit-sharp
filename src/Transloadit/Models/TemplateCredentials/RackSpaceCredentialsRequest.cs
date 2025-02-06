namespace Transloadit.Models.TemplateCredentials
{
    public class RackSpaceCredentialsRequest : CredentialsRequestBase
    {
        public RackSpaceCredentialsRequest()
        {
            Type = "rackspace";
        }

        public RackSpaceCredentialsContent Content { get; set; }
    }

    public class RackSpaceCredentialsContent
    {
        public string AccountType { get; set; }
        public string DataCenter { get; set; }
        public string Container { get; set; }
        public string User { get; set; }
        public string Key { get; set; }
    }
}
