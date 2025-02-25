using System.Collections.Generic;
using Transloadit.Models.Robots;

namespace Transloadit.Models.Templates
{
    /// <summary>
    /// Represents template configuration.
    /// </summary>
    public class TemplateRequest : BaseParams
    {
        /// <summary>
        /// Gets or sets template name. Must be between 5-40 symbols (inclusive), lowercase, can only contain dashes and latin letters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value which controls whether signature is required when using the template. 
        /// Use <c>1</c> to deny requests that do not include a signature.
        /// <para>Default: <c>0</c>.</para>
        /// </summary>
        public int RequireSignatureAuth { get; set; }

        /// <summary>
        /// Gets or sets <a href="https://transloadit.com/docs/topics/assembly-instructions/">Assembly instructions</a>
        /// and <a href="https://transloadit.com/docs/topics/templates/">Template settings</a>.
        /// </summary>
        public TemplateRequestContent Template { get; set; }
    }

    /// <summary>
    /// Represents <a href="https://transloadit.com/docs/topics/assembly-instructions/">Assembly instructions</a>
    /// and <a href="https://transloadit.com/docs/topics/templates/">Template settings</a>.
    /// </summary>
    public class TemplateRequestContent
    {
        public bool AllowStepsOverride { get; set; }

        /// <summary>
        /// Gets or sets Assembly instructions.
        /// </summary>
        public Dictionary<string, RobotBase> Steps { get; set; }
    }

    /// <summary>
    /// Represents template list pagination settings.
    /// </summary>
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
