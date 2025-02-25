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
        public string Host { get; set; }

        /// <summary>
        /// Wasabi user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Wasabi password.
        /// </summary>
        public string Password { get; set; }
    }
}
