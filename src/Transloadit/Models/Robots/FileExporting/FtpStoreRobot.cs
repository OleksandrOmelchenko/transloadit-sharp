namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/ftp/store</c> Robot.
    /// </summary>
    public class FtpStoreRobot : StoreRobotBase
    {
        public int? Port { get; set; }
        public string UrlTemplate { get; set; }
        public string SslUrlTemplate { get; set; }
        public bool? Secure { get; set; }

        /// <summary>
        /// Initializes <c>/ftp/store</c> Robot.
        /// </summary>
        public FtpStoreRobot()
        {
            Robot = "/ftp/store";
        }
    }
}
