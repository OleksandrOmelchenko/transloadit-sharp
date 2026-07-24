using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Tokens
{
    /// <summary>
    /// Represents bearer token request payload.
    /// </summary>
    public class TokenRequest
    {
        /// <summary>
        /// OAuth2 grant type. Must be <c>client_credentials</c>.
        /// </summary>
        [TransloaditJsonName("grant_type")]
        public string GrantType { get; set; } = "client_credentials";

        /// <summary>
        /// Optional token scopes, separated by spaces.
        /// </summary>
        [TransloaditJsonName("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Optional audience.
        /// </summary>
        [TransloaditJsonName("aud")]
        public string Aud { get; set; }
    }
}
