using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    public class FileReadRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        public FileReadRobot()
        {
            Robot = "/file/read";
        }
    }
}
