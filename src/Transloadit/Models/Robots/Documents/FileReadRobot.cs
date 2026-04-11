using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/file-read/">/file/read</a> Robot.
    /// </summary>
    public class FileReadRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/file-read/">/file/read</a> Robot.
        /// </summary>
        public FileReadRobot()
        {
            Robot = "/file/read";
        }
    }
}
