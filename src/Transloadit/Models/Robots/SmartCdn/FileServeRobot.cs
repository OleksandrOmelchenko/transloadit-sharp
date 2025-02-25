using System.Collections.Generic;

namespace Transloadit.Models.Robots.SmartCdn
{
    /// <summary>
    /// Represents <c>/file/serve</c> Robot.
    /// </summary>
    public class FileServeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// An object containing a list of headers to be set for a file as we serve it to a CDN/web browser, such as 
        /// <c>{ FileURL: "${file.url_name}" }</c> which will be merged over the defaults, and can include any 
        /// available <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly Variable</a>.
        /// <para>Default: <c>{ "Access-Control-Allow-Headers": "X-Requested-With, Content-Type, Cache-Control, Accept, Content-Length, 
        /// Transloadit-Client, Authorization", "Access-Control-Allow-Methods": "POST, GET, PUT, DELETE, OPTIONS", 
        /// "Access-Control-Allow-Origin": "*", "Cache-Control": "public, max-age=259200, s-max-age=86400", 
        /// "Content-Type": "${file.mime}; charset=utf-8", "Transfer-Encoding": "chunked", "Transloadit-Assembly": "…", 
        /// "Transloadit-RequestID": "…" }</c>.</para>
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Initializes <c>/file/serve</c> Robot.
        /// </summary>
        public FileServeRobot()
        {
            Robot = "/file/serve";
        }
    }
}