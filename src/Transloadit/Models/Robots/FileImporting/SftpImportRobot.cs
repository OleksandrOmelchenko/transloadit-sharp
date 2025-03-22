using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/sftp/import</c> Robot.
    /// </summary>
    public class SftpImportRobot : RobotBase
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
        /// The path on your SFTP server where to search for files.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The port to use for the connection.
        /// <para>Default: <c>22</c>.</para>
        /// </summary>
        public int? Port { get; set; }

         /// <summary>
        /// Swift bucket.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// Swift host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Swift key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Swift secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Initializes <c>/sftp/import</c> Robot.
        /// </summary>
        public SftpImportRobot()
        {
            Robot = "/sftp/import";
        }
    }
}
