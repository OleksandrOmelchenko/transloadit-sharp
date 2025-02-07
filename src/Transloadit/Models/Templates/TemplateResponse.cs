using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [JsonConverter(typeof(StringToArrayConverter))]
        public List<string> Use { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JToken> Data { get; set; }
    }

    public class StringToArrayConverter : JsonConverter<List<string>>
    {
        public override List<string> ReadJson(
            JsonReader reader,
            Type objectType,
            List<string> existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                return new List<string> { token.ToString() };
            }

            return token.ToObject<List<string>>();
        }

        public override void WriteJson(JsonWriter writer, List<string> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
