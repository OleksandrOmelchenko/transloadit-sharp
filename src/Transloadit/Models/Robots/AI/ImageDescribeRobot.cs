using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    public class ImageDescribeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public string Granularity { get; set; }
        public string Format { get; set; }
        public bool? ExplicitDescriptions { get; set; }

        public ImageDescribeRobot()
        {
            Robot = "/image/describe";
        }
    }
}
