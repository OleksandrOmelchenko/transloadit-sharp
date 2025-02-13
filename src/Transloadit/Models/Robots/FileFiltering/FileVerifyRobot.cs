using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileFiltering
{
    public class FileVerifyRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public bool? ErrorOnDecline { get; set; }
        public string ErrorMsg { get; set; }
        public string VerifyToBe { get; set; }

        public FileVerifyRobot()
        {
            Robot = "/file/verify";
        }
    }
}
