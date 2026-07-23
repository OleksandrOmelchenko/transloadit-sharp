using Transloadit.Serialization.Attributes;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileExporting
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/tus-store/">/tus/store</a> Robot.
    /// </summary>
    public class TusStoreRobot : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [TransloaditJsonName("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The URL of the Tus-compatible server, which you're uploading files to.
        /// </summary>
        [TransloaditJsonName("endpoint")]
        public string Endpoint { get; set; }

        /// <summary>
        /// Template credentials name.
        /// </summary>
        [TransloaditJsonName("credentials")]
        public string Credentials { get; set; }

        /// <summary>
        /// Optional extra headers outside of the Template Credentials can be passed along within this parameter.
        /// </summary>
        [TransloaditJsonName("headers")]
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Metadata to pass along to destination. Includes some file info by default.
        /// <para>Default: <c>{ "filename": "example.png", "basename": "example", "extension": "png" }</c>.</para>
        /// </summary>
        [TransloaditJsonName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// The URL of the file in the Assembly Status JSON.
        /// </summary>
        [TransloaditJsonName("url_template")]
        public string UrlTemplate { get; set; }

        /// <summary>
        /// The SSL URL of the file in the Assembly Status JSON.
        /// </summary>
        [TransloaditJsonName("ssl_url_template")]
        public string SslUrlTemplate { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/tus-store/">/tus/store</a> Robot.
        /// </summary>
        public TusStoreRobot()
        {
            Robot = "/tus/store";
        }
    }
}
