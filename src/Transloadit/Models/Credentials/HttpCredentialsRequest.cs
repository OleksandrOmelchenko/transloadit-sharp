using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents HTTP credentials request.
    /// </summary>
    public class HttpCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes HTTP credentials request.
        /// </summary>
        public HttpCredentialsRequest()
        {
            Type = "http";
        }

        /// <summary>
        /// HTTP credentials content.
        /// </summary>
        [JsonProperty("content")]
        public HttpCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents HTTP credentials.
    /// </summary>
    public class HttpCredentialsContent
    {
        /// <summary>
        /// HTTP headers.
        /// </summary>
        [JsonProperty("headers")]
        public string Headers { get; set; }
    }
}
