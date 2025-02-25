using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <c>/video/adaptive</c> Robot.
    /// </summary>
    public class VideoAdaptiveRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Technique { get; set; }
        public string PlaylistName { get; set; }
        public int? SegmentDuration { get; set; }
        public bool? ClosedCaptions { get; set; }

        /// <summary>
        /// Initializes <c>/video/adaptive</c> Robot.
        /// </summary>
        public VideoAdaptiveRobot()
        {
            Robot = "/video/adaptive";
        }
    }
}
