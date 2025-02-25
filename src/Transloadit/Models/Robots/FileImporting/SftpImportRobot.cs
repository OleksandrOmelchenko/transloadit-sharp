using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/sftp/import</c> Robot.
    /// </summary>
    public class SftpImportRobot : RobotBase
    {
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }
        public string Credentials { get; set; }

        /// <summary>
        /// The path on your SFTP server where to search for files.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The port to use for the connection.
        /// <para>Default: <c>22</c>.</para>
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Initializes <c>/sftp/import</c> Robot.
        /// </summary>
        public SftpImportRobot()
        {
            Robot = "/sftp/import";
        }
    }
}
