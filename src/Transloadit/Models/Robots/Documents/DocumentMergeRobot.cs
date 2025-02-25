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

        /// <summary>
        /// An array of passwords for the input documents, in case they are encrypted. 
        /// The order of passwords must match the order of the documents as they are passed to the Robot.
        /// </summary>
        public List<string> InputPasswords { get; set; }

        /// <summary>
        /// If not empty, encrypts the output file and makes it accessible only by typing in this password.
        /// </summary>
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
