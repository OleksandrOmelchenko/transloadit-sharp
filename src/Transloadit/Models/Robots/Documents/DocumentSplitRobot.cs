using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    public class DocumentSplitRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<string, List<string>> Pages { get; set; }

        public DocumentSplitRobot()
        {
            Robot = "/document/split";
        }
    }
}
