using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <c>/tus/store</c> Robot.
    /// </summary>
    public class TusStoreRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The URL of the Tus-compatible server, which you're uploading files to.
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Template credentials name.
        /// </summary>
        public string Credentials { get; set; }

        /// <summary>
        /// Optional extra headers outside of the Template Credentials can be passed along within this parameter.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Metadata to pass along to destination. Includes some file info by default.
        /// <para>Default: <c>{ "filename": "example.png", "basename": "example", "extension": "png" }</c>.</para>
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// The URL of the file in the Assembly Status JSON.
        /// </summary>
        public string UrlTemplate { get; set; }

        /// <summary>
        /// The SSL URL of the file in the Assembly Status JSON.
        /// </summary>
        public string SslUrlTemplate { get; set; }

        /// <summary>
        /// Initializes <c>/tus/store</c> Robot.
        /// </summary>
        public TusStoreRobot()
        {
            Robot = "/tus/store";
        }
    }
}
