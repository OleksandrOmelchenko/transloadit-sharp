using System.Collections.Generic;

namespace Transloadit.Models.Robots.MediaCataloging
{
    public class FileHashRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Algorithm { get; set; }

        public FileHashRobot()
        {
            Robot = "/file/hash";
        }
    }
}
