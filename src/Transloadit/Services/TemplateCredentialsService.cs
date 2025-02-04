using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models.TemplateCredentials;

namespace Transloadit.Services
{
    public class TemplateCredentialsService
    {
        private readonly TransloaditClient _client;

        public TemplateCredentialsService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<TemplateCredentialsResponse> GetAsync(string id)
        {
            return await _client.SendRequest<TemplateCredentialsResponse>(HttpMethod.Get, $"/template_credentials/{id}");
        }

        public async Task<TemplateCredentialsResponse> GetListAsync()
        {
            return await _client.SendRequest<TemplateCredentialsResponse>(HttpMethod.Get, $"/template_credentials");
        }

        public async Task<TemplateCredentialsResponse> DeleteAsync(string id)
        {
            return await _client.SendRequest<TemplateCredentialsResponse>(HttpMethod.Delete, $"/template_credentials/{id}");
        }

        public async Task<CreateCredentialResponse> CreateAsync(CreateCredentialsRequestBase credential)
        {
            return await _client.SendRequest<CreateCredentialResponse>(HttpMethod.Post, $"/template_credentials", credential);
        }

        public async Task<TemplateCredentialsResponse> UpdateAsync(object template)
        {
            return await _client.SendRequest<TemplateCredentialsResponse>(HttpMethod.Put, $"/template_credentials");
        }
    }
}
