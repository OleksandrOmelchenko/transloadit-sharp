using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/backblaze/store</c> Robot.
    /// </summary>
    public class BackBlazeStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// A JavaScript object containing a list of metadata to be set for this file on backblaze, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Backblaze bucket name.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// Backblaze App Key ID.
        /// </summary>
        public string AppKeyId { get; set; }

        /// <summary>
        /// Backblaze App Key.
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// Initializes <c>/backblaze/store</c> Robot.
        /// </summary>
        public BackBlazeStoreRobot()
        {
            Robot = "/backblaze/store";
        }
    }
}
