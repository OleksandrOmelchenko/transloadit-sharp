using System.Collections.Generic;

namespace Transloadit.Models.Robots.Code
{
    public class ScriptRunRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Script { get; set; }

        public ScriptRunRobot()
        {
            Robot = "/script/run";
        }
    }
}
