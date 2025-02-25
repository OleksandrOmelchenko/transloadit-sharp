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
        public string Path { get; set; }
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
