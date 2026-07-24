using System;
using System.Collections.Generic;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents Template Credential data.
/// </summary>
public class Credential
{
    /// <summary>
    /// Template credential id.
    /// </summary>
    [TransloaditJsonName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Account id.
    /// </summary>
    [TransloaditJsonName("account_id")]
    public string AccountId { get; set; }

    /// <summary>
    /// Template credential name.
    /// </summary>
    [TransloaditJsonName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Template credential type.
    /// </summary>
    [TransloaditJsonName("type")]
    public string Type { get; set; }

    /// <summary>
    /// Creation date.
    /// </summary>
    [TransloaditJsonName("created")]
    public DateTimeOffset Created { get; set; }

    /// <summary>
    /// Last modification date.
    /// </summary>
    [TransloaditJsonName("modified")]
    public DateTimeOffset Modified { get; set; }

    /// <summary>
    /// Deletion date.
    /// </summary>
    [TransloaditJsonName("deleted")]
    public DateTimeOffset? Deleted { get; set; }

    /// <summary>
    /// Template credential content.
    /// </summary>
    [TransloaditJsonName("content")]
    public Dictionary<string, string> Content { get; set; }

    /// <summary>
    /// Credential JSON representation.
    /// </summary>
    [TransloaditJsonName("stringified")]
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
    [TransloaditJsonName("credentials")]
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
    [TransloaditJsonName("credential")]
    public Credential Credential { get; set; }
}

/// <summary>
/// Represents Template Credentials deletion response.
/// </summary>
public class DeleteCredentialsResponse : ResponseBase
{

}
