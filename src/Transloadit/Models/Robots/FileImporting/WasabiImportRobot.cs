using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/wasabi-import/">/wasabi/import</a> Robot.
    /// </summary>
    public class WasabiImportRobot : PaginatedImportRobotBase
    {
        /// <summary>
        /// Wasabi host.
        /// </summary>
        [TransloaditJsonName("host")]
        public string Host { get; set; }

        /// <summary>
        /// Wasabi user.
        /// </summary>
        [TransloaditJsonName("user")]
        public string User { get; set; }

        /// <summary>
        /// Wasabi password.
        /// </summary>
        [TransloaditJsonName("password")]
        public string Password { get; set; }

        /// <summary>
        /// If set to <c>true</c>, the Robot will not import the actual files yet, but instead returns an empty file stub that includes a URL from where the file can be imported by subsequent Robots.
        /// This should only be set if all subsequent Steps use Robots that support file stubs.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [TransloaditJsonName("return_file_stubs")]
        public bool? ReturnFileStubs { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/wasabi-import/">/wasabi/import</a> Robot.
        /// </summary>
        public WasabiImportRobot()
        {
            Robot = "/wasabi/import";
        }
    }
}
