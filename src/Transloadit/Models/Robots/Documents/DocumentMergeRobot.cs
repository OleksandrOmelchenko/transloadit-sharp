using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    public class DocumentMergeRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public List<string> InputPasswords { get; set; }
        public string OutputPassword { get; set; }

        public DocumentMergeRobot()
        {
            Robot = "/document/merge";
        }
    }
}
