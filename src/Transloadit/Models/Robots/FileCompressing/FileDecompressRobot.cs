using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileCompressing
{
    /// <summary>
    /// Represents <c>/file/decompress</c> Robot.
    /// </summary>
    public class FileDecompressRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }

        /// <summary>
        /// Initializes <c>/file/decompress</c> Robot.
        /// </summary>
        public FileDecompressRobot()
        {
            Robot = "/file/decompress";
        }
    }
}
