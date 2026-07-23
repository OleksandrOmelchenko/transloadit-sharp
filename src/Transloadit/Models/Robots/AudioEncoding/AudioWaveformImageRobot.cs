using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    /// <summary>
    /// Represents <c>"/audio/waveform</c> Robot.
    /// </summary>
    public class AudioWaveformImageRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The format of the result file. Can be <c>image</c> or <c>json</c>. If <c>image</c> is supplied, a PNG image will be created, 
        /// otherwise a JSON file.
        /// <para>Default: <c>image</c>.</para>
        /// </summary>
        [TransloaditJsonName("format")]
        public string Format { get; set; }

        /// <summary>
        /// The width of the resulting image if the format <c>image</c> was selected.
        /// <para>Default: <c>256</c>.</para>
        /// </summary>
        [TransloaditJsonName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// The height of the resulting image if the format <c>image</c> was selected.
        /// <para>Default: <c>64</c>.</para>
        /// </summary>
        [TransloaditJsonName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Either a value of <c>0</c> or <c>1</c>, corresponding to using either the legacy waveform tool, or the new tool respectively, 
        /// with the new tool offering an improved style. Other Robot parameters still function as described, with either tool.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        [TransloaditJsonName("style")]
        public int? Style { get; set; }

        /// <summary>
        /// Either a value of <c>0</c> or <c>1</c>, corresponding to if you want to enable antialiasing to achieve smoother edges in the 
        /// waveform graph or not.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        [TransloaditJsonName("antialiasing")]
        public int? Antialiasing { get; set; }

        /// <summary>
        /// The background color of the resulting image in the "rrggbbaa" format (red, green, blue, alpha), if the format <c>image</c> was selected.
        /// <para>Default: <c>#00000000</c>.</para>
        /// </summary>
        [TransloaditJsonName("background_color")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The color used in the center of the gradient. The format is "rrggbbaa" (red, green, blue, alpha).
        /// <para>Default: <c>000000ff</c>.</para>
        /// </summary>
        [TransloaditJsonName("center_color")]
        public string CenterColor { get; set; }

        /// <summary>
        /// The color used in the outer parts of the gradient. The format is "rrggbbaa" (red, green, blue, alpha).
        /// <para>Default: <c>000000ff</c>.</para>
        /// </summary>
        [TransloaditJsonName("outer_color")]
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
