using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileFiltering
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/file-verify/">/file/verify</a> Robot.
    /// </summary>
    public class FileVerifyRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// If this is set to <c>true</c> and one or more files are declined, the Assembly will be stopped and marked with an error.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [JsonProperty("error_on_decline")]
        public bool? ErrorOnDecline { get; set; }

        /// <summary>
        /// The error message shown to your users (such as by Uppy) when a file is declined and <c>error_on_decline</c> is set to <c>true</c>.
        /// <para>Default: <c>One of your files was declined</c>.</para>
        /// </summary>
        [JsonProperty("error_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// The type that you want to match against to ensure your file is of this type. For example, <c>image</c> will verify whether uploaded 
        /// files are images. This also works against file media types, in this case <c>image/png</c> would also work to match against specifically
        /// <c>png</c> files.
        /// <para>Default: <c>pdf</c>.</para>
        /// </summary>
        [JsonProperty("verify_to_be")]
        public string VerifyToBe { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/file-verify/">/file/verify</a> Robot.
        /// </summary>
        public FileVerifyRobot()
        {
            Robot = "/file/verify";
        }
    }
}
