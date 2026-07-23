using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.SmartCdn
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/tlcdn-deliver/">/tlcdn/deliver</a> Robot.
    /// </summary>
    public class TlcdnDeliverRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/tlcdn-deliver/">/tlcdn/deliver</a> Robot.
        /// </summary>
        public TlcdnDeliverRobot()
        {
            Robot = "/tlcdn/deliver";
        }
    }
}
