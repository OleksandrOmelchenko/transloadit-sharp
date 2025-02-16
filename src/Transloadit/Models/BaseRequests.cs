using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models
{
    public class BaseParams
    {
        [JsonProperty("auth")]
        internal AuthParams Auth { get; set; }

        public void SetAuth(AuthParams authParams)
        {
            Auth = authParams;
        }
    }

    public class AuthParams
    {
        public string Key { get; set; }

        [JsonConverter(typeof(AuthExpiresDateTimeConverter))]
        public DateTime? Expires { get; set; }

        public string Nonce { get; set; }

        public string Referer { get; set; }

        public int? MaxSize { get; set; }
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
}
