using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/azure-store/">/azure/store</a> Robot.
    /// </summary>
    public class AzureStoreRobot : StoreRobotBase
    {
        /// <summary>
        /// The content type with which to store the file. By default this will be guessed by Azure.
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        /// <summary>
        /// The content encoding with which to store the file. By default this will be guessed by Azure.
        /// </summary>
        [JsonProperty("content_encoding")]
        public string ContentEncoding { get; set; }

        /// <summary>
        /// The content language with which to store the file. By default this will be guessed by Azure.
        /// </summary>
        [JsonProperty("content_language")]
        public string ContentLanguage { get; set; }

        /// <summary>
        /// The cache control header with which to store the file.
        /// </summary>
        [JsonProperty("cache_control")]
        public string CacheControl { get; set; }

        /// <summary>
        /// A JavaScript object containing a list of metadata to be set for this file on Azure, such as <c>{ FileURL: "${file.url_name}" }</c>. 
        /// This can also include any available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly variables</a>.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Set this to a number to enable shared access signatures for your stored object. This reflects the number of seconds that 
        /// the signature will be valid for once the object is stored. Enabling this will attach the shared access signature (SAS) 
        /// to the result URL of your object.
        /// </summary>
        [JsonProperty("sas_expires_in")]
        public int? SasExpiresIn { get; set; }

        /// <summary>
        /// Set this to a combination of <c>r</c> (read), <c>w</c> (write) and <c>d</c> (delete) for your shared access signatures (SAS) permissions.
        /// </summary>
        [JsonProperty("sas_permissions")]
        public string SasPermissions { get; set; }

        /// <summary>
        /// Azure blob storage account.
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// Azure blob storage key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Azure blob storage container.
        /// </summary>
        [JsonProperty("container")]
        public string Container { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/azure-store/">/azure/store</a> Robot.
        /// </summary>
        public AzureStoreRobot()
        {
            Robot = "/azure/store";
        }
    }
}
