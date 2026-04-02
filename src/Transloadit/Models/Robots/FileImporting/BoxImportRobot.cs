using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/box/import</c> Robot.
    /// </summary>
    public class BoxImportRobot : ImportRobotBase
    {
        /// <summary>
        /// Custom name for imported files.
        /// </summary>
        [JsonProperty("force_name")]
        public AnyOf<string, List<string>> ForceName { get; set; }

        /// <summary>
        /// Initializes <c>/box/import</c> Robot.
        /// </summary>
        public BoxImportRobot()
        {
            Robot = "/box/import";
        }
    }
}
