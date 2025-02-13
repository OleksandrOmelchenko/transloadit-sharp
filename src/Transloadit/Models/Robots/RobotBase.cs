using System.Collections.Generic;
using Transloadit.Serialization;

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
}
