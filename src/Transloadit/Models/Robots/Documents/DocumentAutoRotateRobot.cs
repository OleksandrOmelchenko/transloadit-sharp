using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.Documents
{
    public class DocumentAutoRotateRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        public DocumentAutoRotateRobot()
        {
            Robot = "/document/autorotate";
        }
    }
}
