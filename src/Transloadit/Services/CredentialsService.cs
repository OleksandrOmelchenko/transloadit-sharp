using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models.Credentials;

namespace Transloadit.Services
{
    public class CredentialsService
    {
        private readonly TransloaditClient _client;

        public CredentialsService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<CredentialResponse> GetAsync(string credentialIdOrName)
        {
            return await _client.SendRequest<CredentialResponse>(HttpMethod.Get, $"/template_credentials/{credentialIdOrName}");
        }

        public async Task<CredentialsListResponse> GetListAsync()
        {
            return await _client.SendRequest<CredentialsListResponse>(HttpMethod.Get, $"/template_credentials");
        }

        public async Task<CredentialResponse> CreateAsync(CredentialsRequestBase credential)
        {
            return await _client.SendRequest<CredentialResponse>(HttpMethod.Post, $"/template_credentials", credential);
        }

        public async Task<CredentialResponse> UpdateAsync(string credentialIdOrName, CredentialsRequestBase credential)
        {
            return await _client.SendRequest<CredentialResponse>(HttpMethod.Put, $"/template_credentials/{credentialIdOrName}", credential);
        }

        public async Task<CredentialsListResponse> DeleteAsync(string credentialIdOrName)
        {
            return await _client.SendRequest<CredentialsListResponse>(HttpMethod.Delete, $"/template_credentials/{credentialIdOrName}");
        }
    }
}
