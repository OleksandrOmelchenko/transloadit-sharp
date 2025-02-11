namespace Transloadit.Models.Robots.FileImporting
{
    public class RackSpaceCloudFilesImportRobot : PaginatedImportRobotBase
    {
        public RackSpaceCloudFilesImportRobot()
        {
            Robot = "/cloudfiles/import";
        }
    }
}
