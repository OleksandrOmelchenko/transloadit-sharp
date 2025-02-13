using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    public class ImageFaceDetectRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public bool? Crop { get; set; }
        public string CropPadding { get; set; }
        public string Format { get; set; }
        public int MinConfidence { get; set; }
        public AnyOf<int, string> Faces { get; set; }

        public ImageFaceDetectRobot()
        {
            Robot = "/image/facedetect";
        }
    }
}
