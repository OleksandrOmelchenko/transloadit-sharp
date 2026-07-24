using System;
using System.Net.Http;
using Transloadit.Serialization;

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
        /// The JSON serializer used for request serialization and response deserialization.
        /// Defaults to a System.Text.Json implementation (Newtonsoft.Json on net452). Provide a custom
        /// <see cref="ITransloaditSerializer"/> to change the engine or register additional converters.
        /// </summary>
        public ITransloaditSerializer Serializer { get; set; }
    }
}
