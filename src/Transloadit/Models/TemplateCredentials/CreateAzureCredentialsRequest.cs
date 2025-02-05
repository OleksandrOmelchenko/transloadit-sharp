namespace Transloadit.Models.TemplateCredentials
{
    public class CreateAzureCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateAzureCredentialsRequest()
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
