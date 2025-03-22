using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transloadit.Serialization;

namespace Transloadit.Models.Templates
{
    /// <summary>
    /// Represents a Template.
    /// </summary>
    public class TemplateResponse : ResponseBase
    {
        /// <summary>
        /// Template id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Template content.
        /// </summary>
        public TemplateContent Content { get; set; }

        /// <summary>
        /// Whether <a href="https://transloadit.com/docs/api/authentication/#signature-authentication">signature authentication</a> is required.
        /// </summary>
        [JsonConverter(typeof(BooleanToIntConverter))]
        public bool RequireSignatureAuth { get; set; }

        /// <summary>
        /// Transcoding result expiration date.
        /// </summary>
        public DateTimeOffset? TranscodingResultExpiry { get; set; }

        /// <summary>
        /// Assembly status expiration date.
        /// </summary>
        public DateTimeOffset? AssemblyStatusExpiry { get; set; }
    }

    /// <summary>
    /// Represents template content.
    /// </summary>
    public class TemplateContent
    {
        /// <summary>
        /// Assembly instructions.
        /// </summary>
        public Dictionary<string, Dictionary<string, object>> Steps { get; set; }
    }

    /// <summary>
    /// Represents Template deletion response.
    /// </summary>
    public class DeleteTemplateResponse : ResponseBase
    {

    }
}
