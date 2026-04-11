using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/ftp-store/">/ftp/store</a> Robot.
    /// </summary>
    public class FtpStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The port to use for the FTP connection.
        /// <para>Default: <c>21</c>.</para>
        /// </summary>
        [JsonProperty("port")]
        public int? Port { get; set; }

        /// <summary>
        /// The URL of the file in the result JSON. 
        /// </summary>
        [JsonProperty("url_template")]
        public string UrlTemplate { get; set; }

        /// <summary>
        /// The SSL URL of the file in the result JSON.
        /// </summary>
        [JsonProperty("ssl_url_template")]
        public string SslUrlTemplate { get; set; }

        /// <summary>
        /// Determines whether to establish a secure connection to the FTP server using SSL.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [JsonProperty("secure")]
        public bool? Secure { get; set; }

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

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/ftp-store/">/ftp/store</a> Robot.
        /// </summary>
        public FtpStoreRobot()
        {
            Robot = "/ftp/store";
        }
    }
}
