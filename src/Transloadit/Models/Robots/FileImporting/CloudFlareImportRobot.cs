namespace Transloadit.Models.Robots.FileImporting
{
    public class CloudFlareImportRobot : PaginatedImportRobotBase
    {
        public CloudFlareImportRobot()
        {
            Robot = "/cloudflare/import";
        }
    }
}
