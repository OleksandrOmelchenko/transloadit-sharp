using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <c>/image/facedetect</c> Robot.
    /// </summary>
    public class ImageFaceDetectRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public bool? Crop { get; set; }
        public string CropPadding { get; set; }
        public string Format { get; set; }
        public int MinConfidence { get; set; }
        public AnyOf<int, string> Faces { get; set; }

        /// <summary>
        /// Initializes <c>/image/facedetect</c> Robot.
        /// </summary>
        public ImageFaceDetectRobot()
        {
            Robot = "/image/facedetect";
        }
    }
}
