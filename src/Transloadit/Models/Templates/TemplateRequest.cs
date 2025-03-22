using System.Collections.Generic;
using Newtonsoft.Json;
using Transloadit.Models.Robots;
using Transloadit.Serialization;

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
        /// Use <c>true</c> to deny requests that do not include a signature.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [JsonConverter(typeof(BooleanToIntConverter))]
        public bool RequireSignatureAuth { get; set; }

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
        /// <summary>
        /// Whether to allow overriding template steps. Set this to <c>false</c> to disallow 
        /// <a href="https://transloadit.com/docs/topics/templates/#overruling-templates-at-runtime">Overruling Templates at Runtime</a>. 
        /// If set to <c>false</c> then <c>template_id</c> and <c>steps</c> will be mutually exclusive and only supply one of those parameters 
        /// may be supplied.
        /// <para>Default: <c>true</c>.</para>
        /// </summary>
        public bool? AllowStepsOverride { get; set; }

        /// <summary>
        /// Whether to exclude Assembly data in the response. If set to <c>true</c>, a successful Assembly response will only include the 
        /// <c>ok</c> and <c>assembly_id</c> fields. An erroneous Assembly will only include the <c>error</c>, <c>http_code</c>, 
        /// <c>message</c> and <c>assembly_id</c> fields. 
        /// The full Assembly Status will then still be sent to the <c>notify_url</c> if one was specified.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Quiet { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// An object of pairs (name -> value) that can be used as 
        /// <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly Variables</a>.
        /// </summary>
        public Dictionary<string, object> Fields { get; set; }

        /// <summary>
        /// Assembly instructions.
        /// </summary>
        public Dictionary<string, RobotBase> Steps { get; set; }
    }

    /// <summary>
    /// Represents template list pagination settings.
    /// </summary>
    public class TemplateListRequest : PaginationParams
    {
        /// <summary>
        /// Sorting property. One of <see cref="Constants.TemplateSortProperties"/>: <c>id</c>, <c>name</c>, <c>created</c>, <c>modified</c>.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Ordering direction. One of <see cref="Constants.Orderings"/>: <c>asc</c>, <c>desc</c>.
        /// </summary>
        public string Order { get; set; }
    }
}
