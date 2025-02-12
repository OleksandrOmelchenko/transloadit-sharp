using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.AI
{
    public class ImageOcrRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public string Granularity { get; set; }
        public string Format { get; set; }

        public ImageOcrRobot()
        {
            Robot = "/image/ocr";
        }
    }
}
