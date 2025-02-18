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
        /// Gets or sets Transloadit auth key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Get or sets signature expiration date.
        /// </summary>
        [JsonConverter(typeof(AuthExpiresDateTimeConverter))]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// Get or sets a value (better randomly generated) which helps preventing signature re-use and defend against replay attacks.
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Get or sets a regular expression to match against the HTTP referer of this upload.
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// Gets or sets maximum size that an upload can have in bytes.
        /// </summary>
        public int? MaxSize { get; set; }
    }

    /// <summary>
    /// Represents generic pagination parameters.
    /// </summary>
    public class PaginationParams : BaseParams
    {
        /// <summary>
        /// Gets or sets page number.
        /// </summary>
        [JsonProperty("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        [JsonProperty("pagesize")]
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or sets the minimum entity creation date.
        /// </summary>
        [JsonProperty("fromdate")]
        public string FromDate { get; set; }

        /// <summary>
        /// Gets or sets the maximum entity creation date.
        /// </summary>
        [JsonProperty("todate")]
        public string ToDate { get; set; }

        /// <summary>
        /// Gets or sets keywords to be matched against certain fields.
        /// </summary>
        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }
    }
}
