using System;
using System.Collections.Generic;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents Template Credential data.
    /// </summary>
    public class Credential
    {

        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public DateTimeOffset? Deleted { get; set; }
        public Dictionary<string, string> Content { get; set; }
        public string Stringified { get; set; }
    }

    public class CredentialsListResponse : ResponseBase
    {
        public List<Credential> Credentials { get; set; }
    }

    public class CredentialResponse : ResponseBase
    {
        public Credential Credential { get; set; }
    }

    /// <summary>
    /// Represents Template Credentials deletion response.
    /// </summary>
    public class DeleteCredentialsResponse : ResponseBase
    {

    }
}
