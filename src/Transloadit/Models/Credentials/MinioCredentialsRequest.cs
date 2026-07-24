using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

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
    [TransloaditJsonName("content")]
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
    [TransloaditJsonName("bucket")]
    public string Bucket { get; set; }

    /// <summary>
    /// MinIO key.
    /// </summary>
    [TransloaditJsonName("key")]
    public string Key { get; set; }

    /// <summary>
    /// MinIO secret.
    /// </summary>
    [TransloaditJsonName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// MinIO host.
    /// </summary>
    [TransloaditJsonName("host")]
    public string Host { get; set; }
}
