using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/document-split/">/document/split</a> Robot.
    /// </summary>
    public class DocumentSplitRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The pages to extract from the document. Pages can be selected either through their page number 
        /// (starting at 1, e.g. "5") or through an inclusive range (e.g. "1-10").
        /// </summary>
        [JsonProperty("pages")]
        public AnyOf<string, List<string>> Pages { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/document-split/">/document/split</a> Robot.
        /// </summary>
        public DocumentSplitRobot()
        {
            Robot = "/document/split";
        }
    }
}
