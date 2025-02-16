using System.Collections.Generic;

namespace Transloadit.Models.Robots.SmartCdn
{
    public class FileServeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public FileServeRobot()
        {
            Robot = "/file/serve";
        }
    }
}