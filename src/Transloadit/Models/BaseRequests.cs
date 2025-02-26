using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models
{
    /// <summary>
    /// Represents basic parameters when requesting Transloadit API.
    /// </summary>
    public class BaseParams
    {
        [JsonProperty("auth")]
        internal AuthParams Auth { get; set; }

        [JsonIgnore]
        internal bool EnableSignatureAuth { get; set; } = true;

        /// <summary>
        /// Disables signature authentication for the request.
        /// </summary>
        public void DisableSignatureAuth() => EnableSignatureAuth = false;

        /// <summary>
        /// Sets <c>auth</c> parameter options.
        /// </summary>
        /// <param name="authParams">Auth options.</param>
        public void SetAuth(AuthParams authParams)
        {
            Auth = authParams;
        }
    }

    /// <summary>
    /// Represents possible <c>auth</c> options.
    /// </summary>
    public class AuthParams
    {
        /// <summary>
        /// Transloadit auth key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Signature expiration date.
        /// </summary>
        [JsonConverter(typeof(AuthExpiresDateTimeConverter))]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// A value (better randomly generated) which helps preventing signature re-use and defend against replay attacks.
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// A regular expression to match against the HTTP referer of this upload.
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// Maximum size that an upload can have in bytes.
        /// </summary>
        public int? MaxSize { get; set; }
    }

    /// <summary>
    /// Represents generic pagination parameters.
    /// </summary>
    public class PaginationParams : BaseParams
    {
        /// <summary>
        /// Page number.
        /// </summary>
        [JsonProperty("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Page size.
        /// </summary>
        [JsonProperty("pagesize")]
        public int? PageSize { get; set; }

        /// <summary>
        /// The minimum entity creation date.
        /// </summary>
        [JsonProperty("fromdate")]
        [JsonConverter(typeof(PaginationDateTimeConverter))]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// The maximum entity creation date.
        /// </summary>
        [JsonProperty("todate")]
        [JsonConverter(typeof(PaginationDateTimeConverter))]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Keywords to be matched against certain fields.
        /// </summary>
        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }
    }
}
