using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <c>/document/autorotate</c> Robot.
    /// </summary>
    public class DocumentAutoRotateRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Initializes <c>/document/autorotate</c> Robot.
        /// </summary>
        public DocumentAutoRotateRobot()
        {
            Robot = "/document/autorotate";
        }
    }
}
