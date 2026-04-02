using Newtonsoft.Json;

namespace Transloadit.Models.Tokens
{
    /// <summary>
    /// Represents bearer token response payload.
    /// </summary>
    public class TokenResponse : ResponseBase
    {
        /// <summary>
        /// Access token value.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Token type.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Token lifetime in seconds.
        /// </summary>
        [JsonProperty("expires_in")]
        public int? ExpiresIn { get; set; }

        /// <summary>
        /// Granted scope list.
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}
