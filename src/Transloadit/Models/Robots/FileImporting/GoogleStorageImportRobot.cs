namespace Transloadit.Models.Robots.FileImporting
{
    public class GoogleStorageImportRobot : ImportRobotBase
    {
        public bool? Recursive { get; set; }
        public string NextPageToken { get; set; }
        public int? FilesPerPage { get; set; }

        public GoogleStorageImportRobot()
        {
            Robot = "/google/import";
        }
    }
}
