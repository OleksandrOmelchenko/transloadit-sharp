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

        /// <summary>
        /// Which text to speak. You can also set this to <c>null</c> and supply an input text file.
        /// </summary>
        public string Prompt { get; set; }

        /// <summary>
        /// Which AI provider to leverage. One of <see cref="Constants.AIProviders"/>: <c>aws</c> and <c>gcp</c>.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// The written language of the document. This will also be the language of the spoken text. The language should be specified in the 
        /// <a href="https://www.rfc-editor.org/rfc/bcp/bcp47.txt">BCP-47</a> format, such as <c>en-GB</c>, <c>de-DE</c> or <c>fr-FR</c>.
        /// <para>Default: <c>en-US</c>.</para>
        /// </summary>
        public string TargetLanguage { get; set; }

        /// <summary>
        /// The gender to be used for voice synthesis. Please consult the list of supported languages and voices.
        /// <para>Default: <c>female-1</c>.</para>
        /// </summary>
        public string Voice { get; set; }

        /// <summary>
        /// Supply Speech Synthesis Markup Language instead of raw text, in order to gain more control over how your text is voiced, 
        /// including rests and pronounciations.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
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
