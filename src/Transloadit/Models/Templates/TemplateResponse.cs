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
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Template content.
        /// </summary>
        [JsonProperty("content")]
        public TemplateContent Content { get; set; }

        /// <summary>
        /// Whether <a href="https://transloadit.com/docs/api/authentication/#signature-authentication">signature authentication</a> is required.
        /// </summary>
        [JsonProperty("require_signature_auth")]
        [JsonConverter(typeof(BooleanToIntConverter))]
        public bool RequireSignatureAuth { get; set; }

        /// <summary>
        /// Transcoding result expiration date.
        /// </summary>
        [JsonProperty("transcoding_result_expiry")]
        public string TranscodingResultExpiry { get; set; }

        /// <summary>
        /// Assembly status expiration date.
        /// </summary>
        [JsonProperty("assembly_status_expiry")]
        public string AssemblyStatusExpiry { get; set; }
    }

    /// <summary>
    /// Represents Template model in Template list response.
    /// </summary>
    public class TemplateModel
    {
        /// <summary>
        /// Template id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Template encryption verion.
        /// </summary>
        [JsonProperty("encryption_version")]
        public int EncryptionVersion { get; set; }

        /// <summary>
        /// Whether <a href="https://transloadit.com/docs/api/authentication/#signature-authentication">signature authentication</a> is required.
        /// </summary>
        [JsonProperty("require_signature_auth")]
        [JsonConverter(typeof(BooleanToIntConverter))]
        public bool RequireSignatureAuth { get; set; }

        /// <summary>
        /// Transcoding result expiration date.
        /// </summary>
        [JsonProperty("transcoding_result_expiry")]
        public string TranscodingResultExpiry { get; set; }

        /// <summary>
        /// Assembly status expiration date.
        /// </summary>
        [JsonProperty("assembly_status_expiry")]
        public string AssemblyStatusExpiry { get; set; }

        /// <summary>
        /// The date when the Template was used last time.
        /// </summary>
        [JsonProperty("last_used")]
        public DateTimeOffset? LastUsed { get; set; }

        /// <summary>
        /// The date when the Template was created.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// The date when the Template modified last time.
        /// </summary>
        [JsonProperty("modified")]
        public DateTimeOffset Modified { get; set; }

        /// <summary>
        /// Template content.
        /// </summary>
        [JsonProperty("content")]
        public TemplateContent Content { get; set; }
    }

    /// <summary>
    /// Represents template content.
    /// </summary>
    public class TemplateContent
    {
        /// <summary>
        /// Assembly instructions.
        /// </summary>
        [JsonProperty("steps")]
        public Dictionary<string, Dictionary<string, object>> Steps { get; set; }
    }

    /// <summary>
    /// Represents Template deletion response.
    /// </summary>
    public class DeleteTemplateResponse : ResponseBase
    {

    }
}
