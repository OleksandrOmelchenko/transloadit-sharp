using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/video-artwork/">/video/artwork</a> Robot.
    /// </summary>
    public class VideoArtworkRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// FFmpeg options merged over preset options.
        /// </summary>
        [TransloaditJsonName("ffmpeg")]
        public Dictionary<string, object> Ffmpeg { get; set; }

        /// <summary>
        /// FFmpeg stack version.
        /// </summary>
        [TransloaditJsonName("ffmpeg_stack")]
        public string FfmpegStack { get; set; }

        /// <summary>
        /// Optional preset.
        /// </summary>
        [TransloaditJsonName("preset")]
        public string Preset { get; set; }

        /// <summary>
        /// Method to run: <c>extract</c> or <c>insert</c>.
        /// </summary>
        [TransloaditJsonName("method")]
        public string Method { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/video-artwork/">/video/artwork</a> Robot.
        /// </summary>
        public VideoArtworkRobot()
        {
            Robot = "/video/artwork";
        }
    }
}
