using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models
{
    public class BaseParams
    {
        [JsonProperty("auth")]
        internal AuthParams Auth { get; set; }
    }

    public class AuthParams
    {
        public string Key { get; set; }

        public string Expires { get; set; }

        public string Nonce { get; set; }

        public string Referer { get; set; }

        public int MaxSize { get; set; }
    }

    public class PaginationParams : BaseParams
    {
        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("pagesize")]
        public int? PageSize { get; set; }

        [JsonProperty("fromdate")]
        public string FromDate { get; set; }

        [JsonProperty("todate")]
        public string ToDate { get; set; }

        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }
    }

    public class TemplateListRequest : PaginationParams
    {
        public string Sort { get; set; } //["id", "name", "created", "modified"]

        public string Order { get; set; } //desc, asc
    }
}
