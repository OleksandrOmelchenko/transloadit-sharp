using System.Collections.Generic;
using Newtonsoft.Json;

namespace Transloadit.Models.Robots.FileCompressing
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/file-decompress/">/file/decompress</a> Robot.
    /// </summary>
    public class FileDecompressRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/file-decompress/">/file/decompress</a> Robot.
        /// </summary>
        public FileDecompressRobot()
        {
            Robot = "/file/decompress";
        }
    }
}
