using System.Collections.Generic;

namespace Transloadit.Models.Robots.ImageManipulation
{
    /// <summary>
    /// Represents <c>/image/optimize</c> Robot.
    /// </summary>
    public class ImageOptimizeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Priority { get; set; }
        public bool? Progressive { get; set; }
        public bool? PreserveMetaData { get; set; }
        public bool? FixBreakingImages { get; set; }

        /// <summary>
        /// Initializes <c>/image/optimize</c> Robot.
        /// </summary>
        public ImageOptimizeRobot()
        {
            Robot = "/image/optimize";
        }
    }
}
