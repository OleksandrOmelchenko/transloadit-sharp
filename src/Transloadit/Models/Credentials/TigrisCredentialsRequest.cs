using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Tigris credentials request.
    /// </summary>
    public class TigrisCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Tigris credentials request.
        /// </summary>
        public TigrisCredentialsRequest()
        {
            Type = "tigris";
        }

        /// <summary>
        /// Tigris credentials content.
        /// </summary>
        [JsonProperty("content")]
        public TigrisCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Tigris credentials.
    /// </summary>
    public class TigrisCredentialsContent
    {
        /// <summary>
        /// The name of the bucket to which the file is exported.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// The custom domain for Tigris bucket location.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Tigris access key ID.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Tigris secret access Key.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
