using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models;

namespace Transloadit.Services
{
    public class TemplateService
    {
        private readonly TransloaditClient _client;

        public TemplateService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<TemplateResponse> GetAsync(string id)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Get, $"/templates/{id}");
        }

        public async Task<PaginatedList<TemplateResponse>> GetListAsync(PaginationParams paginationParams = null)
        {
            return await _client.SendRequest<PaginatedList<TemplateResponse>>(HttpMethod.Get, $"/templates", paginationParams);
        }

        public async Task<TemplateResponse> DeleteAsync(string id)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Delete, $"/templates/{id}");
        }

        public async Task<TemplateResponse> CreateAsync(object template)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Post, $"/templates");
        }

        public async Task<TemplateResponse> UpdateAsync(object template)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Put, $"/templates");
        }
    }
}
