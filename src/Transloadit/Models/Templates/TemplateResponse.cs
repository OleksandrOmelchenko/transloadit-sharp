using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Transloadit.Models.Templates
{
    public class TemplateResponse : ResponseBase
    {
        public string Id { get; set; }

        public TemplateContent Content { get; set; }

        public string Name { get; set; }

        public int RequireSignatureAuth { get; set; }

        public DateTimeOffset? TranscodingResultExpiry { get; set; }

        public DateTimeOffset? AssemblyStatusExpiry { get; set; }
    }

    public class TemplateContent
    {
        public Dictionary<string, StepContent> Steps { get; set; }
    }

    public class StepContent
    {
        public string Robot { get; set; }

        public List<string> Use { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JToken> Data { get; set; }
    }
}
