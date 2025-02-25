using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Transloadit
{
    /// <summary>
    /// Contains configuration for <see cref="TransloaditClient"/>.
    /// </summary>
    public class TransloaditClientOptions
    {
        /// <summary>
        /// Base API url.
        /// </summary>
        public Uri ApiBase { get; set; }

        /// <summary>
        /// HttpClient used for sending API requests.
        /// </summary>
        public HttpClient HttpClient { get; set; }

        /// <summary>
        /// <see cref="JsonSerializerSettings"/> for response deserialization.
        /// </summary>
        public JsonSerializerSettings ResponseSerializerSettings { get; set; }

        /// <summary>
        /// <see cref="JsonSerializerSettings"/> for request serialization.
        /// </summary>
        public JsonSerializerSettings RequestSerializerSettings { get; set; }
    }
}
