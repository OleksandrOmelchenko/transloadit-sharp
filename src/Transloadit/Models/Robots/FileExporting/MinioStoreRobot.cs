using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/minio/store</c> Robot.
    /// </summary>
    public class MinioStoreRobot : StoreRobotBase
    {
        public string Acl { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public int? SignUrlsFor { get; set; }

        /// <summary>
        /// Initializes <c>/minio/store</c> Robot.
        /// </summary>
        public MinioStoreRobot()
        {
            Robot = "/minio/store";
        }
    }
}
