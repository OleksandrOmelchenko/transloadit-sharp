using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    public class SpeechTranscribeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Provider { get; set; }
        public string Granularity { get; set; }
        public string Format { get; set; }
        public string SourceLanguage { get; set; }

        public SpeechTranscribeRobot()
        {
            Robot = "/speech/transcribe";
        }
    }
}
