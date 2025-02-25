using System.Collections.Generic;

namespace Transloadit.Models.Robots.SmartCdn
{
    /// <summary>
    /// Represents <c>/file/serve</c> Robot.
    /// </summary>
    public class FileServeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Initializes <c>/file/serve</c> Robot.
        /// </summary>
        public FileServeRobot()
        {
            Robot = "/file/serve";
        }
    }
}