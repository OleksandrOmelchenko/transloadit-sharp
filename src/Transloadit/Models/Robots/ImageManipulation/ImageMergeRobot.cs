using System.Collections.Generic;

namespace Transloadit.Models.Robots.ImageManipulation
{
    public class ImageMergeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, UploadOutputMeta> OutputMeta { get; set; }
        public string Format { get; set; }
        public string Direction { get; set; }
        public int? Border { get; set; }
        public string Background { get; set; }
        public bool? AdaptiveFiltering { get; set; }
        public int? Quality { get; set; }

        public ImageMergeRobot()
        {
            Robot = "/image/merge";
        }
    }
}
