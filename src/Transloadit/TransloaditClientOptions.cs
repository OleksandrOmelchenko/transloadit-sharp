using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Transloadit
{
    public class TransloaditClientOptions
    {
        public Uri ApiBase { get; set; }
        public HttpClient HttpClient { get; set; }
        public JsonSerializerSettings ResponseSerializerSettings { get; set; }
        public JsonSerializerSettings RequestSerializerSettings { get; set; }
    }
}
