using System.Collections.Generic;

namespace Transloadit.Models.Robots
{
    public abstract class RobotBase
    {
        public string Robot { get; protected set; }
    }

    public class ImportRobotBase : RobotBase
    {
        public AnyOf<bool, List<string>> IgnoreErrors { get; set; }
        public string Credentials { get; set; }
        public AnyOf<string, List<string>> Path { get; set; }
    }

    public class StoreRobotBase : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public string Credentials { get; set; }
        public AnyOf<string, List<string>> Path { get; set; }
    }

    public class PaginatedImportRobotBase : ImportRobotBase
    {
        public bool? Recursive { get; set; }
        public int? PageNumber { get; set; }
        public int? FilesPerPage { get; set; }
    }

    public class AdvancedUse
    {
        public AnyOf<List<string>, List<AdvancedStep>> Steps { get; set; }
        public bool? BundleSteps { get; set; }
        public bool? GroupByOriginal { get; set; }
        public List<string> Fields { get; set; }
    }

    public class AdvancedStep
    {
        public string Name { get; set; }
        public string As { get; set; }
        public string Fields { get; set; }
    }

    public class OutputMeta
    {
        public bool? HasTransparency { get; set; }
        public bool? DominantColors { get; set; }
        public bool? Colorspace { get; set; }
        public bool? MeanVolume { get; set; }
    }
}
