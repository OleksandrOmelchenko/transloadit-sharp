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
        public string AccountType { get; set; }

        /// <summary>
        /// Rackspace Cloud Files data center.
        /// </summary>
        public string DataCenter { get; set; }

        /// <summary>
        /// Rackspace Cloud Files container.
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// Rackspace Cloud Files user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Rackspace Cloud Files key.
        /// </summary>
        public string Key { get; set; }
    }
}
