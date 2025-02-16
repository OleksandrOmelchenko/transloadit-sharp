using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;

namespace Transloadit.Models
{
    public interface IResponseBase
    {
        string Ok { get; set; }
        string Message { get; set; }
        string Error { get; set; }
        string Reason { get; set; }
        int? HttpCode { get; set; }
    }

    public class ResponseBase : IResponseBase
    {
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

        [JsonIgnore]
        public IResponseBase Base => this;
    }

    public class PaginatedListResponse<T> : ResponseBase
    {
        public int Count { get; set; }

        public List<T> Items { get; set; }
    }

    public class TransloaditResponse
    {
        /// <summary>Gets the HTTP status code of the response.</summary>
        /// <value>The HTTP status code of the response.</value>
        public HttpStatusCode StatusCode { get; }

        /// <summary>Gets the HTTP headers of the response.</summary>
        /// <value>The HTTP headers of the response.</value>
        public HttpResponseHeaders Headers { get; }

        public string Content { get; }

        public TransloaditResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, string content)
        {
            StatusCode = statusCode;
            Headers = headers;
            Content = content;
        }
    }
}
