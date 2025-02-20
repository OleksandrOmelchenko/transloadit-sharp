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
        /// <summary>
        /// Gets or sets sorting property. One of <see cref="Constants.TemplateSortProperties"/>: <c>id</c>, <c>name</c>, <c>created</c>, <c>modified</c>.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Get or sets ordering direction. One of <see cref="Constants.Orderings"/>: <c>asc</c>, <c>desc</c>.
        /// </summary>
        public string Order { get; set; }
    }
}
