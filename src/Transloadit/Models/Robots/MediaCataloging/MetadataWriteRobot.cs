using System.Collections.Generic;

namespace Transloadit.Models.Robots.MediaCataloging
{
    /// <summary>
    /// Represents <c>/meta/write</c> Robot.
    /// </summary>
    public class MetadataWriteRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// A key/value map defining the metadata to write into the file. Valid metadata keys can be found 
        /// <a href="https://exiftool.org/TagNames/EXIF.html">here</a>. For example: <c>ProcessingSoftware</c>.
        /// </summary>
        public Dictionary<string, object> DataToWrite { get; set; }

        /// <summary>
        /// FFmpeg stack version. One of <see cref="Constants.FFMpegStack"/>: <c>v5.0.0</c> or <c>v6.0.0</c>.
        /// <para>Default: <c>v5.0.0</c>.</para>
        /// </summary>
        public string FfmpegStack { get; set; }

        /// <summary>
        /// Initializes <c>/meta/write</c> Robot.
        /// </summary>
        public MetadataWriteRobot()
        {
            Robot = "/meta/write";
        }
    }
}
