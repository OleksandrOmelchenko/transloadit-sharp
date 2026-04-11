using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/video-ondemand/">/video/ondemand</a> Robot.
    /// </summary>
    public class VideoOndemandRobot : RobotBase
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
        /// Variant definitions indexed by output name.
        /// </summary>
        [JsonProperty("variants")]
        public Dictionary<string, VideoOndemandVariant> Variants { get; set; }

        /// <summary>
        /// Enabled variants from <c>variants</c>.
        /// </summary>
        [JsonProperty("enabled_variants")]
        public AnyOf<string, List<string>> EnabledVariants { get; set; }

        /// <summary>
        /// Segment duration in seconds.
        /// </summary>
        [JsonProperty("segment_duration")]
        public AnyOf<int, string> SegmentDuration { get; set; }

        /// <summary>
        /// Signed URL expiration in seconds.
        /// </summary>
        [JsonProperty("sign_urls_for")]
        public AnyOf<int, string> SignUrlsFor { get; set; }

        /// <summary>
        /// Asset selector value.
        /// </summary>
        [JsonProperty("asset")]
        public string Asset { get; set; }

        /// <summary>
        /// Name of URL param carrying <c>asset</c>.
        /// </summary>
        [JsonProperty("asset_param_name")]
        public string AssetParamName { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/video-ondemand/">/video/ondemand</a> Robot.
        /// </summary>
        public VideoOndemandRobot()
        {
            Robot = "/video/ondemand";
        }
    }

    /// <summary>
    /// Represents a single on-demand variant definition.
    /// </summary>
    public class VideoOndemandVariant
    {
        /// <summary>
        /// Variant preset.
        /// </summary>
        [JsonProperty("preset")]
        public string Preset { get; set; }

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
        /// Variant width in pixels.
        /// </summary>
        [JsonProperty("width")]
        public AnyOf<int, string> Width { get; set; }

        /// <summary>
        /// Variant height in pixels.
        /// </summary>
        [JsonProperty("height")]
        public AnyOf<int, string> Height { get; set; }
    }
}
