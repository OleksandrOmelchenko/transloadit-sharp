using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.SmartCdn
{
    /// <summary>
    /// Represents <c>/tlcdn/deliver</c> Robot.
    /// </summary>
    public class TlcdnDeliverRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Optional expensive metadata extraction settings.
        /// </summary>
        [JsonProperty("output_meta")]
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// Initializes <c>/tlcdn/deliver</c> Robot.
        /// </summary>
        public TlcdnDeliverRobot()
        {
            Robot = "/tlcdn/deliver";
        }
    }
}
