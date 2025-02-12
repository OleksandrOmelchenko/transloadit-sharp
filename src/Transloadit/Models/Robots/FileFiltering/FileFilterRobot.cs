using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.FileFiltering
{
    public class FileFilterRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<string, List<List<string>>> Accepts { get; set; }
        public AnyOf<string, List<List<string>>> Declines { get; set; }
        public string ConditionType { get; set; }
        public bool? ErrorOnDecline { get; set; }
        public string ErrorMsg { get; set; }

        public FileFilterRobot()
        {
            Robot = "/file/filter";
        }
    }
}
