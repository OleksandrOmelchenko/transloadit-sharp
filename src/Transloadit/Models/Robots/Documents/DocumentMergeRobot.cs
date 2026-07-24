using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.Documents;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/document-merge/">/document/merge</a> Robot.
/// </summary>
public class DocumentMergeRobot : ProcessingRobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// An array of passwords for the input documents, in case they are encrypted. 
    /// The order of passwords must match the order of the documents as they are passed to the Robot.
    /// </summary>
    [TransloaditJsonName("input_passwords")]
    public List<string> InputPasswords { get; set; }

    /// <summary>
    /// If not empty, encrypts the output file and makes it accessible only by typing in this password.
    /// </summary>
    [TransloaditJsonName("output_password")]
    public string OutputPassword { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/document-merge/">/document/merge</a> Robot.
    /// </summary>
    public DocumentMergeRobot()
    {
        Robot = "/document/merge";
    }
}
