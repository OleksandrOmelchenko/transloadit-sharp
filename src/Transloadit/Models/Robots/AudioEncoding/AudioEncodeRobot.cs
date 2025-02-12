using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.AudioEncoding
{
    public class AudioEncodeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, UploadOutputMeta> OutputMeta { get; set; }
        public string Preset { get; set; }
        public int? Bitrate { get; set; }
        public int? SampleRate { get; set; }
        public string FfmpegStack { get; set; }
        public Dictionary<string, object> Ffmpeg { get; set; }

        //todo: hls params, not listed in docs?

        public AudioEncodeRobot()
        {
            Robot = "/audio/encode";
        }
    }
}
