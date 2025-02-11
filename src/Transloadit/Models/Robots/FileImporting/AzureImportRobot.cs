namespace Transloadit.Models.Robots.FileImporting
{
    public class AzureImportRobot : ImportRobotBase
    {
        public string NextPageToken { get; set; }
        public int? FilesPerPage { get; set; }

        //public bool Recursive { get; set; } //not in docs, but mentioned in other field
        public AzureImportRobot()
        {
            Robot = "/azure/import";
        }

    }
}
