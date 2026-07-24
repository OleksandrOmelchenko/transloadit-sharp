using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileImporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/tigris-import/">/tigris/import</a> Robot.
/// </summary>
public class TigrisImportRobot : PaginatedImportRobotBase
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

    /// <summary>
    /// If set to <c>true</c>, the Robot will not import the actual files yet, but instead returns an empty file stub that includes a URL from where the file can be imported by subsequent Robots.
    /// This should only be set if all subsequent Steps use Robots that support file stubs.
    /// <para>Default: <c>false</c>.</para>
    /// </summary>
    [TransloaditJsonName("return_file_stubs")]
    public bool? ReturnFileStubs { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/tigris-import/">/tigris/import</a> Robot.
    /// </summary>
    public TigrisImportRobot()
    {
        Robot = "/tigris/import";
    }
}
