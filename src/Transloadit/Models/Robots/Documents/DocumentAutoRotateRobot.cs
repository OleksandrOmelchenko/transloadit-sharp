using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.Documents;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/document-autorotate/">/document/autorotate</a> Robot.
/// </summary>
public class DocumentAutoRotateRobot : ProcessingRobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/document-autorotate/">/document/autorotate</a> Robot.
    /// </summary>
    public DocumentAutoRotateRobot()
    {
        Robot = "/document/autorotate";
    }
}
