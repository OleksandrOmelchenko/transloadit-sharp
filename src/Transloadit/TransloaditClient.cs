using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Transloadit.Services;

namespace Transloadit
{
    public class TransloaditClient
    {
        private readonly HttpClient _httpClient;

        private readonly string _key;
        private readonly string _secret;
        private readonly TransloaditClientOptions _options;

        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        private const string ApiBase = "https://api2.transloadit.com";

        private BillingService _billingService;
        private TemplateService _templateService;
        private AssembliesService _assembliesService;
        private QueuesService _queuesService;
        private TemplateCredentialsService _templateCredentialsService;
        private AssemblyNotificationsService _assemblyNotificationsService;

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
        public AssembliesService Assemblies => _assembliesService ??= new AssembliesService(this);
        public QueuesService Queues => _queuesService ??= new QueuesService(this);
        public TemplateCredentialsService TemplateCredentials => _templateCredentialsService ??= new TemplateCredentialsService(this);
        public AssemblyNotificationsService AssemblyNotifications => _assemblyNotificationsService ??= new AssemblyNotificationsService(this);

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

        public async Task<T> SendRequest<T>(HttpMethod httpMethod, string path, BaseParams parameters = null)
        {
            var request = BuildRequest(httpMethod, path, parameters);
            var result = await _options.HttpClient.SendAsync(request);

            var content = await result.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<T>(content, _jsonSerializerSettings);
            return res;
        }

        private HttpRequestMessage BuildRequest(
            HttpMethod httpMethod,
            string path,
            BaseParams parameters = null,
            MultipartFormDataContent content = null)
        {
            parameters ??= new BaseParams();
            parameters.Auth ??= new AuthParams
            {
                Key = _key,
                Expires = DateTime.UtcNow.AddMinutes(20).ToString("yyyy'/'MM'/'dd HH:mm:ss+00:00")
            };

            var paramsJson = JsonConvert.SerializeObject(parameters, _jsonSerializerSettings);
            var signature = CalculateSignature(paramsJson, _secret);

            if (httpMethod == HttpMethod.Get)
            {
                var queryMap = new Dictionary<string, string>
                {
                    ["params"] = paramsJson,
                    ["signature"] = signature
                };

                var query = BuildQuery(queryMap);
                path = path + "?" + query;
            }

            var message = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(new Uri(ApiBase), path),
            };

            if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Delete || httpMethod == HttpMethod.Put)
            {
                content ??= new MultipartFormDataContent();

                content.Add(new StringContent(paramsJson), "params");
                content.Add(new StringContent(signature), "signature");

            }
            if (content != null)
            {
                message.Content = content;
            }

            return message;
        }
    }

    public class TransloaditClientOptions
    {
        public string ApiBase { get; set; }
        public HttpClient HttpClient { get; set; }

    }


}
