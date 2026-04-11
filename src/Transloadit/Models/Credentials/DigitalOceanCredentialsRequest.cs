using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents DigitalOcean credentials request.
    /// </summary>
    public class DigitalOceanCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes DigitalOcean credentials request.
        /// </summary>
        public DigitalOceanCredentialsRequest()
        {
            Type = "digitalocean";
        }

        /// <summary>
        /// DigitalOcean credentials content.
        /// </summary>
        [JsonProperty("content")]
        public DigitalOceanCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents DigitalOcean credentials.
    /// </summary>
    public class DigitalOceanCredentialsContent
    {
        /// <summary>
        /// DigitalOcean space name.
        /// </summary>
        [JsonProperty("space")]
        public string Space { get; set; }

        /// <summary>
        /// DigitalOcean space region.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// DigitalOcean space key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// DigitalOcean space secret.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
