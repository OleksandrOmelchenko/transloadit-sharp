using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.FileFiltering
{
    public class FileVirusScanRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public bool? ErrorOnDecline { get; set; }
        public string ErrorMsg { get; set; }

        public FileVirusScanRobot()
        {
            Robot = "/file/virusscan";
        }
    }
}
