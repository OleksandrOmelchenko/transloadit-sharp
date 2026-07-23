using Transloadit.Serialization.Attributes;
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
        [TransloaditJsonName("auth")]
        internal AuthParams Auth { get; set; }

        [TransloaditJsonIgnore]
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
        [TransloaditJsonName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Signature expiration date.
        /// </summary>
        [TransloaditJsonName("expires")]
        [TransloaditDateFormat("yyyy'/'MM'/'dd HH:mm:ss+00:00")]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// A value (better randomly generated) which helps preventing signature re-use and defend against replay attacks.
        /// </summary>
        [TransloaditJsonName("nonce")]
        public string Nonce { get; set; }

        /// <summary>
        /// A regular expression to match against the HTTP referer of this upload.
        /// </summary>
        [TransloaditJsonName("referer")]
        public string Referer { get; set; }

        /// <summary>
        /// Maximum size that an upload can have in bytes.
        /// </summary>
        [TransloaditJsonName("max_size")]
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
        [TransloaditJsonName("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Page size.
        /// </summary>
        [TransloaditJsonName("pagesize")]
        public int? PageSize { get; set; }

        /// <summary>
        /// The minimum entity creation date.
        /// </summary>
        [TransloaditJsonName("fromdate")]
        [TransloaditDateFormat("yyyy-MM-dd HH:mm:ss")]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// The maximum entity creation date.
        /// </summary>
        [TransloaditJsonName("todate")]
        [TransloaditDateFormat("yyyy-MM-dd HH:mm:ss")]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Keywords to be matched against certain fields.
        /// </summary>
        [TransloaditJsonName("keywords")]
        public List<string> Keywords { get; set; }
    }
}
