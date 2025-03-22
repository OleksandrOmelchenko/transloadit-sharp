namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/ftp/store</c> Robot.
    /// </summary>
    public class FtpStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The port to use for the FTP connection.
        /// <para>Default: <c>21</c>.</para>
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// The URL of the file in the result JSON. 
        /// </summary>
        public string UrlTemplate { get; set; }

        /// <summary>
        /// The SSL URL of the file in the result JSON.
        /// </summary>
        public string SslUrlTemplate { get; set; }

        /// <summary>
        /// Determines whether to establish a secure connection to the FTP server using SSL.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Secure { get; set; }

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

        /// <summary>
        /// Initializes <c>/ftp/store</c> Robot.
        /// </summary>
        public FtpStoreRobot()
        {
            Robot = "/ftp/store";
        }
    }
}
