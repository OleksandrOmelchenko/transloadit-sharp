using Newtonsoft.Json;
using System.Collections.Generic;

namespace Transloadit.Models
{
    public class BaseParams
    {
        internal AuthParams Auth { get; set; }
    }

    public class AuthParams
    {
        public string Key { get; set; }

        public string Expires { get; set; }

        public string Nonce { get; set; }
    }

    public class PaginationParams : BaseParams
    {
        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("pagesize")]
        public int? PageSize { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; } //["id", "name", "created", "modified"]

        [JsonProperty("order")]
        public string Order { get; set; } //desc, asc

        [JsonProperty("fromdate")]
        public string FromDate { get; set; }

        [JsonProperty("todate")]
        public string ToDate { get; set; }

        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }
    }
}
