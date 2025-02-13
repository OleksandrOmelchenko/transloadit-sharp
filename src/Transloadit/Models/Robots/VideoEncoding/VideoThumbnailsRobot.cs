using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.VideoEncoding
{
    public class VideoThumbnailsRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, UploadOutputMeta> OutputMeta { get; set; }
        public int? Count { get; set; }
        public AnyOf<List<int>, List<string>> Offsets { get; set; }
        public string Format { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string ResizeStrategy { get; set; }
        public string Background { get; set; }
        public int? Rotate { get; set; }
        public string FfmpegStack { get; set; }

        public VideoThumbnailsRobot()
        {
            Robot = "/video/thumbs";
        }
    }
}
