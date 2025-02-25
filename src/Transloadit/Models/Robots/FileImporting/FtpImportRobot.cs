using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/ftp/import</c> Robot.
    /// </summary>
    public class FtpImportRobot : RobotBase
    {
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }
        public string Credentials { get; set; }
        public string Path { get; set; }
        public int? Port { get; set; }
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
