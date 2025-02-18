using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    public class VideoConcatenateRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }
        public string Preset { get; set; }
        public double? VideoFadeSeconds { get; set; }
        public double? AudioFadeSeconds { get; set; }
        public string FfmpegStack { get; set; }
        public Dictionary<string, object> Ffmpeg { get; set; }

        public VideoConcatenateRobot()
        {
            Robot = "/video/concat";
        }
    }
}
