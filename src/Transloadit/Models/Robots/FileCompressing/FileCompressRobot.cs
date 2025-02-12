using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.FileCompressing
{
    public class FileCompressRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Format { get; set; }
        public bool? Gzip { get; set; }
        public string Password { get; set; }
        public int? CompressionLevel { get; set; }
        public string FileLayout { get; set; }

        public FileCompressRobot()
        {
            Robot = "/file/compress";
        }
    }
}
