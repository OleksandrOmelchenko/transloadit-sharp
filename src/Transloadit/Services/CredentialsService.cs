using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models.Credentials;

namespace Transloadit.Services
{
    /// <summary>
    /// Represents API requests to <c>/template_credentials</c> endpoints.
    /// </summary>
    public class CredentialsService
    {
        private readonly TransloaditClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialsService"/> class with given <see cref="TransloaditClient"/>.
        /// </summary>
        /// <param name="client">Transloadit client</param>
        public CredentialsService(TransloaditClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Retrieves template credentials by id/name.
        /// </summary>
        /// <param name="credentialIdOrName">Credentials id or name.</param>
        /// <returns>Credentials data.</returns>
        public async Task<CredentialResponse> GetAsync(string credentialIdOrName)
        {
            return await _client.SendRequest<CredentialResponse>(HttpMethod.Get, $"/template_credentials/{credentialIdOrName}");
        }

        /// <summary>
        /// Retrieves a complete list of template credentials.
        /// </summary>
        /// <returns>Credentials list.</returns>
        public async Task<CredentialsListResponse> GetListAsync()
        {
            return await _client.SendRequest<CredentialsListResponse>(HttpMethod.Get, $"/template_credentials");
        }

        /// <summary>
        /// Creates template credentials.
        /// </summary>
        /// <param name="credential">Credentials data.</param>
        /// <returns>Created credentials data.</returns>
        public async Task<CredentialResponse> CreateAsync(CredentialsRequestBase credential)
        {
            return await _client.SendRequest<CredentialResponse>(HttpMethod.Post, $"/template_credentials", credential);
        }

        /// <summary>
        /// Updated template credentials.
        /// </summary>
        /// <param name="credentialIdOrName">Credentials id or name.</param>
        /// <param name="credential">Credentials data.</param>
        /// <returns>Updated credentials data.</returns>
        public async Task<CredentialResponse> UpdateAsync(string credentialIdOrName, CredentialsRequestBase credential)
        {
            return await _client.SendRequest<CredentialResponse>(HttpMethod.Put, $"/template_credentials/{credentialIdOrName}", credential);
        }

        /// <summary>
        /// Deletes template credentials.
        /// </summary>
        /// <param name="credentialIdOrName">Credentials id or name.</param>
        /// <returns>Credentials deletion status.</returns>
        public async Task<DeleteCredentialsResponse> DeleteAsync(string credentialIdOrName)
        {
            return await _client.SendRequest<DeleteCredentialsResponse>(HttpMethod.Delete, $"/template_credentials/{credentialIdOrName}");
        }
    }
}
