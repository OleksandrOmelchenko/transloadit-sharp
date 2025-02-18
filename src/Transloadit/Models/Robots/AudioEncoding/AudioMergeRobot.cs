using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    public class AudioMergeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }
        public string Preset { get; set; }
        public int? Bitrate { get; set; }
        public int? SampleRate { get; set; }
        public double? Duration { get; set; }
        public bool? Loop { get; set; }
        public string Volume { get; set; }
        public string FfmpegStack { get; set; }
        public Dictionary<string, object> Ffmpeg { get; set; }

        public AudioMergeRobot()
        {
            Robot = "/audio/merge";
        }
    }
}
