using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.MediaCataloging
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/meta-write/">/meta/write</a> Robot.
    /// </summary>
    public class MetadataWriteRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// A key/value map defining the metadata to write into the file. Valid metadata keys can be found 
        /// <a href="https://exiftool.org/TagNames/EXIF.html">here</a>. For example: <c>ProcessingSoftware</c>.
        /// </summary>
        [TransloaditJsonName("data_to_write")]
        public Dictionary<string, object> DataToWrite { get; set; }

        /// <summary>
        /// FFmpeg stack version. One of <see cref="Constants.FFMpegStack"/>: <c>v5.0.0</c> or <c>v6.0.0</c>.
        /// <para>Default: <c>v5.0.0</c>.</para>
        /// </summary>
        [TransloaditJsonName("ffmpeg_stack")]
        public string FfmpegStack { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/meta-write/">/meta/write</a> Robot.
        /// </summary>
        public MetadataWriteRobot()
        {
            Robot = "/meta/write";
        }
    }
}
