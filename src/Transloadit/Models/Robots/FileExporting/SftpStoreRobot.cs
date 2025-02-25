namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/sftp/store</c> Robot.
    /// </summary>
    public class SftpStoreRobot : StoreRobotBase
    {
        public string UrlTemplate { get; set; }
        public string SslUrlTemplate { get; set; }
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
