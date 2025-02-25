using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileFiltering
{
    /// <summary>
    /// Represents <c>/file/filter</c> Robot.
    /// </summary>
    public class FileFilterRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Files that match at least one requirement will be accepted, or declined otherwise. If the array is empty, all files will be accepted. 
        /// Example: <c>[["${file.mime}", "==", "image/gif"]]</c>. If the condition_type parameter is set to <c>and</c>, then all requirements must
        /// match for the file to be accepted.
        /// </summary>
        public AnyOf<string, List<List<string>>> Accepts { get; set; }

        /// <summary>
        /// Files that match at least one requirement will be declined, or accepted otherwise. Example: <c>[["${file.size}",">","1024"]]</c>. 
        /// If the condition_type parameter is set to <c>and</c>, then all requirements must match for the file to be declined.
        /// </summary>
        public AnyOf<string, List<List<string>>> Declines { get; set; }

        /// <summary>
        /// Specifies the condition type according to which the members of the accepts or declines arrays should be evaluated. 
        /// Can be <c>or</c> or <c>and</c>.
        /// <para>Default: <c>or</c>.</para>
        /// </summary>
        public string ConditionType { get; set; }

        /// <summary>
        /// If this is set to <c>true</c> and one or more files are declined, the Assembly will be stopped and marked with an error.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? ErrorOnDecline { get; set; }

        /// <summary>
        /// The error message shown to your users (such as by Uppy) when a file is declined and <c>error_on_decline</c> is set to <c>true</c>.
        /// <para>Default: <c>One of your files was declined</c>.</para>
        /// </summary>
        public string ErrorMsg { get; set; }

        /// <summary>
        /// Initializes <c>/file/filter</c> Robot.
        /// </summary>
        public FileFilterRobot()
        {
            Robot = "/file/filter";
        }
    }
}
