using System.Collections.Generic;

namespace Transloadit.Models.Robots.MediaCataloging
{
    /// <summary>
    /// Represents <c>/file/hash</c> Robot.
    /// </summary>
    public class FileHashRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Algorithm { get; set; }

        /// <summary>
        /// Initializes <c>/file/hash</c> Robot.
        /// </summary>
        public FileHashRobot()
        {
            Robot = "/file/hash";
        }
    }
}
