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
        /// "Ignore errors" mode. Possible array members are <c>meta</c> and <c>import</c>. 
        /// You might see an error when trying to extract metadata from your imported files. This happens, for example, for files with a size of zero bytes. Including <c>"meta"</c> in the array will cause the Robot to not stop the import (and the entire Assembly) when that happens.
        /// Including <c>"import"</c> in the array will ensure the Robot does not cease to function on any import errors either.
        /// Setting this parameter to <c>true</c> will set it to <c>["meta", "import"]</c> internally.
        /// </summary>
        [JsonProperty("ignore_errors")]
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }

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
