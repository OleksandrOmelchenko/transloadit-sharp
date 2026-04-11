using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/sftp-import/">/sftp/import</a> Robot.
    /// </summary>
    public class SftpImportRobot : RobotBase
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
        /// The path on your SFTP server where to search for files.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// The port to use for the connection.
        /// <para>Default: <c>22</c>.</para>
        /// </summary>
        [JsonProperty("port")]
        public int? Port { get; set; }

        /// <summary>
        /// The directory on the SFTP server to import files from.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// The hostname or IP address of the SFTP server.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// The authentication key used to connect to the SFTP server.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// The authentication secret used to connect to the SFTP server.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/sftp-import/">/sftp/import</a> Robot.
        /// </summary>
        public SftpImportRobot()
        {
            Robot = "/sftp/import";
        }
    }
}
