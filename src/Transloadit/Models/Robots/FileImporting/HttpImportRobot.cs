using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/http-import/">/http/import</a> Robot.
    /// </summary>
    public class HttpImportRobot : RobotBase
    {
        /// <summary>
        /// The URL from which the file to be imported can be retrieved. You can also specify an array of URLs or a string of <c>|</c> 
        /// delimited URLs to import several files at once. Please also check the <c>url_delimiter</c> parameter for that.
        /// </summary>
        [TransloaditJsonName("url")]
        public AnyOf<string, List<string>> Url { get; set; }

        /// <summary>
        /// Provides the delimiter that is used to split the URLs in your <c>url</c> parameter value.
        /// <para>Default: <c>|</c>.</para>
        /// </summary>
        [TransloaditJsonName("url_delimiter")]
        public string UrlDelimiter { get; set; }

        /// <summary>
        /// Custom headers to be sent for file import. This is an empty array by default, such that no additional headers except 
        /// the necessary ones (e.g. Host) are sent.
        /// </summary>
        [TransloaditJsonName("headers")]
        public List<string> Headers { get; set; }

        /// <summary>
        /// Custom name for the imported file(s). Defaults to <c>null</c>, which means the file names are derived from the supplied URL(s).
        /// </summary>
        [TransloaditJsonName("force_name")]
        public AnyOf<string, List<string>> ForceName { get; set; }

        /// <summary>
        /// Setting this to <c>meta</c> will still import the file on metadata extraction errors. <c>ignore_errors</c> is similar, 
        /// it also ignores the error and makes sure the Robot doesn't stop, but it doesn't import the file.
        /// </summary>
        [TransloaditJsonName("import_on_errors")]
        public List<string> ImportOnErrors { get; set; }

        /// <summary>
        /// Disable the internal retry mechanism, and fail immediately if a resource can't be imported. This can be useful for performance critical applications.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [TransloaditJsonName("fail_fast")]
        public bool? FailFast { get; set; }

        /// <summary>
        /// If set to <c>true</c>, the Robot will not import the actual files yet, but instead returns an empty file stub that includes a URL from where the file can be imported by subsequent Robots.
        /// This should only be set if all subsequent Steps use Robots that support file stubs.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [TransloaditJsonName("return_file_stubs")]
        public bool? ReturnFileStubs { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/http-import/">/http/import</a> Robot.
        /// </summary>
        public HttpImportRobot()
        {
            Robot = "/http/import";
        }
    }
}
