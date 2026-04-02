using Newtonsoft.Json;

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
        [JsonProperty("content")]
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
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// SFTP port.
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; }

        /// <summary>
        /// SFTP user.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        /// SFTP public key.
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }
    }
}
