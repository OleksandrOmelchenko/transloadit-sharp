using System.Collections.Generic;
using Newtonsoft.Json;

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
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// FFmpeg options merged over preset options.
        /// </summary>
        [JsonProperty("ffmpeg")]
        public Dictionary<string, object> Ffmpeg { get; set; }

        /// <summary>
        /// FFmpeg stack version.
        /// </summary>
        [JsonProperty("ffmpeg_stack")]
        public string FfmpegStack { get; set; }

        /// <summary>
        /// Optional preset.
        /// </summary>
        [JsonProperty("preset")]
        public string Preset { get; set; }

        /// <summary>
        /// Method to run: <c>extract</c> or <c>insert</c>.
        /// </summary>
        [JsonProperty("method")]
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
