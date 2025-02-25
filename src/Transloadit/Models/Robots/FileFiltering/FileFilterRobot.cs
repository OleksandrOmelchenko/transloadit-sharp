using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileFiltering
{
    /// <summary>
    /// Represents <c>/file/filter</c> Robot.
    /// </summary>
    public class FileFilterRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<string, List<List<string>>> Accepts { get; set; }
        public AnyOf<string, List<List<string>>> Declines { get; set; }
        public string ConditionType { get; set; }
        public bool? ErrorOnDecline { get; set; }
        public string ErrorMsg { get; set; }

        /// <summary>
        /// Initializes <c>/file/filter</c> Robot.
        /// </summary>
        public FileFilterRobot()
        {
            Robot = "/file/filter";
        }
    }
}
