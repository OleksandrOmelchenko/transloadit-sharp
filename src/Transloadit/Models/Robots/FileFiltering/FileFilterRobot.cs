using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Robots.FileFiltering;

/// <summary>
/// Represents <a href="https://transloadit.com/docs/robots/file-filter/">/file/filter</a> Robot.
/// </summary>
public class FileFilterRobot : ProcessingRobotBase
{
    /// <summary>
    /// Specifies which Step(s) to use as input.
    /// </summary>
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

    /// <summary>
    /// Files that match at least one requirement will be accepted, or declined otherwise. If the array is empty, all files will be accepted. 
    /// Example: <c>[["${file.mime}", "==", "image/gif"]]</c>. If the condition_type parameter is set to <c>and</c>, then all requirements must
    /// match for the file to be accepted.
    /// </summary>
    [TransloaditJsonName("accepts")]
    public AnyOf<string, List<List<string>>> Accepts { get; set; }

    /// <summary>
    /// Files that match at least one requirement will be declined, or accepted otherwise. Example: <c>[["${file.size}",">","1024"]]</c>. 
    /// If the condition_type parameter is set to <c>and</c>, then all requirements must match for the file to be declined.
    /// </summary>
    [TransloaditJsonName("declines")]
    public AnyOf<string, List<List<string>>> Declines { get; set; }

    /// <summary>
    /// Specifies the condition type according to which the members of the accepts or declines arrays should be evaluated. 
    /// Can be <c>or</c> or <c>and</c>.
    /// <para>Default: <c>or</c>.</para>
    /// </summary>
    [TransloaditJsonName("condition_type")]
    public string ConditionType { get; set; }

    /// <summary>
    /// If this is set to <c>true</c> and one or more files are declined, the Assembly will be stopped and marked with an error.
    /// <para>Default: <c>false</c>.</para>
    /// </summary>
    [TransloaditJsonName("error_on_decline")]
    public bool? ErrorOnDecline { get; set; }

    /// <summary>
    /// The error message shown to your users (such as by Uppy) when a file is declined and <c>error_on_decline</c> is set to <c>true</c>.
    /// <para>Default: <c>One of your files was declined</c>.</para>
    /// </summary>
    [TransloaditJsonName("error_msg")]
    public string ErrorMsg { get; set; }

    /// <summary>
    /// Initializes <a href="https://transloadit.com/docs/robots/file-filter/">/file/filter</a> Robot.
    /// </summary>
    public FileFilterRobot()
    {
        Robot = "/file/filter";
    }
}
