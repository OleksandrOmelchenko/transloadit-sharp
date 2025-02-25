using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <c>/file/read</c> Robot.
    /// </summary>
    public class FileReadRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Initializes <c>/file/read</c> Robot.
        /// </summary>
        public FileReadRobot()
        {
            Robot = "/file/read";
        }
    }
}
