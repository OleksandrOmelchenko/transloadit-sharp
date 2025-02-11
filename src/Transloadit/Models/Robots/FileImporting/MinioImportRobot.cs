namespace Transloadit.Models.Robots.FileImporting
{
    public class MinioImportRobot : PaginatedImportRobotBase
    {
        public MinioImportRobot()
        {
            Robot = "/minio/import";
        }
    }
}
