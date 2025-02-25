namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Backblaze credentials request.
    /// </summary>
    public class BackblazeCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Backblaze credentials request.
        /// </summary>
        public BackblazeCredentialsRequest()
        {
            Type = "backblaze";
        }

        /// <summary>
        /// Backblaze credentials content.
        /// </summary>
        public BackblazeCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Backblaze credentials.
    /// </summary>
    public class BackblazeCredentialsContent
    {
        /// <summary>
        /// Backblaze bucket name.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// Backblaze App Key ID.
        /// </summary>
        public string AppKeyId { get; set; }

        /// <summary>
        /// Backblaze App Key.
        /// </summary>
        public string AppKey { get; set; }
    }
}
