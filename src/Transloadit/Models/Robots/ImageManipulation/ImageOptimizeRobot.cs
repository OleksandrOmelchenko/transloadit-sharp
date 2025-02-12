using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.ImageManipulation
{
    public class ImageOptimizeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Priority { get; set; }
        public bool? Progressive { get; set; }
        public bool? PreserveMetaData { get; set; }
        public bool? FixBreakingImages { get; set; }

        public ImageOptimizeRobot()
        {
            Robot = "/image/optimize";
        }
    }
}
