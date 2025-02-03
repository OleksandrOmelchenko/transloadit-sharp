using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models
{
    public class Content
    {
        [JsonProperty("steps")]
        public Steps Steps { get; set; }
    }

    public class Exported
    {
        [JsonProperty("use")]
        public List<string> Use { get; set; }

        [JsonProperty("robot")]
        public string Robot { get; set; }

        [JsonProperty("credentials")]
        public string Credentials { get; set; }
    }

    public class Imported
    {
        [JsonProperty("robot")]
        public string Robot { get; set; }

        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("credentials")]
        public string Credentials { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }

    public class TemplateResponse
    {
        [JsonProperty("ok")]
        public string Ok { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("require_signature_auth")]
        public int RequireSignatureAuth { get; set; }

        [JsonProperty("transcoding_result_expiry")]
        public object TranscodingResultExpiry { get; set; }

        [JsonProperty("assembly_status_expiry")]
        public object AssemblyStatusExpiry { get; set; }
    }

    public class Steps
    {
        [JsonProperty("imported")]
        public Imported Imported { get; set; }

        [JsonProperty("exported")]
        public Exported Exported { get; set; }
    }
}
