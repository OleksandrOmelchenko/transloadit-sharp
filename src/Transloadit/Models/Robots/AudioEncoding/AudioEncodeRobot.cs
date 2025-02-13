using System.Collections.Generic;

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

        public AudioEncodeRobot()
        {
            Robot = "/audio/encode";
        }
    }
}
