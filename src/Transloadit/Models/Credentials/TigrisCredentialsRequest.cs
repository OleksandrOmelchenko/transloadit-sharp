using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Tigris credentials request.
    /// </summary>
    public class TigrisCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Tigris credentials request.
        /// </summary>
        public TigrisCredentialsRequest()
        {
            Type = "tigris";
        }

        /// <summary>
        /// Tigris credentials content.
        /// </summary>
        [TransloaditJsonName("content")]
        public TigrisCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Tigris credentials.
    /// </summary>
    public class TigrisCredentialsContent
    {
        /// <summary>
        /// The name of the bucket to which the file is exported.
        /// </summary>
        [TransloaditJsonName("bucket")]
        public string Bucket { get; set; }

        /// <summary>
        /// The custom domain for Tigris bucket location.
        /// </summary>
        [TransloaditJsonName("host")]
        public string Host { get; set; }

        /// <summary>
        /// Tigris access key ID.
        /// </summary>
        [TransloaditJsonName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Tigris secret access Key.
        /// </summary>
        [TransloaditJsonName("secret")]
        public string Secret { get; set; }
    }
}
