using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileFiltering
{
    /// <summary>
    /// Represents <c>/file/virusscan</c> Robot.
    /// </summary>
    public class FileVirusScanRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// If this is set to <c>true</c> and one or more files are declined, the Assembly will be stopped and marked with an error.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? ErrorOnDecline { get; set; }

        /// <summary>
        /// The error message shown to your users (such as by Uppy) when a file is declined and <c>error_on_decline</c> is set to <c>true</c>.
        /// <para>Default: <c>One of your files was declined</c>.</para>
        /// </summary>
        public string ErrorMsg { get; set; }

        /// <summary>
        /// Initializes <c>/file/virusscan</c> Robot.
        /// </summary>
        public FileVirusScanRobot()
        {
            Robot = "/file/virusscan";
        }
    }
}
