using Transloadit.Serialization.Attributes;

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
        [TransloaditJsonName("content")]
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
        [TransloaditJsonName("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// Backblaze App Key ID.
        /// </summary>
        [TransloaditJsonName("app_key_id")]
        public string AppKeyId { get; set; }

        /// <summary>
        /// Backblaze App Key.
        /// </summary>
        [TransloaditJsonName("app_key")]
        public string AppKey { get; set; }
    }
}
