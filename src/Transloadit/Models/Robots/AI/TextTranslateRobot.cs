using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <c>/text/translate</c> Robot.
    /// </summary>
    public class TextTranslateRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public string TargetLanguage { get; set; }
        public string SourceLanguage { get; set; }

        /// <summary>
        /// Initializes <c>/text/translate</c> Robot.
        /// </summary>
        public TextTranslateRobot()
        {
            Robot = "/text/translate";
        }
    }
}
