using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileImporting
{
    /// <summary>
    /// Represents <c>/http/import</c> Robot.
    /// </summary>
    public class HttpImportRobot : RobotBase
    {
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }
        public AnyOf<string, List<string>> Url { get; set; }
        public string UrlDelimiter { get; set; }
        public List<string> Headers { get; set; }
        public AnyOf<string, List<string>> ForceName { get; set; }
        public List<string> ImportOnErrors { get; set; }
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
