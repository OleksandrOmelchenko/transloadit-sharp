using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <c>/html/convert</c> Robot.
    /// </summary>
    public class HtmlConvertRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The URL of the web page to be converted. Optional, as you can also upload/import HTML files and pass it to this Robot.
        /// </summary>
        public string Url { get; set; }


        public string Format { get; set; }

        /// <summary>
        /// Determines if a screenshot of the full page should be taken or not.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? Fullpage { get; set; }

        /// <summary>
        /// Determines whether to preserve a transparent background in HTML pages. Useful if you're generating artwork in HTML that you want 
        /// to overlay on e.g. a video. This parameter is only used when <c>format</c> is not <c>pdf</c>.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? OmitBackground { get; set; }

        /// <summary>
        /// The screen width that will be used, in pixels.
        /// <para>Default: <c>1024</c>.</para>
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// The screen height that will be used, in pixels. By default this equals the length of the web page in pixels if <c>fullpage</c> is 
        /// set to <c>true</c>. If <c>fullpage</c> is set to <c>false</c>, the <c>height</c> parameter takes effect.
        /// <para>Default: <c> 768</c>.</para>
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// The delay (in milliseconds) applied to allow the page and all of its JavaScript to render before taking the screenshot.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        public int? Delay { get; set; }

        /// <summary>
        /// An object containing optional headers that will be passed along with the original request to the website. 
        /// For example, this parameter can be used to pass along an authorization token along with the request.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Initializes <c>/html/convert</c> Robot.
        /// </summary>
        public HtmlConvertRobot()
        {
            Robot = "/html/convert";
        }
    }
}
