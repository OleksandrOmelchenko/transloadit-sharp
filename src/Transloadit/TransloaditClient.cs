using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Transloadit.Models;
using Transloadit.Serialization;
using Transloadit.Services;
using Transloadit.Utilities;

namespace Transloadit
{
    /// <summary>
    /// Represents Transloadit API client used to send requests and deserialize responses.
    /// </summary>
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
                NamingStrategy = new SnakeCaseNamingStrategy(),
            },
            Converters = new List<JsonConverter>
            {
                new AnyOfConverter()
            },
        };

        private BillingService _billingService;
        private TemplatesService _templatesService;
        private AssembliesService _assembliesService;
        private QueuesService _queuesService;
        private CredentialsService _credentialsService;
        private AssemblyNotificationsService _assemblyNotificationsService;

        /// <summary>
        /// Gets Billing service.
        /// </summary>
        public BillingService Billing => _billingService ??= new BillingService(this);

        /// <summary>
        /// Gets Templates service.
        /// </summary>
        public TemplatesService Templates => _templatesService ??= new TemplatesService(this);

        /// <summary>
        /// Gets Assemblies service.
        /// </summary>
        public AssembliesService Assemblies => _assembliesService ??= new AssembliesService(this);

        /// <summary>
        /// Gets Queues service.
        /// </summary>
        public QueuesService Queues => _queuesService ??= new QueuesService(this);

        /// <summary>
        /// Gets Template Credentials service.
        /// </summary>
        public CredentialsService Credentials => _credentialsService ??= new CredentialsService(this);

        /// <summary>
        /// Gets Assembly Notifications service.
        /// </summary>
        public AssemblyNotificationsService AssemblyNotifications => _assemblyNotificationsService ??= new AssemblyNotificationsService(this);

        /// <summary>
        /// Initializes a new instance of the <see cref="TransloaditClient"/> class with specified authentication key, secret 
        /// and optional <see cref="TransloaditClientOptions"/>.
        /// </summary>
        /// <param name="key">Transloadit auth key.</param>
        /// <param name="secret">Transloadit auth secret.</param>
        /// <param name="options">Options allowing to overwrite <see cref="TransloaditClient"/> defaults.</param>
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

        /// <summary>
        /// Sends request to Transloadit API.
        /// </summary>
        /// <typeparam name="T">Response type to parse into.</typeparam>
        /// <param name="httpMethod">HTTP method to use.</param>
        /// <param name="path">Request path.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <param name="formData">Request form data.</param>
        /// <returns>Parsed response.</returns>
        public async Task<T> SendRequest<T>(
            HttpMethod httpMethod,
            string path,
            BaseParams parameters = null,
            MultipartFormDataContent formData = null) where T : ResponseBase
        {
            var uri = new Uri(_options.ApiBase, path);
            return await SendRequest<T>(httpMethod, uri, parameters, formData);
        }

        /// <summary>
        /// Sends request to the specified url.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T">Response type to parse into.</typeparam>
        /// <param name="httpMethod">HTTP method to use.</param>
        /// <param name="uri">Request url.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <param name="formData">Request form data.</param>
        /// <returns>Parsed response.</returns>
        public async Task<T> SendRequest<T>(
           HttpMethod httpMethod,
           Uri uri,
           BaseParams parameters = null,
           MultipartFormDataContent formData = null) where T : ResponseBase
        {
            var request = BuildRequest(httpMethod, uri, parameters, formData);
            var response = await _options.HttpClient.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            var parsed = JsonConvert.DeserializeObject<T>(content, _jsonSerializerSettings);
            parsed.TransloaditResponse = new TransloaditResponse(response.StatusCode, response.Headers, content);
            return parsed;
        }

        private static string BuildQuery(string paramsJson, string signature)
            => $"?params={WebUtility.UrlEncode(paramsJson)}&signature={WebUtility.UrlEncode(signature)}";

        private HttpRequestMessage BuildRequest(
            HttpMethod httpMethod,
            Uri uri,
            BaseParams parameters = null,
            MultipartFormDataContent content = null)
        {
            parameters ??= new BaseParams();
            parameters.Auth ??= new AuthParams();
            parameters.Auth.Key ??= _key;
            parameters.Auth.Expires ??= DateTime.UtcNow.AddMinutes(30);

            var paramsJson = JsonConvert.SerializeObject(parameters, _jsonSerializerSettings);
            var signature = SignatureUtilities.CalculateSignature(paramsJson, _secret);

            if (httpMethod == HttpMethod.Get)
            {
                var query = BuildQuery(paramsJson, signature);
                uri = new Uri(uri, query);
            }

            var message = new HttpRequestMessage(httpMethod, uri);
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
