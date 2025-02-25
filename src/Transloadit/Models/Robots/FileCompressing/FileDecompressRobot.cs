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

        /// <summary>
        /// "Ignore errors" mode. Possible array members are <c>meta</c> and <c>import</c>. 
        /// You might see an error when trying to extract metadata from your imported files. This happens, for example, for files with a size of zero bytes. Including <c>"meta"</c> in the array will cause the Robot to not stop the import (and the entire Assembly) when that happens.
        /// Including <c>"import"</c> in the array will ensure the Robot does not cease to function on any import errors either.
        /// Setting this parameter to <c>true</c> will set it to <c>["meta", "import"]</c> internally.
        /// </summary>
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
