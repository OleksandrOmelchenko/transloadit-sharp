using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileExporting;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/ftp-store/">/ftp/store</a> Robot.
/// </summary>
public class FtpStoreRobot : StoreRobotBase
{
    /// <summary>
    /// The port to use for the FTP connection.
    /// <para>Default: <c>21</c>.</para>
    /// </summary>
    [TransloaditJsonName("port")]
    public int? Port { get; set; }

    /// <summary>
    /// The URL of the file in the result JSON. 
    /// </summary>
    [TransloaditJsonName("url_template")]
    public string UrlTemplate { get; set; }

    /// <summary>
    /// The SSL URL of the file in the result JSON.
    /// </summary>
    [TransloaditJsonName("ssl_url_template")]
    public string SslUrlTemplate { get; set; }

    /// <summary>
    /// Determines whether to establish a secure connection to the FTP server using SSL.
    /// <para>Default: <c>false</c>.</para>
    /// </summary>
    [TransloaditJsonName("secure")]
    public bool? Secure { get; set; }

    /// <summary>
    /// FTP host.
    /// </summary>
    [TransloaditJsonName("host")]
    public string Host { get; set; }

    /// <summary>
    /// FTP user.
    /// </summary>
    [TransloaditJsonName("user")]
    public string User { get; set; }

    /// <summary>
    /// FTP password.
    /// </summary>
    [TransloaditJsonName("password")]
    public string Password { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/ftp-store/">/ftp/store</a> Robot.
    /// </summary>
    public FtpStoreRobot()
    {
        Robot = "/ftp/store";
    }
}
