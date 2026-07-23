using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/html-convert/">/html/convert</a> Robot.
    /// </summary>
    public class HtmlConvertRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The URL of the web page to be converted. Optional, as you can also upload/import HTML files and pass it to this Robot.
        /// </summary>
        [TransloaditJsonName("url")]
        public string Url { get; set; }

        /// <summary>
        /// The format of the resulting image. The supported values are <c>pdf</c>, <c>jpg</c>, <c>jpeg</c> and <c>png</c>.
        /// <para>Default: <c>png</c>.</para>
        /// </summary>
        [TransloaditJsonName("format")]
        public string Format { get; set; }

        /// <summary>
        /// Determines if a screenshot of the full page should be taken or not.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        [TransloaditJsonName("fullpage")]
        public bool? Fullpage { get; set; }

        /// <summary>
        /// Determines whether to preserve a transparent background in HTML pages. Useful if you're generating artwork in HTML that you want 
        /// to overlay on e.g. a video. This parameter is only used when <c>format</c> is not <c>pdf</c>.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [TransloaditJsonName("omit_background")]
        public bool? OmitBackground { get; set; }

        /// <summary>
        /// The screen width that will be used, in pixels.
        /// <para>Default: <c>1024</c>.</para>
        /// </summary>
        [TransloaditJsonName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// The screen height that will be used, in pixels. By default this equals the length of the web page in pixels if <c>fullpage</c> is 
        /// set to <c>true</c>. If <c>fullpage</c> is set to <c>false</c>, the <c>height</c> parameter takes effect.
        /// <para>Default: <c> 768</c>.</para>
        /// </summary>
        [TransloaditJsonName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// The delay (in milliseconds) applied to allow the page and all of its JavaScript to render before taking the screenshot.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        [TransloaditJsonName("delay")]
        public int? Delay { get; set; }

        /// <summary>
        /// An object containing optional headers that will be passed along with the original request to the website. 
        /// For example, this parameter can be used to pass along an authorization token along with the request.
        /// </summary>
        [TransloaditJsonName("headers")]
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/html-convert/">/html/convert</a> Robot.
        /// </summary>
        public HtmlConvertRobot()
        {
            Robot = "/html/convert";
        }
    }
}
