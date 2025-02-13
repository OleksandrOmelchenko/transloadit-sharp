using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    public class HtmlConvertRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Url { get; set; }
        public string Format { get; set; }
        public bool? Fullpage { get; set; }
        public bool? OmitBackground { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Delay { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public HtmlConvertRobot()
        {
            Robot = "/html/convert";
        }
    }
}
