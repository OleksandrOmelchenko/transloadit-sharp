using System.Collections.Generic;

namespace Transloadit.Models.Robots.MediaCataloging
{
    /// <summary>
    /// Represents <c>/file/hash</c> Robot.
    /// </summary>
    public class FileHashRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The hashing algorithm to use. One of <see cref="Constants.FileHashingAlgorithms"/>: <c>b2</c>, <c>md5</c>, <c>sha1</c>, 
        /// <c>sha224</c>, <c>sha256</c>, <c>sha384</c> and <c>sha512</c>.
        /// </summary>
        public string Algorithm { get; set; }

        /// <summary>
        /// Initializes <c>/file/hash</c> Robot.
        /// </summary>
        public FileHashRobot()
        {
            Robot = "/file/hash";
        }
    }
}
