using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.ImageManipulation
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/image-upscale/">/image/upscale</a> Robot.
    /// </summary>
    public class ImageUpscaleRobot : RobotBase
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
        /// AI model used for upscaling. One of <see cref="Constants.ImageUpscaleModels"/>.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Upscaling factor.
        /// </summary>
        [JsonProperty("scale")]
        public int? Scale { get; set; }

        /// <summary>
        /// Enables face enhancement.
        /// </summary>
        [JsonProperty("face_enhance")]
        public bool? FaceEnhance { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/image-upscale/">/image/upscale</a> Robot.
        /// </summary>
        public ImageUpscaleRobot()
        {
            Robot = "/image/upscale";
        }
    }
}
