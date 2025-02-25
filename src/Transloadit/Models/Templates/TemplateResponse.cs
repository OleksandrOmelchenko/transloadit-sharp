using System;
using System.Collections.Generic;

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

        public TemplateContent Content { get; set; }

        /// <summary>
        /// Whether <a href="https://transloadit.com/docs/api/authentication/#signature-authentication">signature authentication</a> is required.
        /// </summary>
        public int RequireSignatureAuth { get; set; }

        public DateTimeOffset? TranscodingResultExpiry { get; set; }

        public DateTimeOffset? AssemblyStatusExpiry { get; set; }
    }

    public class TemplateContent
    {
        public Dictionary<string, Dictionary<string, object>> Steps { get; set; }
    }

    /// <summary>
    /// Represents Template deletion response.
    /// </summary>
    public class DeleteTemplateResponse : ResponseBase
    {

    }
}
