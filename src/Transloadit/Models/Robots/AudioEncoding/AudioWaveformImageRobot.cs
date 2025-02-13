using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    public class AudioWaveformImageRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, UploadOutputMeta> OutputMeta { get; set; }
        public string Format { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Style { get; set; }
        public int? Antialiasing { get; set; }
        public string BackgroundColor { get; set; }
        public string CenterColor { get; set; }
        public string OuterColor { get; set; }

        public AudioWaveformImageRobot()
        {
            Robot = "/audio/waveform";
        }
    }
}
