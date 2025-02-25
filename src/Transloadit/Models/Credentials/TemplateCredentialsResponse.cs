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
        public string Id { get; set; }

        /// <summary>
        /// Account id.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Template credential name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Template credential type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Last modification date.
        /// </summary>
        public DateTimeOffset Modified { get; set; }

        /// <summary>
        /// Deletion date.
        /// </summary>
        public DateTimeOffset? Deleted { get; set; }

        /// <summary>
        /// Template credential content.
        /// </summary>
        public Dictionary<string, string> Content { get; set; }

        /// <summary>
        /// Credential JSON representation.
        /// </summary>
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
        public Credential Credential { get; set; }
    }

    /// <summary>
    /// Represents Template Credentials deletion response.
    /// </summary>
    public class DeleteCredentialsResponse : ResponseBase
    {

    }
}
