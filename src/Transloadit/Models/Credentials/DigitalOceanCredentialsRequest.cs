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
        public string Space { get; set; }

        /// <summary>
        /// DigitalOcean space region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// DigitalOcean space key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// DigitalOcean space secret.
        /// </summary>
        public string Secret { get; set; }
    }
}
