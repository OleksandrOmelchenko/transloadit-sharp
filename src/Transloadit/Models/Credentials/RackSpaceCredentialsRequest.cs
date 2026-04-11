using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Rackspace credentials request.
    /// </summary>
    public class RackspaceCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Rackspace credentials request.
        /// </summary>
        public RackspaceCredentialsRequest()
        {
            Type = "rackspace";
        }

        /// <summary>
        /// Rackspace credentials content.
        /// </summary>
        [JsonProperty("content")]
        public RackSpaceCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Rackspace credentials.
    /// </summary>
    public class RackSpaceCredentialsContent
    {
        /// <summary>
        /// Rackspace Cloud Files account type.
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// Rackspace Cloud Files data center.
        /// </summary>
        [JsonProperty("data_center")]
        public string DataCenter { get; set; }

        /// <summary>
        /// Rackspace Cloud Files container.
        /// </summary>
        [JsonProperty("container")]
        public string Container { get; set; }

        /// <summary>
        /// Rackspace Cloud Files user.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        /// Rackspace Cloud Files key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
