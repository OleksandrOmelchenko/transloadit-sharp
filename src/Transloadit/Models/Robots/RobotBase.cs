using System.Collections.Generic;

namespace Transloadit.Models.Robots
{
    /// <summary>
    /// Represents base class for all Robots.
    /// </summary>
    public abstract class RobotBase
    {
        /// <summary>
        /// Gets or sets Robot which should process the files. For example <c>/ftp/import</c>.
        /// </summary>
        public string Robot { get; protected set; }

        /// <summary>
        /// Gets or sets the value that controls whether the results of this Robot should be present in the Assembly Status JSON.
        /// <para>Default: <c>true</c> for leaf Steps and <c>false</c> for any intermediate Step.</para>
        /// </summary>
        public bool? Result { get; set; }

        /// <summary>
        /// Gets or sets the value that forces a Robot to accept a file type it would have ignored.
        /// With the value set to <c>true</c> you can force Robots to accept all files thrown at them. This will typically lead to errors and should only be used for debugging or combatting edge cases.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? ForceAccept { get; set; }
    }

    /// <summary>
    /// Represents base class for import Robots.
    /// </summary>
    public abstract class ImportRobotBase : RobotBase
    {
        /// <summary>
        /// Get or sets "ignore errors" mode. Possible array members are <c>meta</c> and <c>import</c>. 
        /// You might see an error when trying to extract metadata from your imported files. This happens, for example, for files with a size of zero bytes. Including <c>"meta"</c> in the array will cause the Robot to not stop the import (and the entire Assembly) when that happens.
        /// Including <c>"import"</c> in the array will ensure the Robot does not cease to function on any import errors either.
        /// Setting this parameter to <c>true</c> will set it to <c>["meta", "import"]</c> internally.
        /// </summary>
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }

        /// <summary>
        /// Get or sets template credentials name.
        /// </summary>
        public string Credentials { get; set; }

        /// <summary>
        /// Get or sets the path to the specific file or directory.
        /// </summary>
        public AnyOf<string, List<string>> Path { get; set; }
    }

    /// <summary>
    /// Represents base class for store Robots.
    /// </summary>
    public abstract class StoreRobotBase : RobotBase
    {
        /// <summary>
        /// Gets or sets which steps to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Get or sets template credentials name.
        /// </summary>
        public string Credentials { get; set; }

        /// <summary>
        /// Gets or sets the path at which the file is to be stored.
        /// </summary>
        public AnyOf<string, List<string>> Path { get; set; }
    }

    /// <summary>
    /// Represents base class for Robots supporting paginated import.
    /// </summary>
    public abstract class PaginatedImportRobotBase : ImportRobotBase
    {
        /// <summary>
        /// Gets or sets the value which enables importing files from subdirectories and sub-subdirectories (etc.) of the given path.
        /// </summary>
        public bool? Recursive { get; set; }

        /// <summary>
        /// Gets or sets the pagination page number. 
        /// For now, in order to not break backwards compatibility in non-recursive imports, this only works when recursive is set to <c>true</c>.
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// The pagination page size. This only works when recursive is <c>true</c> for now, 
        /// in order to not break backwards compatibility in non-recursive imports.
        /// </summary>
        public int? FilesPerPage { get; set; }
    }

    /// <summary>
    /// Represents an advanced <c>use</c> parameter.
    /// </summary>
    public class AdvancedUse
    {
        /// <summary>
        /// Gets or sets the list of Steps to use as input.
        /// </summary>
        public AnyOf<List<string>, List<AdvancedStep>> Steps { get; set; }

        /// <summary>
        /// Gets or sets the value which controls whether to gather several Step results for a single invocation.
        /// For example, <c>/file/compress</c> would normally create one archive for each file passed to it. 
        /// However, if you set the value to <c>true</c>, it will create one archive containing all the result files from every Step you hand it.
        /// </summary>
        public bool? BundleSteps { get; set; }

        /// <summary>
        /// Gets or sets the value which controls whether to organize output files by their originating input file.
        /// It is essential in workflows where you want to ensure outputs are grouped with the input file that produced them, 
        /// for example when using the <c>/file/compress</c> Robot.
        /// </summary>
        public bool? GroupByOriginal { get; set; }

        /// <summary>
        /// Gets or sets the list to filter files based on their field names. When this array is specified, 
        /// the corresponding Step will only be executed for files submitted through one of the given field names.
        /// </summary>
        public List<string> Fields { get; set; }
    }

    /// <summary>
    /// Represents the advanced Step configuration.
    /// </summary>
    public class AdvancedStep
    {
        /// <summary>
        /// Gets or sets the name of the Step.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the input name for Robots which can take several inputs.
        /// </summary>
        public string As { get; set; }

        /// <summary>
        /// Gets or sets the value to specify the file base on its field name.
        /// </summary>
        public string Fields { get; set; }
    }

    /// <summary>
    /// Represents a set of metadata of processed files.
    /// </summary>
    public class OutputMeta
    {
        /// <summary>
        /// Gets or sets the value which controls whether to extract if the image contains transparent parts.
        /// </summary>
        public bool? HasTransparency { get; set; }

        /// <summary>
        /// Gets or sets the value which controls whether to extract an array of hexadecimal color codes from the image.
        /// </summary>
        public bool? DominantColors { get; set; }

        /// <summary>
        /// Gets or sets the value which controls whether to extract the colorspace of the output video.
        /// </summary>
        public bool? Colorspace { get; set; }

        /// <summary>
        /// Gets or sets the value which controls whether to get a single value representing the mean average volume of the audio file.
        /// </summary>
        public bool? MeanVolume { get; set; }
    }
}
