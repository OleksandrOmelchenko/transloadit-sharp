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

        /// <summary>
        /// Which AI provider to leverage. One of <see cref="Constants.AIProviders"/>: <c>aws</c> and <c>gcp</c>.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// The desired language to translate to. If the exact language can't be found, a generic variant can be fallen back to. 
        /// For example, if you specify <c>en-US</c>, <c>en</c> will be used instead. Please consult the list of supported languages for each provider.
        /// <para>Default: <c>en</c>.</para>
        /// </summary>
        public string TargetLanguage { get; set; }

        /// <summary>
        /// The desired language to translate from. By default, both providers will detect this automatically, but there are cases where 
        /// specifying the source language prevents ambiguities. If the exact language can't be found, a generic variant can be fallen back to.
        /// For example, if you specify <c>en-US</c>, <c>en</c> will be used instead. Please consult the list of supported languages for each provider.
        /// </summary>
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
