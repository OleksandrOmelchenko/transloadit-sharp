using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;

namespace Transloadit.Models
{
    /// <summary>
    /// Represents Transloadit API base response properties.
    /// </summary>
    public interface IResponseBase
    {
        /// <summary>
        /// Success status code.
        /// </summary>
        string Ok { get; set; }

        /// <summary>
        /// Success or error message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Error status code.
        /// </summary>
        string Error { get; set; }

        /// <summary>
        /// Error reason message.
        /// </summary>
        string Reason { get; set; }

        /// <summary>
        /// Response HTTP code.
        /// </summary>
        int? HttpCode { get; set; }
    }

    /// <summary>
    /// Represents Transloadit API base response properties.
    /// Also hides direct access to them, while providing it via <see cref="Base"/> property.
    /// </summary>
    public class ResponseBase : IResponseBase
    {
        /// <summary>
        /// Gets raw Transloadit response.
        /// </summary>
        [JsonIgnore]
        public TransloaditResponse TransloaditResponse { get; internal set; }

        [JsonProperty("ok")]
        string IResponseBase.Ok { get; set; }

        [JsonProperty("message")]
        string IResponseBase.Message { get; set; }

        [JsonProperty("error")]
        string IResponseBase.Error { get; set; }

        [JsonProperty("reason")]
        string IResponseBase.Reason { get; set; }

        [JsonProperty("http_code")]
        int? IResponseBase.HttpCode { get; set; }

        /// <summary>
        /// Base response properties.
        /// </summary>
        [JsonIgnore]
        public IResponseBase Base => this;

        /// <summary>
        /// Checks whether received successful response by checking <c>ok</c> and <c>error</c> properties.
        /// </summary>
        /// <returns>Whether the response is successful.</returns>
        public bool IsSuccessResponse() => Base.Ok is not null || Base.Error is null;
    }

    /// <summary>
    /// Representes paginated list response.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public class PaginatedListResponse<T> : ResponseBase
    {
        /// <summary>
        /// Total items count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Paginated items.
        /// </summary>
        public List<T> Items { get; set; }
    }

    /// <summary>
    /// Represents a raw Transloadit response.
    /// </summary>
    public class TransloaditResponse
    {
        /// <summary>
        /// The HTTP status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The HTTP headers of the response.
        /// </summary>
        public HttpResponseHeaders Headers { get; }

        /// <summary>
        /// The content of the response.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransloaditResponse"/> class with basic response data.
        /// </summary>
        /// <param name="statusCode">HTTP status code of the response.</param>
        /// <param name="headers">HTTP headers of the response.</param>
        /// <param name="content">Content of the response.</param>
        public TransloaditResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, string content)
        {
            StatusCode = statusCode;
            Headers = headers;
            Content = content;
        }
    }
}
