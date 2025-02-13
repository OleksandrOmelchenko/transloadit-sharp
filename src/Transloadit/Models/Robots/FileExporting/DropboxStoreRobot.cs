namespace Transloadit.Models.Robots.FileExporting
{
    public class DropboxStoreRobot : StoreRobotBase
    {
        public bool? CreateSharingLink { get; set; }

        public DropboxStoreRobot()
        {
            Robot = "/dropbox/store";
        }
    }
}
