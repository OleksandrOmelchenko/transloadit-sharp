namespace Transloadit.Models.Robots.FileImporting
{
    public class BackBlazeImportRobot : ImportRobotBase
    {
        public bool? Recursive { get; set; }
        public string StartFileName { get; set; }
        public int? FilesPerPage { get; set; }

        public BackBlazeImportRobot()
        {
            Robot = "/backblaze/import";
        }
    }
}
