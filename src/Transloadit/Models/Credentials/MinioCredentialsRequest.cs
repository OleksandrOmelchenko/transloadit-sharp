namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents MinIO credentials request.
    /// </summary>
    public class MinioCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes MinIO credentials request.
        /// </summary>
        public MinioCredentialsRequest()
        {
            Type = "minio";
        }

        /// <summary>
        /// MinIO credentials content.
        /// </summary>
        public MinioCredentialsContent Content { get; set; }
    }

    /// <summary>
    /// Represents MinIO credentials.
    /// </summary>
    public class MinioCredentialsContent
    {
        /// <summary>
        /// MinIO bucket.
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// MinIO key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// MinIO secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// MinIO host.
        /// </summary>
        public string Host { get; set; }
    }
}
