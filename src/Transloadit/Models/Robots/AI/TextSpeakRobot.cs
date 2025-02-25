using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <c>/text/speak</c> Robot.
    /// </summary>
    public class TextSpeakRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Prompt { get; set; }
        public string Provider { get; set; }
        public string TargetLanguage { get; set; }
        public string Voice { get; set; }
        public bool? Ssml { get; set; }

        /// <summary>
        /// Initializes <c>/text/speak</c> Robot.
        /// </summary>
        public TextSpeakRobot()
        {
            Robot = "/text/speak";
        }
    }
}
