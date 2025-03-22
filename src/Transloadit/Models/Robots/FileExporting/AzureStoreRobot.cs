using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/azure/store</c> Robot.
    /// </summary>
    public class AzureStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The content type with which to store the file. By default this will be guessed by Azure.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The content encoding with which to store the file. By default this will be guessed by Azure.
        /// </summary>
        public string ContentEncoding { get; set; }

        /// <summary>
        /// The content language with which to store the file. By default this will be guessed by Azure.
        /// </summary>
        public string ContentLanguage { get; set; }

        /// <summary>
        /// The cache control header with which to store the file.
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// A JavaScript object containing a list of metadata to be set for this file on Azure, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Set this to a number to enable shared access signatures for your stored object. This reflects the number of seconds that 
        /// the signature will be valid for once the object is stored. Enabling this will attach the shared access signature (SAS) 
        /// to the result URL of your object.
        /// </summary>
        public int? SasExpiresIn { get; set; }

        /// <summary>
        /// Set this to a combination of <c>r</c> (read), <c>w</c> (write) and <c>d</c> (delete) for your shared access signatures (SAS) permissions.
        /// </summary>
        public string SasPermissions { get; set; }

        /// <summary>
        /// Azure blob storage account.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Azure blob storage key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Azure blob storage container.
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// Initializes <c>/azure/store</c> Robot.
        /// </summary>
        public AzureStoreRobot()
        {
            Robot = "/azure/store";
        }
    }
}
