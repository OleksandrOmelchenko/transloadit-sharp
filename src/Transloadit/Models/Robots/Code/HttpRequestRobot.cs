using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.Code;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/http-request/">/http/request</a> Robot.
/// <para>Calls an HTTP endpoint during the Assembly and expects optional JSON describing zero or more input files
/// or result-file URLs to emit from this Step. Your endpoint must return a 2xx response.</para>
/// </summary>
public class HttpRequestRobot : RobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// The HTTP or HTTPS endpoint to call.
    /// </summary>
    [TransloaditJsonName("url")]
    public string Url { get; set; }

    /// <summary>
    /// HTTP method to use for the request. One of <c>DELETE</c>, <c>GET</c>, <c>PATCH</c>, <c>POST</c>, or <c>PUT</c>.
    /// <para>Default: <c>POST</c>.</para>
    /// </summary>
    [TransloaditJsonName("method")]
    public string Method { get; set; }

    /// <summary>
    /// Controls what is sent to your endpoint.
    /// <list type="bullet">
    /// <item><c>none</c> sends no request body.</item>
    /// <item><c>metadata</c> sends a JSON body with Assembly metadata, fields, the previous Step, and file metadata.</item>
    /// <item><c>file</c> sends multipart form data with a <c>payload</c> JSON field and the first input file as a <c>file</c> part.</item>
    /// <item><c>files</c> sends multipart form data with a <c>payload</c> JSON field and all input files as repeated <c>files[]</c> parts.</item>
    /// </list>
    /// <para>Default: <c>none</c>.</para>
    /// </summary>
    [TransloaditJsonName("payload")]
    public string Payload { get; set; }

    /// <summary>
    /// Custom request headers. Can be specified as an object map of header names to values, or an array of strings
    /// in the format <c>"Header-Name: value"</c>.
    /// </summary>
    [TransloaditJsonName("headers")]
    public AnyOf<Dictionary<string, string>, List<string>> Headers { get; set; }

    /// <summary>
    /// Maximum number of seconds to wait for the HTTP request. The effective timeout is the lower of this value and
    /// Transloadit's server-side cap.
    /// <para>Default: <c>60</c>.</para>
    /// </summary>
    [TransloaditJsonName("timeout")]
    public int? Timeout { get; set; }

    /// <summary>
    /// Maximum accepted response size in bytes. The response should normally be a small JSON document.
    /// <para>Default: <c>1048576</c>.</para>
    /// </summary>
    [TransloaditJsonName("max_response_size")]
    public int? MaxResponseSize { get; set; }

    /// <summary>
    /// Maximum number of files that the endpoint may return.
    /// <para>Default: <c>10</c>.</para>
    /// </summary>
    [TransloaditJsonName("max_result_files")]
    public int? MaxResultFiles { get; set; }

    /// <summary>
    /// Maximum allowed size in bytes for each result file returned by URL.
    /// <para>Default: <c>104857600</c>.</para>
    /// </summary>
    [TransloaditJsonName("max_result_file_size")]
    public long? MaxResultFileSize { get; set; }

    /// <summary>
    /// Maximum number of seconds to spend downloading each result file returned by URL.
    /// <para>Default: <c>120</c>.</para>
    /// </summary>
    [TransloaditJsonName("result_download_timeout")]
    public int? ResultDownloadTimeout { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/http-request/">/http/request</a> Robot.
    /// </summary>
    public HttpRequestRobot()
    {
        Robot = "/http/request";
    }
}
