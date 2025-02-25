using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <c>/speech/transcribe</c> Robot.
    /// </summary>
    public class SpeechTranscribeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public string Granularity { get; set; }
        public string Format { get; set; }
        public string SourceLanguage { get; set; }

        /// <summary>
        /// Initializes <c>/speech/transcribe</c> Robot.
        /// </summary>
        public SpeechTranscribeRobot()
        {
            Robot = "/speech/transcribe";
        }
    }
}
