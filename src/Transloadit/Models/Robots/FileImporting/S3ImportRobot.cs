namespace Transloadit.Models.Robots.FileImporting
{
    public class S3ImportRobot : PaginatedImportRobotBase
    {
        public S3ImportRobot()
        {
            Robot = "/s3/import";
        }
    }
}
