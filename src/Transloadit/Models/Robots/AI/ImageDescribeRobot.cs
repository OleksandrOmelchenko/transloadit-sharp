using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <c>/image/describe</c> Robot.
    /// </summary>
    public class ImageDescribeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Which AI provider to leverage. One of <see cref="Constants.AIProviders"/>: <c>aws</c> and <c>gcp</c>.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Whether to return a full response including coordinates for the text (<c>full</c>), or a flat list of the extracted phrases (<c>list</c>). 
        /// This parameter has no effect if the format parameter is set to <c>text</c>.
        /// <para>Default: <c>full</c>.</para>
        /// </summary>
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
        public string Format { get; set; }

        /// <summary>
        /// Whether to return only explicit or only non-explicit descriptions of the provided image. Explicit descriptions include labels for 
        /// NSFW content (nudity, violence, etc). If set to <c>false</c>, only non-explicit descriptions (such as human or chair) will be returned. 
        /// If set to <c>true</c>, only explicit descriptions will be returned.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? ExplicitDescriptions { get; set; }

        /// <summary>
        /// Initializes <c>/image/describe</c> Robot.
        /// </summary>
        public ImageDescribeRobot()
        {
            Robot = "/image/describe";
        }
    }
}
