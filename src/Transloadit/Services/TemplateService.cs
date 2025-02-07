using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models;
using Transloadit.Models.Templates;

namespace Transloadit.Services
{
    public class TemplateService
    {
        private readonly TransloaditClient _client;

        public TemplateService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<TemplateResponse> GetAsync(string templateId)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Get, $"/templates/{templateId}");
        }

        public async Task<PaginatedListResponse<TemplateResponse>> GetListAsync(TemplateListRequest paginationParams = null)
        {
            return await _client.SendRequest<PaginatedListResponse<TemplateResponse>>(HttpMethod.Get, $"/templates", paginationParams);
        }

        public async Task<TemplateResponse> CreateAsync(TemplateRequest template)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Post, $"/templates", template);
        }

        public async Task<TemplateResponse> UpdateAsync(string templateId, TemplateRequest template)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Put, $"/templates/{templateId}", template);
        }

        public async Task<TemplateResponse> DeleteAsync(string templateId)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Delete, $"/templates/{templateId}");
        }
    }
}
