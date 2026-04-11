using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Swift credentials request.
    /// </summary>
    public class SwiftCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Swift credentials request.
        /// </summary>
        public SwiftCredentialsRequest()
        {
            Type = "swift";
        }

        /// <summary>
        /// Swift credentials content.
        /// </summary>
        [JsonProperty("content")]
        public SwiftCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Swift credentials.
    /// </summary>
    public class SwiftCredentialsContent
    {
        /// <summary>
        /// Swift bucket.
        /// </summary>
        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// Swift host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Swift key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Swift secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
