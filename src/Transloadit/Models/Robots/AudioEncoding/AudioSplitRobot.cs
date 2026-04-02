using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.AudioEncoding
{
    /// <summary>
    /// Represents <c>/audio/split</c> Robot.
    /// </summary>
    public class AudioSplitRobot : RobotBase
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
        /// Audio encoding preset.
        /// </summary>
        [JsonProperty("preset")]
        public string Preset { get; set; }

        /// <summary>
        /// Output bitrate.
        /// </summary>
        [JsonProperty("bitrate")]
        public AnyOf<int, string> Bitrate { get; set; }

        /// <summary>
        /// Output sample rate.
        /// </summary>
        [JsonProperty("sample_rate")]
        public AnyOf<int, string> SampleRate { get; set; }

        /// <summary>
        /// Audio segments to extract.
        /// </summary>
        [JsonProperty("segments")]
        public List<AudioSplitSegment> Segments { get; set; }

        /// <summary>
        /// Initializes <c>/audio/split</c> Robot.
        /// </summary>
        public AudioSplitRobot()
        {
            Robot = "/audio/split";
        }
    }

    /// <summary>
    /// Represents an audio split segment.
    /// </summary>
    public class AudioSplitSegment
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
