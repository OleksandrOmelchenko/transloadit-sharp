using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/ftp/import</c> Robot.
    /// </summary>
    public class FtpImportRobot : RobotBase
    {
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }

        /// <summary>
        /// Template credentials name.
        /// </summary>
        public string Credentials { get; set; }

        /// <summary>
        /// The path to the specific file or directory.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The port to use for the FTP connection.
        /// <para>Default: <c>21</c>.</para>
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Determines if passive mode should be used for the FTP connection.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? PassiveMode { get; set; }

        /// <summary>
        /// Initializes <c>/ftp/import</c> Robot.
        /// </summary>
        public FtpImportRobot()
        {
            Robot = "/ftp/import";
        }
    }
}
