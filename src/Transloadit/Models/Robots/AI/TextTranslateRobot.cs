using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.AI
{
    public class TextTranslateRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public string TargetLanguage { get; set; }
        public string SourceLanguage { get; set; }

        public TextTranslateRobot()
        {
            Robot = "/text/translate";
        }
    }
}
