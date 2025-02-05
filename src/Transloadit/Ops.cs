using Newtonsoft.Json;
using System.Collections.Generic;
using Transloadit.Models;

namespace Transloadit
{
    public class PaginatedList<T> : ResponseBase
    {
        public int Count { get; set; }

        public List<T> Items { get; set; }
    }


    public class BaseParams
    {
        [JsonProperty("auth")]
        internal AuthParams Auth { get; set; }
    }

    public class AuthParams
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("expires")]
        public string Expires { get; set; }

        [JsonProperty("nonce")]
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
