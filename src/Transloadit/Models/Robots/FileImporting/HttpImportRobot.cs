using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/http/import</c> Robot.
    /// </summary>
    public class HttpImportRobot : RobotBase
    {
        /// <summary>
        /// "Ignore errors" mode. Possible array members are <c>meta</c> and <c>import</c>. 
        /// You might see an error when trying to extract metadata from your imported files. This happens, for example, for files with a size of zero bytes. Including <c>"meta"</c> in the array will cause the Robot to not stop the import (and the entire Assembly) when that happens.
        /// Including <c>"import"</c> in the array will ensure the Robot does not cease to function on any import errors either.
        /// Setting this parameter to <c>true</c> will set it to <c>["meta", "import"]</c> internally.
        /// </summary>
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }

        /// <summary>
        /// The URL from which the file to be imported can be retrieved. You can also specify an array of URLs or a string of <c>|</c> 
        /// delimited URLs to import several files at once. Please also check the <c>url_delimiter</c> parameter for that.
        /// </summary>
        public AnyOf<string, List<string>> Url { get; set; }

        /// <summary>
        /// Provides the delimiter that is used to split the URLs in your <c>url</c> parameter value.
        /// <para>Default: <c>|</c>.</para>
        /// </summary>
        public string UrlDelimiter { get; set; }

        /// <summary>
        /// Custom headers to be sent for file import. This is an empty array by default, such that no additional headers except 
        /// the necessary ones (e.g. Host) are sent.
        /// </summary>
        public List<string> Headers { get; set; }

        /// <summary>
        /// Custom name for the imported file(s). Defaults to <c>null</c>, which means the file names are derived from the supplied URL(s).
        /// </summary>
        public AnyOf<string, List<string>> ForceName { get; set; }

        /// <summary>
        /// Setting this to <c>meta</c> will still import the file on metadata extraction errors. <c>ignore_errors</c> is similar, 
        /// it also ignores the error and makes sure the Robot doesn't stop, but it doesn't import the file.
        /// </summary>
        public List<string> ImportOnErrors { get; set; }

        /// <summary>
        /// Disable the internal retry mechanism, and fail immediately if a resource can't be imported. This can be useful for performance critical applications.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? FailFast { get; set; }

        /// <summary>
        /// Initializes <c>/http/import</c> Robot.
        /// </summary>
        public HttpImportRobot()
        {
            Robot = "/http/import";
        }
    }
}
