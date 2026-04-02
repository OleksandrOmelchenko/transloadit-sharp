using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents FTP credentials request.
    /// </summary>
    public class FtpCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes FTP credentials request.
        /// </summary>
        public FtpCredentialsRequest()
        {
            Type = "ftp";
        }

        /// <summary>
        /// FTP credentials content.
        /// </summary>
        [JsonProperty("content")]
        public FtpCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents FTP credentials.
    /// </summary>
    public class FtpCredentialsContent
    {
        /// <summary>
        /// FTP host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// FTP user.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        /// FTP password.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
