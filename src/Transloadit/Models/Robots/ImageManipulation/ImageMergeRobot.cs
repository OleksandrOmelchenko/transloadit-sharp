using System.Collections.Generic;

namespace Transloadit.Models.Robots.ImageManipulation
{
    /// <summary>
    /// Represents <c>/image/merge</c> Robot.
    /// </summary>
    public class ImageMergeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }
        public string Format { get; set; }
        public string Direction { get; set; }
        public int? Border { get; set; }
        public string Background { get; set; }
        public bool? AdaptiveFiltering { get; set; }
        public int? Quality { get; set; }

        /// <summary>
        /// Initializes <c>/image/merge</c> Robot.
        /// </summary>
        public ImageMergeRobot()
        {
            Robot = "/image/merge";
        }
    }
}
