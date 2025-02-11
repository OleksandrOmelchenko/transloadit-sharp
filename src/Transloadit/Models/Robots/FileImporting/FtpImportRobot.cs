using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.FileImporting
{
    public class FtpImportRobot : RobotBase
    {
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }
        public string Credentials { get; set; }
        public string Path { get; set; }
        public int? Port { get; set; }
        public bool? PassiveMode { get; set; }

        public FtpImportRobot()
        {
            Robot = "/ftp/import";
        }
    }
}
