namespace Transloadit.Models.Robots.FileExporting
{
    public class SftpStoreRobot : StoreRobotBase
    {
        public string UrlTemplate { get; set; }
        public string SslUrlTemplate { get; set; }
        public string FileChmod { get; set; }

        public SftpStoreRobot()
        {
            Robot = "/sftp/store";
        }
    }
}
