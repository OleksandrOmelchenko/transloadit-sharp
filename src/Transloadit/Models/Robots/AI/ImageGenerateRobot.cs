using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <c>/image/generate</c> Robot.
    /// </summary>
    public class ImageGenerateRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Allows to specify a set of metadata that is more expensive on CPU power to calculate, 
        /// and thus is disabled by default to keep your Assemblies processing fast.
        /// This can be set to <c>false</c> to skip metadata extraction and speed up transcoding.
        /// <para>Default: <c>{}</c>.</para>
        /// </summary>
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// The AI model to use for image generation. Please see the 
        /// <a href="https://transloadit.com/docs/transcoding/artificial-intelligence/image-generate/#supported-models">table of supported models</a>
        /// for all available options on their capabilities.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// The text prompt describing the image you want to generate. 
        /// Be as descriptive as possible for best results. Include details about style, lighting, composition, and subject matter.
        /// </summary>
        public string Prompt { get; set; }

        /// <summary>
        /// The output format for the generated image.
        /// Please see the <a href="https://transloadit.com/docs/transcoding/artificial-intelligence/image-generate/#supported-models">table of supported models</a> for the format support per model.
        /// <para>Default: <c>png</c>.</para>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// A seed value for deterministic generation. Using the same seed with the same prompt and model will produce similar results. 
        /// This allows for reproducible outputs.
        /// <para>Default: <c>null</c>.</para>
        /// </summary>
        public int? Seed { get; set; }

        /// <summary>
        /// The aspect ratio of the generated image.
        /// </summary>
        public string AspectRatio { get; set; }

        /// <summary>
        /// The height of the generated image in pixels.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// The width of the generated image in pixels.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// The artistic style to apply to the generated image.
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Initializes <c>/image/generate</c> Robot.
        /// </summary>
        public ImageGenerateRobot()
        {
            Robot = "/image/generate";
        }
    }
}
