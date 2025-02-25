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
        public string Url { get; set; }
        public string Format { get; set; }
        public bool? Fullpage { get; set; }
        public bool? OmitBackground { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Delay { get; set; }
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
