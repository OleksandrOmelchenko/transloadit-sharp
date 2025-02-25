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
        public string Host { get; set; }

        /// <summary>
        /// FTP user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// FTP password.
        /// </summary>
        public string Password { get; set; }
    }
}
