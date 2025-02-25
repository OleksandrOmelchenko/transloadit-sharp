using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <c>/image/describe</c> Robot.
    /// </summary>
    public class ImageDescribeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public string Granularity { get; set; }
        public string Format { get; set; }
        public bool? ExplicitDescriptions { get; set; }

        /// <summary>
        /// Initializes <c>/image/describe</c> Robot.
        /// </summary>
        public ImageDescribeRobot()
        {
            Robot = "/image/describe";
        }
    }
}
