using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/sftp-store/">/sftp/store</a> Robot.
    /// </summary>
    public class SftpStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The URL of the file in the result JSON.
        /// </summary>
        [TransloaditJsonName("url_template")]
        public string UrlTemplate { get; set; }

        /// <summary>
        /// The SSL URL of the file in the result JSON.
        /// </summary>
        [TransloaditJsonName("ssl_url_template")]
        public string SslUrlTemplate { get; set; }

        /// <summary>
        /// This optional parameter controls how an uploaded file's permission bits are set. You can use any string format that the chmod 
        /// command would accept, such as <c>755</c>. If you don't specify this option, the file's permission bits aren't changed at all, 
        /// meaning it's up to your server's configuration (e.g. umask).
        /// </summary>
        [TransloaditJsonName("file_chmod")]
        public string FileChmod { get; set; }

        /// <summary>
        /// SFTP host.
        /// </summary>
        [TransloaditJsonName("host")]
        public string Host { get; set; }

        /// <summary>
        /// SFTP port.
        /// </summary>
        [TransloaditJsonName("port")]
        public int? Port { get; set; }

        /// <summary>
        /// SFTP user.
        /// </summary>
        [TransloaditJsonName("user")]
        public string User { get; set; }

        /// <summary>
        /// SFTP public key.
        /// </summary>
        [TransloaditJsonName("public_key")]
        public string PublicKey { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/sftp-store/">/sftp/store</a> Robot.
        /// </summary>
        public SftpStoreRobot()
        {
            Robot = "/sftp/store";
        }
    }
}
