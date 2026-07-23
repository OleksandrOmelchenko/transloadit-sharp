using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.VideoEncoding
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/video-ondemand/">/video/ondemand</a> Robot.
    /// </summary>
    public class VideoOndemandRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Variant definitions indexed by output name.
        /// </summary>
        [TransloaditJsonName("variants")]
        public Dictionary<string, VideoOndemandVariant> Variants { get; set; }

        /// <summary>
        /// Enabled variants from <c>variants</c>.
        /// </summary>
        [TransloaditJsonName("enabled_variants")]
        public AnyOf<string, List<string>> EnabledVariants { get; set; }

        /// <summary>
        /// Segment duration in seconds.
        /// </summary>
        [TransloaditJsonName("segment_duration")]
        public AnyOf<int, string> SegmentDuration { get; set; }

        /// <summary>
        /// Signed URL expiration in seconds.
        /// </summary>
        [TransloaditJsonName("sign_urls_for")]
        public AnyOf<int, string> SignUrlsFor { get; set; }

        /// <summary>
        /// Asset selector value.
        /// </summary>
        [TransloaditJsonName("asset")]
        public string Asset { get; set; }

        /// <summary>
        /// Name of URL param carrying <c>asset</c>.
        /// </summary>
        [TransloaditJsonName("asset_param_name")]
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
        [TransloaditJsonName("preset")]
        public string Preset { get; set; }

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
        /// Variant width in pixels.
        /// </summary>
        [TransloaditJsonName("width")]
        public AnyOf<int, string> Width { get; set; }

        /// <summary>
        /// Variant height in pixels.
        /// </summary>
        [TransloaditJsonName("height")]
        public AnyOf<int, string> Height { get; set; }
    }
}
