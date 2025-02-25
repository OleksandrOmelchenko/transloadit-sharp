using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <c>/image/ocr</c> Robot.
    /// </summary>
    public class ImageOcrRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public string Granularity { get; set; }
        public string Format { get; set; }

        /// <summary>
        /// Initializes <c>/image/ocr</c> Robot.
        /// </summary>
        public ImageOcrRobot()
        {
            Robot = "/image/ocr";
        }
    }
}
