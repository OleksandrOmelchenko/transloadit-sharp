using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    public class VideoAdaptiveRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Technique { get; set; }
        public string PlaylistName { get; set; }
        public int? SegmentDuration { get; set; }
        public bool? ClosedCaptions { get; set; }

        public VideoAdaptiveRobot()
        {
            Robot = "/video/adaptive";
        }
    }
}
