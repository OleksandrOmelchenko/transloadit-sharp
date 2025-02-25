using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <c>/document/split</c> Robot.
    /// </summary>
    public class DocumentSplitRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<string, List<string>> Pages { get; set; }

        /// <summary>
        /// Initializes <c>/document/split</c> Robot.
        /// </summary>
        public DocumentSplitRobot()
        {
            Robot = "/document/split";
        }
    }
}
