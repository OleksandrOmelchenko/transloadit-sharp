using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.Code
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/script-run/">/script/run</a> Robot.
    /// </summary>
    public class ScriptRunRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// A string of JavaScript to evaluate. It has access to all JavaScript features available in a modern browser environment.
        /// </summary>
        [TransloaditJsonName("script")]
        public string Script { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/script-run/">/script/run</a> Robot.
        /// </summary>
        public ScriptRunRobot()
        {
            Robot = "/script/run";
        }
    }
}
