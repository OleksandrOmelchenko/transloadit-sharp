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
        /// Billing service.
        /// </summary>
        public BillingService Billing => _billingService ??= new BillingService(this);

        /// <summary>
        /// Templates service.
        /// </summary>
        public TemplatesService Templates => _templatesService ??= new TemplatesService(this);

        /// <summary>
        /// Assemblies service.
        /// </summary>
        public AssembliesService Assemblies => _assembliesService ??= new AssembliesService(this);

        /// <summary>
        /// Queues service.
        /// </summary>
        public QueuesService Queues => _queuesService ??= new QueuesService(this);

        /// <summary>
        /// Template Credentials service.
        /// </summary>
        public CredentialsService Credentials => _credentialsService ??= new CredentialsService(this);

        /// <summary>
        /// Assembly Notifications service.
        /// </summary>
        public AssemblyNotificationsService AssemblyNotifications => _assemblyNotificationsService ??= new AssemblyNotificationsService(this);

        /// <summary>
        /// Initializes a new instance of the <see cref="TransloaditClient"/> class with specified authentication key, secret 
        /// and optional <see cref="TransloaditClientOptions"/>.
        /// </summary>
        /// <param name="key">Transloadit auth key.</param>
        /// <param name="secret">Transloadit auth secret.</param>
        /// <param name="options">Options allowing to overwrite <see cref="TransloaditClient"/> defaults. Will be merged with default values.</param>
        public TransloaditClient(string key, string secret, TransloaditClientOptions options = null)
        {
            _key = key;
            _secret = secret;
            _options = MergeOptions(options);
        }

        private static TransloaditClientOptions MergeOptions(TransloaditClientOptions options)
        {
            var httpClient = options?.HttpClient ?? new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Transloadit-Client", "transloadit-sharp/0.8.0");
            return new TransloaditClientOptions
            {
                ApiBase = options?.ApiBase ?? new Uri(ApiBase),
                HttpClient = httpClient,
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
        /// <param name="parameters">Request parameters. Auhtorization parameters are added automatically.</param>
        /// <param name="formData">Request form data. Usually contains file uploads and <c>${fields.*}</c> assembly parameters.</param>
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
        /// <typeparam name="T">Response type to parse into.</typeparam>
        /// <param name="httpMethod">HTTP method to use.</param>
        /// <param name="uri">Request url.</param>
        /// <param name="parameters">Request parameters. Auhtorization parameters are added automatically.</param>
        /// <param name="formData">Request form data. Usually contains file uploads and <c>${fields.*}</c> assembly parameters.</param>
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

        private static string BuildQuery(string paramsJson) => $"?params={WebUtility.UrlEncode(paramsJson)}";

        private HttpRequestMessage BuildRequest(
            HttpMethod httpMethod,
            Uri uri,
            BaseParams parameters = null,
            MultipartFormDataContent content = null)
        {
            parameters ??= new BaseParams();
            parameters.Auth ??= new AuthParams();
            parameters.Auth.Key ??= _key;
            if (parameters.EnableSignatureAuth)
            {
                parameters.Auth.Expires ??= DateTime.UtcNow.AddMinutes(30);
            }

            var paramsJson = JsonConvert.SerializeObject(parameters, _jsonSerializerSettings);
            var signature = parameters.EnableSignatureAuth
                ? SignatureUtilities.CalculateSignature(paramsJson, _secret)
                : null;

            if (httpMethod == HttpMethod.Get)
            {
                var query = parameters.EnableSignatureAuth ? BuildQuery(paramsJson, signature) : BuildQuery(paramsJson);
                uri = new Uri(uri, query);
            }

            var message = new HttpRequestMessage(httpMethod, uri);
            if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Delete || httpMethod == HttpMethod.Put)
            {
                content ??= new MultipartFormDataContent();
                content.Add(new StringContent(paramsJson), "params");
                if (parameters.EnableSignatureAuth)
                {
                    content.Add(new StringContent(signature), "signature");
                }
            }
            if (content != null)
            {
                message.Content = content;
            }

            return message;
        }
    }
}
