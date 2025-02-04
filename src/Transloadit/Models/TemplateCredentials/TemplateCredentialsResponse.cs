using System;
using System.Collections.Generic;

namespace Transloadit.Models.TemplateCredentials
{
    public class CredentialContent
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Bucket { get; set; }
        public string BucketRegion { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
    }

    public class Credential
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public DateTimeOffset? Deleted { get; set; }
        public Content Content { get; set; }
        public string Stringified { get; set; }
    }

    public class TemplateCredentialsResponse
    {
        public string Ok { get; set; }
        public string Message { get; set; }
        public List<Credential> Credentials { get; set; }
    }

    public class CreateCredentialResponse
    {
        public string Ok { get; set; }
        public string Message { get; set; }
        public Credential Credential { get; set; }
    }
}
