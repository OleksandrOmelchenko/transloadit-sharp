using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileFiltering
{
    /// <summary>
    /// Represents <c>/file/verify</c> Robot.
    /// </summary>
    public class FileVerifyRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public bool? ErrorOnDecline { get; set; }
        public string ErrorMsg { get; set; }
        public string VerifyToBe { get; set; }

        /// <summary>
        /// Initializes <c>/file/verify</c> Robot.
        /// </summary>
        public FileVerifyRobot()
        {
            Robot = "/file/verify";
        }
    }
}
