using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileCompressing
{
    public class FileDecompressRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }

        public FileDecompressRobot()
        {
            Robot = "/file/decompress";
        }
    }
}
