using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileFiltering
{
    /// <summary>
    /// Represents <c>/file/verify</c> Robot.
    /// </summary>
    public class FileVerifyRobot : RobotBase
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
        /// The type that you want to match against to ensure your file is of this type. For example, <c>image</c> will verify whether uploaded 
        /// files are images. This also works against file media types, in this case <c>image/png</c> would also work to match against specifically
        /// <c>png</c> files.
        /// <para>Default: <c>pdf</c>.</para>
        /// </summary>
        public string VerifyToBe { get; set; }

        /// <summary>
        /// Initializes <c>/file/verify</c> Robot.
        /// </summary>
        public FileVerifyRobot()
        {
            Robot = "/file/verify";
        }
    }
}
