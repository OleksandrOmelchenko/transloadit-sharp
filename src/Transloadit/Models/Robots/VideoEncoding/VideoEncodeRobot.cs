using System.Collections.Generic;
using Transloadit.Models.Robots.ImageManipulation;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.VideoEncoding
{
    public class VideoEncodeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, UploadOutputMeta> OutputMeta { get; set; }
        public string Preset { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string ResizeStrategy { get; set; }
        public bool? Zoom { get; set; }
        public AnyOf<string, Crop> Crop { get; set; }
        public string Background { get; set; }
        public int? Rotate { get; set; }
        public bool? Hint { get; set; }
        public bool? Turbo { get; set; }
        public int? ChunkDuration { get; set; }
        public bool? FreezeDetect { get; set; }
        public string FfmpegStack { get; set; }
        public Dictionary<string, object> Ffmpeg { get; set; }

        public VideoEncodeRobot()
        {
            Robot = "/video/encode";
        }
    }
}
