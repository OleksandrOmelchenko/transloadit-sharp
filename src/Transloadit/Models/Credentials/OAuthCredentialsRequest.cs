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
        public string Provider { get; set; }

        /// <summary>
        /// OAuth key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// OAuth secret.
        /// </summary>
        public string Secret { get; set; }
    }
}
