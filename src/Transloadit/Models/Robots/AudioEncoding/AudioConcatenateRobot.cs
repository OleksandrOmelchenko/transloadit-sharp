using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.AudioEncoding
{
    public class AudioConcatenateRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, UploadOutputMeta> OutputMeta { get; set; }
        public string Preset { get; set; }
        public int? Bitrate { get; set; }
        public int? SampleRate { get; set; }
        public double? AudioFadeSeconds { get; set; }
        public string FfmpegStack { get; set; }
        public Dictionary<string, object> Ffmpeg { get; set; }

        public AudioConcatenateRobot()
        {
            Robot = "/audio/concat";
        }
    }
}
