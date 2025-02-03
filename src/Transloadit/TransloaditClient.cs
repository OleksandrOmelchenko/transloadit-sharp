using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Transloadit.Models;

namespace Transloadit
{
    public class TransloaditClient
    {
        private readonly HttpClient _httpClient;

        private readonly string _key;
        private readonly string _secret;
        private readonly TransloaditClientOptions _options;


        private const string ApiBase = "https://api2.transloadit.com";

        private BillingService _billingService;
        private TemplateService _templateService;

        public TransloaditClient(string key, string secret, TransloaditClientOptions options = null)
        {
            _key = key;
            _secret = secret;
            _options = options ?? BuildDefault();
        }

        private TransloaditClientOptions BuildDefault()
        {
            return new TransloaditClientOptions
            {
                ApiBase = ApiBase,
                HttpClient = new HttpClient
                {
                    BaseAddress = new Uri(ApiBase)
                }
            };
        }

        public BillingService Billing => _billingService ??= new BillingService(this);
        public TemplateService Templates => _templateService ??= new TemplateService(this);

        public static string BuildQuery(IEnumerable<KeyValuePair<string, string>> values)
        {
            return string.Join("&", values.Select(p => $"{WebUtility.UrlEncode(p.Key)}={WebUtility.UrlEncode(p.Value)}"));
        }

        private string ToLowerHex(byte[] bytes)
        {
            var builder = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        private string CalculateSignature(string parameters, string key)
        {
            using var cry = new HMACSHA384(Encoding.UTF8.GetBytes(key));
            var hashBytes = cry.ComputeHash(Encoding.UTF8.GetBytes(parameters));
            var res = ToLowerHex(hashBytes);

            return $"sha384:{res}";
        }

        public async Task<T> SendRequest<T>(HttpMethod httpMethod, string path, Dictionary<string, object> parameters = null)
        {
            var request = BuildRequest(httpMethod, path, parameters);
            var result = await _options.HttpClient.SendAsync(request);

            var content = await result.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<T>(content);
            return res;
        }

        private HttpRequestMessage BuildRequest(
            HttpMethod httpMethod,
            string path,
            Dictionary<string, object> parameters = null,
            HttpContent content = null)
        {
            parameters ??= new Dictionary<string, object>();
            var auth = new Dictionary<string, string>
            {
                ["key"] = _key,
                ["expires"] = DateTime.UtcNow.AddMinutes(20).ToString("yyyy'/'MM'/'dd HH:mm:ss+00:00")
            };
            parameters["auth"] = auth;

            var queryMap = new Dictionary<string, string>
            {
                ["params"] = JsonConvert.SerializeObject(parameters)
            };
            queryMap["signature"] = CalculateSignature(queryMap["params"], _secret);

            var query = BuildQuery(queryMap);

            var message = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(new Uri(ApiBase), path + "?" + query),

            };
            return message;
        }
    }

    public class TransloaditClientOptions
    {
        public string ApiBase { get; set; }
        public HttpClient HttpClient { get; set; }

    }

   
}
