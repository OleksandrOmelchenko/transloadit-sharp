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
        /// <summary>
        /// Get or sets assembly status. One of <see cref="Constants.AssemlyStatuses"/>:
        /// <c>all</c>, <c>uploading</c>, <c>executing</c>, <c>canceled</c>, <c>completed</c>, <c>failed</c>, <c>request_aborted</c>.
        /// </summary>
        public string Type { get; set; }
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
