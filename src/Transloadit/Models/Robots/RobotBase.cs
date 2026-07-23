using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models.Robots
{
    /// <summary>
    /// Represents base class for all Robots.
    /// </summary>
    public abstract class RobotBase
    {
        /// <summary>
        /// Robot which should process the files. For example <c>/ftp/import</c>.
        /// </summary>
        public string Robot { get; protected set; }

        /// <summary>
        /// Whether the results of this Robot should be present in the Assembly Status JSON.
        /// <para>Default: <c>true</c> for leaf Steps and <c>false</c> for any intermediate Step.</para>
        /// </summary>
        [JsonProperty("result")]
        public bool? Result { get; set; }

        /// <summary>
        /// Whether to force the Robot to accept a file type it would have ignored.
        /// With the value set to <c>true</c> you can force Robots to accept all files thrown at them. This will typically lead to errors and should only be used for debugging or combatting edge cases.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [JsonProperty("force_accept")]
        public bool? ForceAccept { get; set; }

        /// <summary>
        /// Optional expensive metadata extraction settings.
        /// </summary>
        [JsonProperty("output_meta")]
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }

        /// <summary>
        /// Controls whether Assembly Variables are interpolated for individual instruction fields.
        /// Set this to <c>false</c> to treat every instruction field as literal text, or set individual field paths (such as <c>path</c>, or a dotted path like <c>ffmpeg.vf</c> for nested objects) to <c>false</c> to treat only those fields as literal text.
        /// </summary>
        [JsonProperty("interpolate")]
        public AnyOf<bool, Dictionary<string, object>> Interpolate { get; set; }

        /// <summary>
        /// Setting the queue to <c>batch</c> manually downgrades the priority of jobs for this Step, to avoid consuming Priority job slots for jobs that don't need zero queue waiting times.
        /// </summary>
        [JsonProperty("queue")]
        public string Queue { get; set; }
    }

    /// <summary>
    /// Represents base class for non-import Robots, which support the <c>ignore_errors</c> parameter.
    /// </summary>
    public abstract class ProcessingRobotBase : RobotBase
    {
        /// <summary>
        /// "Ignore errors" mode. Possible array members are <c>meta</c> and <c>convert</c>.
        /// You might see an error when trying to extract metadata from your files. This happens, for example, for files with a size of zero bytes. Including <c>"meta"</c> in the array will cause the Robot to not stop (and the entire Assembly) when that happens.
        /// Setting this parameter to <c>true</c> will ignore all errors.
        /// </summary>
        [JsonProperty("ignore_errors")]
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }
    }

    /// <summary>
    /// Represents base class for import Robots.
    /// </summary>
    public abstract class ImportRobotBase : RobotBase
    {
        /// <summary>
        /// Template credentials name.
        /// </summary>
        [JsonProperty("credentials")]
        public string Credentials { get; set; }

        /// <summary>
        /// The path to the specific file or directory.
        /// </summary>
        [JsonProperty("path")]
        public AnyOf<string, List<string>> Path { get; set; }

        /// <summary>
        /// Custom name for the imported file(s). By default file names are derived from the source.
        /// </summary>
        [JsonProperty("force_name")]
        public AnyOf<string, List<string>> ForceName { get; set; }

        /// <summary>
        /// Setting this to <c>["meta"]</c> will still import the file on metadata extraction errors.
        /// This is similar to <c>ignore_errors</c>, which also ignores the error and makes sure the Robot doesn't stop, but unlike this parameter it does not import the file.
        /// </summary>
        [JsonProperty("import_on_errors")]
        public List<string> ImportOnErrors { get; set; }
    }

    /// <summary>
    /// Represents base class for store Robots.
    /// </summary>
    public abstract class StoreRobotBase : ProcessingRobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        [JsonProperty("use")]
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Template credentials name.
        /// </summary>
        [JsonProperty("credentials")]
        public string Credentials { get; set; }

        /// <summary>
        /// The path at which the file is to be stored.
        /// </summary>
        [JsonProperty("path")]
        public AnyOf<string, List<string>> Path { get; set; }
    }

    /// <summary>
    /// Represents base class for Robots supporting paginated import.
    /// </summary>
    public abstract class PaginatedImportRobotBase : ImportRobotBase
    {
        /// <summary>
        /// The value which enables importing files from subdirectories and sub-subdirectories (etc.) of the given path.
        /// </summary>
        [JsonProperty("recursive")]
        public bool? Recursive { get; set; }

        /// <summary>
        /// The pagination page number. 
        /// For now, in order to not break backwards compatibility in non-recursive imports, this only works when recursive is set to <c>true</c>.
        /// </summary>
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// The pagination page size. This only works when recursive is <c>true</c> for now, 
        /// in order to not break backwards compatibility in non-recursive imports.
        /// </summary>
        [JsonProperty("files_per_page")]
        public int? FilesPerPage { get; set; }
    }

    /// <summary>
    /// Represents an advanced <c>use</c> parameter.
    /// </summary>
    public class AdvancedUse
    {
        /// <summary>
        /// The list of Steps to use as input.
        /// </summary>
        [JsonProperty("steps")]
        public AnyOf<List<string>, List<AdvancedStep>> Steps { get; set; }

        /// <summary>
        /// Whether to gather several Step results for a single invocation.
        /// For example, <c>/file/compress</c> would normally create one archive for each file passed to it. 
        /// However, if you set the value to <c>true</c>, it will create one archive containing all the result files from every Step you hand it.
        /// </summary>
        [JsonProperty("bundle_steps")]
        public bool? BundleSteps { get; set; }

        /// <summary>
        /// Whether to organize output files by their originating input file.
        /// It is essential in workflows where you want to ensure outputs are grouped with the input file that produced them, 
        /// for example when using the <c>/file/compress</c> Robot.
        /// </summary>
        [JsonProperty("group_by_original")]
        public bool? GroupByOriginal { get; set; }

        /// <summary>
        /// The list to filter files based on their field names. When this array is specified, 
        /// the corresponding Step will only be executed for files submitted through one of the given field names.
        /// </summary>
        [JsonProperty("fields")]
        public List<string> Fields { get; set; }
    }

    /// <summary>
    /// Represents the advanced Step configuration.
    /// </summary>
    public class AdvancedStep
    {
        /// <summary>
        /// The name of the Step.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The input name for Robots which can take several inputs.
        /// </summary>
        [JsonProperty("as")]
        public string As { get; set; }

        /// <summary>
        /// The value to specify the file base on its field name.
        /// </summary>
        [JsonProperty("fields")]
        public string Fields { get; set; }
    }

    /// <summary>
    /// Represents a set of metadata of processed files.
    /// </summary>
    public class OutputMeta
    {
        /// <summary>
        /// Whether to extract if the image contains transparent parts.
        /// </summary>
        [JsonProperty("has_transparency")]
        public bool? HasTransparency { get; set; }

        /// <summary>
        /// Whether to extract an array of hexadecimal color codes from the image.
        /// </summary>
        [JsonProperty("dominant_colors")]
        public bool? DominantColors { get; set; }

        /// <summary>
        /// Whether to extract the colorspace of the output video.
        /// </summary>
        [JsonProperty("colorspace")]
        public bool? Colorspace { get; set; }

        /// <summary>
        /// Whether to get a single value representing the mean average volume of the audio file.
        /// </summary>
        [JsonProperty("mean_volume")]
        public bool? MeanVolume { get; set; }
    }
}
