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

        /// <summary>
        /// Which AI provider to leverage. One of <see cref="Constants.AIProviders"/>: <c>aws</c> and <c>gcp</c>.
        /// </summary>
        public string Provider { get; set; }

         /// <summary>
        /// Whether to return a full response including coordinates for the text (<c>full</c>), or a flat list of the extracted phrases (<c>list</c>). 
        /// This parameter has no effect if the format parameter is set to <c>text</c>.
        /// <para>Default: <c>full</c>.</para>
        /// </summary>
        public string Granularity { get; set; }

        /// <summary>
        /// In what format to return the extracted text.
        /// <para>Default: <c>json</c>.</para>
        /// <list type="bullet">
        /// <item><c>json</c> returns a JSON file.</item>
        /// <item><c>meta</c> does not return a file, but stores the data inside Transloadit's file object (under <c>${file.meta.recognized_text}</c>, 
        /// which is an array of strings) that's passed around between encoding Steps, so that you can use the values to burn the data into videos, 
        /// filter on them, etc.</item>
        /// <item><c>text</c> returns the recognized text as a plain UTF-8 encoded text file.</item>
        /// </list>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// The spoken language of the audio or video. This will also be the language of the transcribed text. The language should be specified in the 
        /// <a href="https://www.rfc-editor.org/rfc/bcp/bcp47.txt">BCP-47</a> format, such as <c>en-GB</c>, <c>de-DE</c> or <c>fr-FR</c>.
        /// </summary>
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
