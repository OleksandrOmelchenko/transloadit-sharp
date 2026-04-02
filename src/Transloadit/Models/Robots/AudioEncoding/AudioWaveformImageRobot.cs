using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    /// <summary>
    /// Represents <c>"/audio/waveform</c> Robot.
    /// </summary>
    public class AudioWaveformImageRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Allows to specify a set of metadata that is more expensive on CPU power to calculate, 
        /// and thus is disabled by default to keep your Assemblies processing fast.
        /// This can be set to <c>false</c> to skip metadata extraction and speed up transcoding.
        /// <para>Default: <c>{}</c>.</para>
        /// </summary>
        [JsonProperty("output_meta")]
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// The format of the result file. Can be <c>image</c> or <c>json</c>. If <c>image</c> is supplied, a PNG image will be created, 
        /// otherwise a JSON file.
        /// <para>Default: <c>image</c>.</para>
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// The width of the resulting image if the format <c>image</c> was selected.
        /// <para>Default: <c>256</c>.</para>
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        /// The height of the resulting image if the format <c>image</c> was selected.
        /// <para>Default: <c>64</c>.</para>
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Either a value of <c>0</c> or <c>1</c>, corresponding to using either the legacy waveform tool, or the new tool respectively, 
        /// with the new tool offering an improved style. Other Robot parameters still function as described, with either tool.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        [JsonProperty("style")]
        public int? Style { get; set; }

        /// <summary>
        /// Either a value of <c>0</c> or <c>1</c>, corresponding to if you want to enable antialiasing to achieve smoother edges in the 
        /// waveform graph or not.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        [JsonProperty("antialiasing")]
        public int? Antialiasing { get; set; }

        /// <summary>
        /// The background color of the resulting image in the "rrggbbaa" format (red, green, blue, alpha), if the format <c>image</c> was selected.
        /// <para>Default: <c>#00000000</c>.</para>
        /// </summary>
        [JsonProperty("background_color")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The color used in the center of the gradient. The format is "rrggbbaa" (red, green, blue, alpha).
        /// <para>Default: <c>000000ff</c>.</para>
        /// </summary>
        [JsonProperty("center_color")]
        public string CenterColor { get; set; }

        /// <summary>
        /// The color used in the outer parts of the gradient. The format is "rrggbbaa" (red, green, blue, alpha).
        /// <para>Default: <c>000000ff</c>.</para>
        /// </summary>
        [JsonProperty("outer_color")]
        public string OuterColor { get; set; }

        /// <summary>
        /// Initializes <c>"/audio/waveform</c> Robot.
        /// </summary>
        public AudioWaveformImageRobot()
        {
            Robot = "/audio/waveform";
        }
    }
}
