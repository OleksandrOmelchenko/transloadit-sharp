using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <c>/video/split</c> Robot.
    /// </summary>
    public class VideoSplitRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Optional expensive metadata extraction settings.
        /// </summary>
        [JsonProperty("output_meta")]
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

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
        /// Output width in pixels.
        /// </summary>
        [JsonProperty("width")]
        public AnyOf<int, string> Width { get; set; }

        /// <summary>
        /// Output height in pixels.
        /// </summary>
        [JsonProperty("height")]
        public AnyOf<int, string> Height { get; set; }

        /// <summary>
        /// Video segments to extract.
        /// </summary>
        [JsonProperty("segments")]
        public List<VideoSplitSegment> Segments { get; set; }

        /// <summary>
        /// Initializes <c>/video/split</c> Robot.
        /// </summary>
        public VideoSplitRobot()
        {
            Robot = "/video/split";
        }
    }

    /// <summary>
    /// Represents a video split segment.
    /// </summary>
    public class VideoSplitSegment
    {
        /// <summary>
        /// Segment start offset.
        /// </summary>
        [JsonProperty("from")]
        public AnyOf<int, string> From { get; set; }

        /// <summary>
        /// Segment end offset.
        /// </summary>
        [JsonProperty("to")]
        public AnyOf<int, string> To { get; set; }
    }
}
