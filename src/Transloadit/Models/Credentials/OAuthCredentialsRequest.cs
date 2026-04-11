using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents OAuth (companion) credentials request.
    /// </summary>
    public class OAuthCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes OAuth (companion) credentials request.
        /// </summary>
        public OAuthCredentialsRequest()
        {
            Type = "companion";
        }

        /// <summary>
        /// OAuth (companion) credentials content.
        /// </summary>
        [JsonProperty("content")]
        public OAuthCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents OAuth (companion) credentials.
    /// </summary>
    public class OAuthCredentialsContent
    {
        /// <summary>
        /// OAuth provider.
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// OAuth key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// OAuth secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
