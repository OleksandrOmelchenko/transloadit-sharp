using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    public class SftpImportRobot : RobotBase
    {
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }
        public string Credentials { get; set; }
        public string Path { get; set; }
        public int? Port { get; set; }

        public SftpImportRobot()
        {
            Robot = "/sftp/import";
        }
    }
}
