using System.Threading.Tasks;
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
            return await _client.SendTokenRequest(request).ConfigureAwait(false);
        }
    }
}
