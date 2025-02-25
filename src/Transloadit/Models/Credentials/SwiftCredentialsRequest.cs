namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Swift credentials request.
    /// </summary>
    public class SwiftCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes Swift credentials request.
        /// </summary>
        public SwiftCredentialsRequest()
        {
            Type = "swift";
        }

        /// <summary>
        /// Swift credentials content.
        /// </summary>
        public SwiftCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents Swift credentials.
    /// </summary>
    public class SwiftCredentialsContent
    {
        /// <summary>
        /// Swift bucket.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// Swift host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Swift key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Swift secret.
        /// </summary>
        public string Secret { get; set; }
    }
}
