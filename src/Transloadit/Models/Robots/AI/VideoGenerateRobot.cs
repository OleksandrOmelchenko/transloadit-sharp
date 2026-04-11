using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/video-generate/">/video/generate</a> Robot.
    /// </summary>
    public class VideoGenerateRobot : RobotBase
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
        /// The model to use.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Required prompt describing desired video content.
        /// </summary>
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// Output format such as <c>mp4</c> or <c>gif</c>.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Deterministic generation seed.
        /// </summary>
        [JsonProperty("seed")]
        public AnyOf<int, string> Seed { get; set; }

        /// <summary>
        /// Output aspect ratio.
        /// </summary>
        [JsonProperty("aspect_ratio")]
        public string AspectRatio { get; set; }

        /// <summary>
        /// Output height in pixels.
        /// </summary>
        [JsonProperty("height")]
        public AnyOf<int, string> Height { get; set; }

        /// <summary>
        /// Output width in pixels.
        /// </summary>
        [JsonProperty("width")]
        public AnyOf<int, string> Width { get; set; }

        /// <summary>
        /// Generation style.
        /// </summary>
        [JsonProperty("style")]
        public string Style { get; set; }

        /// <summary>
        /// Number of variants to generate.
        /// </summary>
        [JsonProperty("num_outputs")]
        public AnyOf<int, string> NumOutputs { get; set; }

        /// <summary>
        /// Output duration in seconds.
        /// </summary>
        [JsonProperty("duration")]
        public AnyOf<int, string> Duration { get; set; }

        /// <summary>
        /// Frames per second.
        /// </summary>
        [JsonProperty("fps")]
        public AnyOf<int, string> Fps { get; set; }

        /// <summary>
        /// Motion intensity control.
        /// </summary>
        [JsonProperty("motion_amount")]
        public AnyOf<int, string> MotionAmount { get; set; }

        /// <summary>
        /// Camera movement type.
        /// </summary>
        [JsonProperty("camera_motion")]
        public string CameraMotion { get; set; }

        /// <summary>
        /// Negative prompt describing what to avoid.
        /// </summary>
        [JsonProperty("negative_prompt")]
        public string NegativePrompt { get; set; }

        /// <summary>
        /// Reference adherence strength.
        /// </summary>
        [JsonProperty("reference_strength")]
        public AnyOf<double, string> ReferenceStrength { get; set; }

        /// <summary>
        /// Provider override.
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/video-generate/">/video/generate</a> Robot.
        /// </summary>
        public VideoGenerateRobot()
        {
            Robot = "/video/generate";
        }
    }
}
