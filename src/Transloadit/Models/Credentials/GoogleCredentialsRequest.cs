using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents Google Cloud Storage credentials request.
/// </summary>
public class GoogleCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes Google Cloud Storage credentials request.
    /// </summary>
    public GoogleCredentialsRequest()
    {
        Type = "google";
    }

    /// <summary>
    /// Google Cloud Storage credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public GoogleCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents Google Cloud Storage credentials.
/// </summary>
public class GoogleCredentialsContent
{
    /// <summary>
    /// Google Cloud project id.
    /// </summary>
    [TransloaditJsonName("project_id")]
    public string ProjectId { get; set; }

    /// <summary>
    /// Contents of the service account JSON key file.
    /// </summary>
    [TransloaditJsonName("key_file_contents")]
    public string KeyFileContents { get; set; }

    /// <summary>
    /// Google Cloud Storage bucket name.
    /// </summary>
    [TransloaditJsonName("bucket")]
    public string Bucket { get; set; }
}
