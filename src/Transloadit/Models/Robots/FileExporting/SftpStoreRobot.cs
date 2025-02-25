namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/sftp/store</c> Robot.
    /// </summary>
    public class SftpStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The URL of the file in the result JSON.
        /// </summary>
        public string UrlTemplate { get; set; }

        /// <summary>
        /// The SSL URL of the file in the result JSON.
        /// </summary>
        public string SslUrlTemplate { get; set; }

        /// <summary>
        /// This optional parameter controls how an uploaded file's permission bits are set. You can use any string format that the chmod 
        /// command would accept, such as <c>755</c>. If you don't specify this option, the file's permission bits aren't changed at all, 
        /// meaning it's up to your server's configuration (e.g. umask).
        /// </summary>
        public string FileChmod { get; set; }

        /// <summary>
        /// Initializes <c>/sftp/store</c> Robot.
        /// </summary>
        public SftpStoreRobot()
        {
            Robot = "/sftp/store";
        }
    }
}
