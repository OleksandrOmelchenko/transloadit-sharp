using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.AI
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/text-translate/">/text/translate</a> Robot.
    /// </summary>
    public class TextTranslateRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Which AI provider to leverage. One of <see cref="Constants.AIProviders"/>: <c>aws</c> and <c>gcp</c>.
        /// </summary>
        [TransloaditJsonName("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// The desired language to translate to. If the exact language can't be found, a generic variant can be fallen back to. 
        /// For example, if you specify <c>en-US</c>, <c>en</c> will be used instead. Please consult the list of supported languages for each provider.
        /// <para>Default: <c>en</c>.</para>
        /// </summary>
        [TransloaditJsonName("target_language")]
        public string TargetLanguage { get; set; }

        /// <summary>
        /// The desired language to translate from. By default, both providers will detect this automatically, but there are cases where 
        /// specifying the source language prevents ambiguities. If the exact language can't be found, a generic variant can be fallen back to.
        /// For example, if you specify <c>en-US</c>, <c>en</c> will be used instead. Please consult the list of supported languages for each provider.
        /// </summary>
        [TransloaditJsonName("source_language")]
        public string SourceLanguage { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/text-translate/">/text/translate</a> Robot.
        /// </summary>
        public TextTranslateRobot()
        {
            Robot = "/text/translate";
        }
    }
}
