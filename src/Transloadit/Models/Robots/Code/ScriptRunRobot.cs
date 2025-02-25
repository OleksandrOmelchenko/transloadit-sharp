using System.Collections.Generic;

namespace Transloadit.Models.Robots.Code
{
    /// <summary>
    /// Represents <c>/script/run</c> Robot.
    /// </summary>
    public class ScriptRunRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// A string of JavaScript to evaluate. It has access to all JavaScript features available in a modern browser environment.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// Intializes <c>/script/run</c> Robot.
        /// </summary>
        public ScriptRunRobot()
        {
            Robot = "/script/run";
        }
    }
}
