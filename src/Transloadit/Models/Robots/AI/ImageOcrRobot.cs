using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/image-ocr/">/image/ocr</a> Robot.
    /// </summary>
    public class ImageOcrRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Which AI provider to leverage. One of <see cref="Constants.AIProviders"/>: <c>aws</c> and <c>gcp</c>.
        /// </summary>
        [TransloaditJsonName("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Whether to return a full response including coordinates for the text (<c>full</c>), or a flat list of the extracted phrases (<c>list</c>). 
        /// This parameter has no effect if the format parameter is set to <c>text</c>.
        /// <para>Default: <c>full</c>.</para>
        /// </summary>
        [TransloaditJsonName("granularity")]
        public string Granularity { get; set; }

        /// <summary>
        /// In what format to return the extracted text.
        /// <para>Default: <c>json</c>.</para>
        /// <list type="bullet">
        /// <item><c>json</c> returns a JSON file.</item>
        /// <item><c>meta</c> does not return a file, but stores the data inside Transloadit's file object (under <c>${file.meta.recognized_text}</c>, 
        /// which is an array of strings) that's passed around between encoding Steps, so that you can use the values to burn the data into videos, 
        /// filter on them, etc.</item>
        /// <item><c>text</c> returns the recognized text as a plain UTF-8 encoded text file.</item>
        /// </list>
        /// </summary>
        [TransloaditJsonName("format")]
        public string Format { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/image-ocr/">/image/ocr</a> Robot.
        /// </summary>
        public ImageOcrRobot()
        {
            Robot = "/image/ocr";
        }
    }
}
