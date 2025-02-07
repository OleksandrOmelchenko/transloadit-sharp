using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Transloadit.Models;
using Transloadit.Services;

namespace Transloadit
{
    public class TransloaditClient
    {
        private const string ApiBase = "https://api2.transloadit.com";

        private readonly string _key;
        private readonly string _secret;
        private readonly TransloaditClientOptions _options;

        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        private BillingService _billingService;
        private TemplatesService _templatesService;
        private AssembliesService _assembliesService;
        private QueuesService _queuesService;
        private CredentialsService _credentialsService;
        private AssemblyNotificationsService _assemblyNotificationsService;

        public TransloaditClient(string key, string secret, TransloaditClientOptions options = null)
        {
            _key = key;
            _secret = secret;
            _options = MergeOptions(options);
        }

        private static TransloaditClientOptions MergeOptions(TransloaditClientOptions options)
        {
            return new TransloaditClientOptions
            {
                ApiBase = options?.ApiBase ?? new Uri(ApiBase),
                HttpClient = options?.HttpClient ?? new HttpClient(),
                RequestSerializerSettings = options?.RequestSerializerSettings ?? _jsonSerializerSettings,
                ResponseSerializerSettings = options?.ResponseSerializerSettings ?? _jsonSerializerSettings,
            };
        }

        public BillingService Billing => _billingService ??= new BillingService(this);
        public TemplatesService Templates => _templatesService ??= new TemplatesService(this);
        public AssembliesService Assemblies => _assembliesService ??= new AssembliesService(this);
        public QueuesService Queues => _queuesService ??= new QueuesService(this);
        public CredentialsService Credentials => _credentialsService ??= new CredentialsService(this);
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
            using var crypto = new HMACSHA384(Encoding.UTF8.GetBytes(key));
            var hashBytes = crypto.ComputeHash(Encoding.UTF8.GetBytes(parameters));
            var hash = ToLowerHex(hashBytes);

            return $"sha384:{hash}";
        }

        public async Task<T> SendRequest<T>(HttpMethod httpMethod, string path, BaseParams parameters = null) where T : ResponseBase
        {
            var request = BuildRequest(httpMethod, path, parameters);
            var response = await _options.HttpClient.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            var transloaditResponse = new TransloaditResponse(response.StatusCode, response.Headers, content);

            var parsed = JsonConvert.DeserializeObject<T>(content, _jsonSerializerSettings);
            parsed.TransloaditResponse = transloaditResponse;
            return parsed;
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

            var message = new HttpRequestMessage(httpMethod, new Uri(_options.ApiBase, path));
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
}
