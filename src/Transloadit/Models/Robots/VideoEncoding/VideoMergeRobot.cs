using System.Collections.Generic;

namespace Transloadit.Models.Robots.VideoEncoding
{
    public class VideoMergeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, UploadOutputMeta> OutputMeta { get; set; }
        public string Preset { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string ResizeStrategy { get; set; }
        public string Background { get; set; }
        public string Framerate { get; set; }
        public List<double> ImageDurations { get; set; }
        public double? Duration { get; set; }
        public double? AudioDelay { get; set; }
        public bool? ReplaceAudio { get; set; }
        public bool? Vstack { get; set; }
        public string FfmpegStack { get; set; }
        public Dictionary<string, object> Ffmpeg { get; set; }

        public VideoMergeRobot()
        {
            Robot = "/video/merge";
        }
    }
}
