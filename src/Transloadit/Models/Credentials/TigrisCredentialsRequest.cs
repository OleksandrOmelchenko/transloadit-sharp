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
        public string Bucket { get; set; }

        /// <summary>
        /// The custom domain for Tigris bucket location.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Tigris access key ID.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Tigris secret access Key.
        /// </summary>
        public string Secret { get; set; }
    }
}
