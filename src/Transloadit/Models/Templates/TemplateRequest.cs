using System.Collections.Generic;
using Transloadit.Models.Robots;

namespace Transloadit.Models.Templates
{
    public class TemplateRequest : BaseParams
    {
        public string Name { get; set; }

        public int RequireSignatureAuth { get; set; }

        public TemplateRequestContent Template { get; set; }
    }

    public class TemplateRequestContent
    {
        public Dictionary<string, RobotBase> Steps { get; set; }
    }

    public class TemplateListRequest : PaginationParams
    {
        public string Sort { get; set; } //["id", "name", "created", "modified"]

        public string Order { get; set; } //desc, asc
    }
}
