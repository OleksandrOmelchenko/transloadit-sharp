using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.FileImporting
{
    public class HttpImportRobot : RobotBase
    {
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }
        public AnyOf<string, List<string>> Url { get; set; }
        public string UrlDelimiter { get; set; }
        public List<string> Headers { get; set; }
        public AnyOf<string, List<string>> ForceName { get; set; }
        public List<string> ImportOnErrors { get; set; }
        public bool? FailFast { get; set; }

        public HttpImportRobot()
        {
            Robot = "/http/import";
        }
    }
}
