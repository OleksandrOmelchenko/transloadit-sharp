namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents SFTP credentials request.
    /// </summary>
    public class SftpCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes SFTP credentials request.
        /// </summary>
        public SftpCredentialsRequest()
        {
            Type = "sftp";
        }

        /// <summary>
        /// SFTP credentials content.
        /// </summary>
        public SftpCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents SFTP credentials.
    /// </summary>
    public class SftpCredentialsContent
    {
        /// <summary>
        /// SFTP host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// SFTP port.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// SFTP user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// SFTP public key.
        /// </summary>
        public string PublicKey { get; set; }
    }
}
