using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/ftp-import/">/ftp/import</a> Robot.
    /// </summary>
    public class FtpImportRobot : RobotBase
    {
        /// <summary>
        /// Template credentials name.
        /// </summary>
        [JsonProperty("credentials")]
        public string Credentials { get; set; }

        /// <summary>
        /// The path to the specific file or directory.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// The port to use for the FTP connection.
        /// <para>Default: <c>21</c>.</para>
        /// </summary>
        [JsonProperty("port")]
        public int? Port { get; set; }

        /// <summary>
        /// Determines if passive mode should be used for the FTP connection.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        [JsonProperty("passive_mode")]
        public bool? PassiveMode { get; set; }

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
        /// Initializes <a href="https://transloadit.com/docs/robots/ftp-import/">/ftp/import</a> Robot.
        /// </summary>
        public FtpImportRobot()
        {
            Robot = "/ftp/import";
        }
    }
}
