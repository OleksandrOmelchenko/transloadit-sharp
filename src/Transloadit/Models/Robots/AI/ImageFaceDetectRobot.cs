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

        /// <summary>
        /// Which AI provider to leverage. One of <see cref="Constants.AIProviders"/>: <c>aws</c> and <c>gcp</c>.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Determine if the detected faces should be extracted. If this option is set to <c>false</c>, then the Robot returns the input image again, 
        /// but with the coordinates of all detected faces attached to <c>file.meta.faces</c> in the result JSON. If this parameter is set to 
        /// <c>true</c>, the Robot will output all detected faces as images.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Crop { get; set; }

        /// <summary>
        /// Specifies how much padding is added to the extracted face images if <c>crop</c> is set to <c>true</c>. Values can be in 
        /// <c>px</c> (pixels) or <c>%</c> (percentage of the width and height of the particular face image).
        /// <para>Default: <c>5px</c>.</para>
        /// </summary>
        public string CropPadding { get; set; }

        /// <summary>
        /// Determines the output format of the extracted face images if <c>crop</c> is set to <c>true</c>. The default value <c>preserve</c>
        /// means that the input image format is re-used. One of: <c>jpg</c>", <c>png</c>, <c>tiff</c> and <c>preserve</c>.
        /// <para>Default: <c>preserve</c>.</para>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Specifies the minimum confidence that a detected face must have. Only faces which have a higher confidence value than this threshold 
        /// will be included in the result. Available values 1-100.
        /// <para>Default: <c>70</c>.</para>
        /// </summary>
        public int MinConfidence { get; set; }

        /// <summary>
        /// Determines which of the detected faces should be returned. Valid values are:
        /// <list type="bullet">
        /// <item><c>each</c> - each face is returned individually.</item>
        /// <item><c>max-confidence</c> - only the face with the highest confidence value is returned.</item>
        /// <item><c>max-size</c> - only the face with the largest area is returned.</item>
        /// <item><c>group</c> - all detected faces are grouped together into one rectangle that contains all faces.</item>
        /// <item>any integer - the faces are sorted by their top-left corner and the integer determines the index of the returned face. 
        /// Be aware the values are zero-indexed, meaning that <c>faces: 0</c> will return the first face. If no face for a given index exists, 
        /// no output is produced.</item>
        /// </list>
        /// </summary>
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
