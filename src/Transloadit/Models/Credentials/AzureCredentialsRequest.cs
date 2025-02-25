namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Azure credentials request.
    /// </summary>
    public class AzureCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Azure credentials request.
        /// </summary>
        public AzureCredentialsRequest()
        {
            Type = "azure";
        }

        /// <summary>
        /// Azure credentials content.
        /// </summary>
        public AzureCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Azure credentials.
    /// </summary>
    public class AzureCredentialsContent
    {
        /// <summary>
        /// Azure blob storage account.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Azure blob storage key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Azure blob storage container.
        /// </summary>
        public string Container { get; set; }
    }
}
