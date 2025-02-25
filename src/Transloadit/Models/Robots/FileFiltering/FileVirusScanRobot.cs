using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileFiltering
{
    /// <summary>
    /// Represents <c>/file/virusscan</c> Robot.
    /// </summary>
    public class FileVirusScanRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public bool? ErrorOnDecline { get; set; }
        public string ErrorMsg { get; set; }

        /// <summary>
        /// Initializes <c>/file/virusscan</c> Robot.
        /// </summary>
        public FileVirusScanRobot()
        {
            Robot = "/file/virusscan";
        }
    }
}
