using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Template Credential data.
    /// </summary>
    public class Credential
    {
        /// <summary>
        /// Template credential id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Account id.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Template credential name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Template credential type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Last modification date.
        /// </summary>
        [JsonProperty("modified")]
        public DateTimeOffset Modified { get; set; }

        /// <summary>
        /// Deletion date.
        /// </summary>
        [JsonProperty("deleted")]
        public DateTimeOffset? Deleted { get; set; }

        /// <summary>
        /// Template credential content.
        /// </summary>
        [JsonProperty("content")]
        public Dictionary<string, string> Content { get; set; }

        /// <summary>
        /// Credential JSON representation.
        /// </summary>
        [JsonProperty("stringified")]
        public string Stringified { get; set; }
    }

    /// <summary>
    /// Represents credentials response list.
    /// </summary>
    public class CredentialsListResponse : ResponseBase
    {
        /// <summary>
        /// Credentials list.
        /// </summary>
        [JsonProperty("credentials")]
        public List<Credential> Credentials { get; set; }
    }

    /// <summary>
    /// Represents credentials response.
    /// </summary>
    public class CredentialResponse : ResponseBase
    {
        /// <summary>
        /// Credential data.
        /// </summary>
        [JsonProperty("credential")]
        public Credential Credential { get; set; }
    }

    /// <summary>
    /// Represents Template Credentials deletion response.
    /// </summary>
    public class DeleteCredentialsResponse : ResponseBase
    {

    }
}
