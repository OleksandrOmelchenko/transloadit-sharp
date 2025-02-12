using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.MediaCataloging
{
    public class MetadataWriteRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public Dictionary<string, object> DataToWrite { get; set; }
        public string FfmpegStack { get; set; }

        public MetadataWriteRobot()
        {
            Robot = "/meta/write";
        }
    }
}
