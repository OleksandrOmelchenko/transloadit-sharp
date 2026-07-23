using Transloadit.Serialization.Attributes;

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
        [TransloaditJsonName("content")]
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
        [TransloaditJsonName("space")]
        public string Space { get; set; }

        /// <summary>
        /// DigitalOcean space region.
        /// </summary>
        [TransloaditJsonName("region")]
        public string Region { get; set; }

        /// <summary>
        /// DigitalOcean space key.
        /// </summary>
        [TransloaditJsonName("key")]
        public string Key { get; set; }

        /// <summary>
        /// DigitalOcean space secret.
        /// </summary>
        [TransloaditJsonName("secret")]
        public string Secret { get; set; }
    }
}
