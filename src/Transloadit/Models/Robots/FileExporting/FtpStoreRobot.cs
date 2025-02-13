namespace Transloadit.Models.Robots.FileExporting
{
    public class FtpStoreRobot : StoreRobotBase
    {
        public int? Port { get; set; }
        public string UrlTemplate { get; set; }
        public string SslUrlTemplate { get; set; }
        public bool? Secure { get; set; }

        public FtpStoreRobot()
        {
            Robot = "/ftp/store";
        }
    }
}
