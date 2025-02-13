using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    public class TextSpeakRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Prompt { get; set; }
        public string Provider { get; set; }
        public string TargetLanguage { get; set; }
        public string Voice { get; set; }
        public bool? Ssml { get; set; }

        public TextSpeakRobot()
        {
            Robot = "/text/speak";
        }
    }
}
