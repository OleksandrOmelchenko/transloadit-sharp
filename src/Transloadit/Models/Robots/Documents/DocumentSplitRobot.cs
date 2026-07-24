using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/document-split/">/document/split</a> Robot.
    /// </summary>
    public class DocumentSplitRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The pages to extract from the document. Pages can be selected either through their page number 
        /// (starting at 1, e.g. "5") or through an inclusive range (e.g. "1-10").
        /// </summary>
        [TransloaditJsonName("pages")]
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
