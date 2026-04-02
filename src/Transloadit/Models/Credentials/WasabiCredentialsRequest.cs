using Newtonsoft.Json;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Wasabi credentials request.
    /// </summary>
    public class WasabiCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Wasabi credentials request.
        /// </summary>
        public WasabiCredentialsRequest()
        {
            Type = "wasabi";
        }

        /// <summary>
        /// Wasabi credentials content.
        /// </summary>
        [JsonProperty("content")]
        public WasabiCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Wasabi credentials.
    /// </summary>
    public class WasabiCredentialsContent
    {
        /// <summary>
        /// Wasabi host.
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Wasabi user.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        /// Wasabi password.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
