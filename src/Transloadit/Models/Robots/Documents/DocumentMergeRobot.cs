using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <c>/document/merge</c> Robot.
    /// </summary>
    public class DocumentMergeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public List<string> InputPasswords { get; set; }
        public string OutputPassword { get; set; }

        /// <summary>
        /// Initializes <c>/document/merge</c> Robot.
        /// </summary>
        public DocumentMergeRobot()
        {
            Robot = "/document/merge";
        }
    }
}
