using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    public class VideoSubtitleRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }
        public string Preset { get; set; }
        public string SubtitlesType { get; set; }
        public string BorderStyle { get; set; }
        public string BorderColor { get; set; }
        public string Font { get; set; }
        public string FontColor { get; set; }
        public int? FontSize { get; set; }
        public string Position { get; set; }
        public string FfmpegStack { get; set; }
        public Dictionary<string, object> Ffmpeg { get; set; }

        public VideoSubtitleRobot()
        {
            Robot = "/video/subtitle";
        }
    }
}
