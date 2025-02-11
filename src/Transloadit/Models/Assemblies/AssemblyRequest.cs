using System.Collections.Generic;
using Transloadit.Models.Robots;

namespace Transloadit.Models.Assemblies
{
    public class AssemblyRequest : BaseParams
    {
        public Dictionary<string, RobotBase> Steps { get; set; }

        public string TemplateId { get; set; }

        public string NotifyUrl { get; set; }

        public Dictionary<string, object> Fields { get; set; }

        public bool AllowStepsOverride { get; set; }

        public bool? Quiet { get; set; }
    }

    public class AssemblyListRequest : PaginationParams
    {
        public string Type { get; set; } //all, uploading, executing, canceled, completed, failed or request_aborted
    }

    public class ReplayAssemblyRequest : BaseParams
    {
        public Dictionary<string, RobotBase> Steps { get; set; }

        public string TemplateId { get; set; }

        public string NotifyUrl { get; set; }

        public Dictionary<string, object> Fields { get; set; }

        public int ReparseTemplate { get; set; }
    }
}
