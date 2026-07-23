using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/sftp-import/">/sftp/import</a> Robot.
    /// </summary>
    public class SftpImportRobot : RobotBase
    {
        /// <summary>
        /// Template credentials name.
        /// </summary>
        [TransloaditJsonName("credentials")]
        public string Credentials { get; set; }

        /// <summary>
        /// The path on your SFTP server where to search for files.
        /// </summary>
        [TransloaditJsonName("path")]
        public string Path { get; set; }

        /// <summary>
        /// The port to use for the connection.
        /// <para>Default: <c>22</c>.</para>
        /// </summary>
        [TransloaditJsonName("port")]
        public int? Port { get; set; }

        /// <summary>
        /// The directory on the SFTP server to import files from.
        /// </summary>
        [TransloaditJsonName("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// The hostname or IP address of the SFTP server.
        /// </summary>
        [TransloaditJsonName("host")]
        public string Host { get; set; }

        /// <summary>
        /// The authentication key used to connect to the SFTP server.
        /// </summary>
        [TransloaditJsonName("key")]
        public string Key { get; set; }

        /// <summary>
        /// The authentication secret used to connect to the SFTP server.
        /// </summary>
        [TransloaditJsonName("secret")]
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
