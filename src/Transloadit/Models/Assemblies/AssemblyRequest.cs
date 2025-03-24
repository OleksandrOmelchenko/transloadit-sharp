using System.Collections.Generic;
using Newtonsoft.Json;
using Transloadit.Models.Robots;
using Transloadit.Serialization;

namespace Transloadit.Models.Assemblies
{
    /// <summary>
    /// Represents a request when creating or updating an Assembly.
    /// </summary>
    public class AssemblyRequest : BaseParams
    {
        /// <summary>
        /// Assembly instructions.
        /// </summary>
        public Dictionary<string, RobotBase> Steps { get; set; }

        /// <summary>
        /// Template id.
        /// </summary>
        public string TemplateId { get; set; }

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
        /// Whether to exclude Assembly data in the response. If set to <c>true</c>, a successful Assembly response will only include the 
        /// <c>ok</c> and <c>assembly_id</c> fields. An erroneous Assembly will only include the <c>error</c>, <c>http_code</c>, 
        /// <c>message</c> and <c>assembly_id</c> fields. 
        /// The full Assembly Status will then still be sent to the <c>notify_url</c> if one was specified.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Quiet { get; set; }
    }

    /// <summary>
    /// Represents Assembly list request.
    /// </summary>
    public class AssemblyListRequest : PaginationParams
    {
        /// <summary>
        /// Get or sets assembly status. One of <see cref="Constants.ListAssemlyStatuses"/>:
        /// <c>all</c>, <c>uploading</c>, <c>executing</c>, <c>canceled</c>, <c>completed</c>, <c>failed</c>, <c>request_aborted</c>.
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// Represents replay Assembly request.
    /// </summary>
    public class ReplayAssemblyRequest : BaseParams
    {
        /// <summary>
        /// Assembly instructions.
        /// </summary>
        public Dictionary<string, RobotBase> Steps { get; set; }

        /// <summary>
        /// Template id.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// Notification url to which Transloadit will send Assembly status when the Assembly is completed.
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// An object of pairs (name -> value) that can be used as <a href="https://transloadit.com/docs/topics/assembly-instructions/#assembly-variables">Assembly Variables</a>.
        /// </summary>
        public Dictionary<string, object> Fields { get; set; }

        /// <summary>
        /// Whether to reparse the template.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        [JsonConverter(typeof(BooleanToIntConverter))]
        public bool? ReparseTemplate { get; set; }
    }
}
