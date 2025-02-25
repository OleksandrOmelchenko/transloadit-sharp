using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.ImageManipulation
{
    /// <summary>
    /// Represents <c>/image/resize</c> Robot.
    /// </summary>
    public class ResizeImageRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }
        public string Format { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string ResizeStrategy { get; set; }
        public bool? Zoom { get; set; }
        public AnyOf<string, Crop> Crop { get; set; }
        public string Gravity { get; set; }
        public bool? Strip { get; set; }
        public string Alpha { get; set; }
        public string PreclipAlpha { get; set; }
        public bool? Flatten { get; set; }
        public bool? CorrectGamma { get; set; }
        public int? Quality { get; set; }
        public bool? AdaptiveFilering { get; set; }
        public string Background { get; set; }
        public int? Frame { get; set; }
        public string Colorspace { get; set; }
        public string Type { get; set; }
        public AnyOf<bool, int> Rotation { get; set; }
        public string Compress { get; set; }
        public string Blur { get; set; }
        public List<BlurRegion> BlurRegions { get; set; }
        public int? Brightness { get; set; }
        public int? Saturation { get; set; }
        public int? Hue { get; set; }
        public bool? Progressive { get; set; }
        public string Transparent { get; set; }
        public bool? TrimWhitespace { get; set; }
        public AnyOf<bool, string> Clip { get; set; }
        public bool? Negate { get; set; }
        public int? Density { get; set; }

        /// <summary>
        /// ImageMagic stack version. One of <see cref="Constants.ImageMagickStack"/>: <c>v2.0.10</c> or <c>v3.0.1</c>.
        /// <para>Default: <c>v2.0.10</c>.</para>
        /// </summary>
        public string ImagemagickStack { get; set; }
        public List<TextData> Text { get; set; }
        public string WatermarkUrl { get; set; }
        public AnyOf<string, List<string>> WatermarkPosition { get; set; }
        public int? WatermarkXOffset { get; set; }
        public int? WatermarkYOffset { get; set; }
        public string WatermarkSize { get; set; }
        public string WatermarkResizeStrategy { get; set; }

        /// <summary>
        /// Initializes <c>/image/resize</c> Robot.
        /// </summary>
        public ResizeImageRobot()
        {
            Robot = "/image/resize";
        }
    }

    public class TextData
    {
        public string Text { get; set; }
        public string Font { get; set; }
        public int? Size { get; set; }
        public int? Rotate { get; set; }
        public string Color { get; set; }
        public string BackgroundColor { get; set; }
        public int? StrokeWidth { get; set; }
        public string StrokeColor { get; set; }
        public string Align { get; set; }
        public string Valign { get; set; }
        public int? XOffset { get; set; }
        public int? YOffset { get; set; }
    }

    public class Crop
    {
        [JsonProperty("x1")]
        public int X1 { get; set; }

        [JsonProperty("y1")]
        public int Y1 { get; set; }

        [JsonProperty("x2")]
        public string X2 { get; set; }

        [JsonProperty("y2")]
        public string Y2 { get; set; }
    }

    public class BlurRegion
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
