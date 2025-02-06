namespace Transloadit.Models.TemplateCredentials
{
    public class AzureCredentialsRequest : CredentialsRequestBase
    {
        public AzureCredentialsRequest()
        {
            Type = "azure";
        }

        public AzureCredentialsContent Content { get; set; }
    }

    public class AzureCredentialsContent
    {
        public string Account { get; set; }
        public string Key { get; set; }
        public string Container { get; set; }
    }
}
