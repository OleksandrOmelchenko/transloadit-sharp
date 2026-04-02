using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Transloadit.Models;
using Transloadit.Models.Tokens;

namespace Transloadit.Services
{
    /// <summary>
    /// Represents API requests to <c>/token</c> endpoint.
    /// </summary>
    public class TokensService
    {
        private readonly TransloaditClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokensService"/> class with given <see cref="TransloaditClient"/>.
        /// </summary>
        /// <param name="client">Transloadit client.</param>
        public TokensService(TransloaditClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Creates a short-lived bearer token.
        /// </summary>
        /// <param name="request">Token request options.</param>
        /// <returns>Token response.</returns>
        public async Task<TokenResponse> CreateAsync(TokenRequest request = null)
        {
            if (string.IsNullOrWhiteSpace(_client.Secret))
            {
                throw new InvalidOperationException("Token requests require a client initialized with both key and secret.");
            }

            request ??= new TokenRequest();
            request.GrantType ??= "client_credentials";

            var formData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", request.GrantType),
            };

            if (!string.IsNullOrWhiteSpace(request.Scope))
            {
                formData.Add(new KeyValuePair<string, string>("scope", request.Scope));
            }

            if (!string.IsNullOrWhiteSpace(request.Aud))
            {
                formData.Add(new KeyValuePair<string, string>("aud", request.Aud));
            }

            var uri = new Uri(_client.Options.ApiBase, "/token");
            var message = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new FormUrlEncodedContent(formData),
            };

            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_client.Key}:{_client.Secret}"));
            message.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            var response = await _client.Options.HttpClient.SendAsync(message).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var parsed = JsonConvert.DeserializeObject<TokenResponse>(content, _client.Options.ResponseSerializerSettings) ?? new TokenResponse();
            parsed.TransloaditResponse = new TransloaditResponse(response.StatusCode, response.Headers, content);
            return parsed;
        }
    }
}
