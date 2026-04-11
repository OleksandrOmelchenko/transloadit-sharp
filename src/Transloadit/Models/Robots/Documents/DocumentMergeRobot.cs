using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots.Documents
{
    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/robots/document-merge/">/document/merge</a> Robot.
    /// </summary>
    public class DocumentMergeRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// An array of passwords for the input documents, in case they are encrypted. 
        /// The order of passwords must match the order of the documents as they are passed to the Robot.
        /// </summary>
        [JsonProperty("input_passwords")]
        public List<string> InputPasswords { get; set; }

        /// <summary>
        /// If not empty, encrypts the output file and makes it accessible only by typing in this password.
        /// </summary>
        [JsonProperty("output_password")]
        public string OutputPassword { get; set; }

        /// <summary>
        /// Initializes <a href="https://transloadit.com/docs/robots/document-merge/">/document/merge</a> Robot.
        /// </summary>
        public DocumentMergeRobot()
        {
            Robot = "/document/merge";
        }
    }
}
