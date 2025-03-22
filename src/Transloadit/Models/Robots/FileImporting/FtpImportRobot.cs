using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/ftp/import</c> Robot.
    /// </summary>
    public class FtpImportRobot : RobotBase
    {
        /// <summary>
        /// "Ignore errors" mode. Possible array members are <c>meta</c> and <c>import</c>. 
        /// You might see an error when trying to extract metadata from your imported files. This happens, for example, for files with a size of zero bytes. Including <c>"meta"</c> in the array will cause the Robot to not stop the import (and the entire Assembly) when that happens.
        /// Including <c>"import"</c> in the array will ensure the Robot does not cease to function on any import errors either.
        /// Setting this parameter to <c>true</c> will set it to <c>["meta", "import"]</c> internally.
        /// </summary>
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }

        /// <summary>
        /// Template credentials name.
        /// </summary>
        public string Credentials { get; set; }

        /// <summary>
        /// The path to the specific file or directory.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The port to use for the FTP connection.
        /// <para>Default: <c>21</c>.</para>
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Determines if passive mode should be used for the FTP connection.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? PassiveMode { get; set; }

        /// <summary>
        /// FTP host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// FTP user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// FTP password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Initializes <c>/ftp/import</c> Robot.
        /// </summary>
        public FtpImportRobot()
        {
            Robot = "/ftp/import";
        }
    }
}
