using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models;
using Transloadit.Models.Templates;

namespace Transloadit.Services
{
    /// <summary>
    /// Represents API requests to <c>/templates</c> endpoints.
    /// </summary>
    public class TemplatesService
    {
        private readonly TransloaditClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatesService"/> class with given <see cref="TransloaditClient"/>.
        /// </summary>
        /// <param name="client">Transloadit client</param>
        public TemplatesService(TransloaditClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Retrieves template data.
        /// </summary>
        /// <param name="templateId">Template id.</param>
        /// <returns>Template data.</returns>
        public async Task<TemplateResponse> GetAsync(string templateId)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Get, $"/templates/{templateId}")
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves list of templates.
        /// </summary>
        /// <param name="paginationParams">Pagination parameters.</param>
        /// <returns>Paginated list of templates.</returns>
        public async Task<PaginatedListResponse<TemplateResponse>> GetListAsync(TemplateListRequest paginationParams = null)
        {
            return await _client.SendRequest<PaginatedListResponse<TemplateResponse>>(HttpMethod.Get, $"/templates", paginationParams)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Create a template.
        /// </summary>
        /// <param name="template">Template settings.</param>
        /// <returns>Created template data.</returns>
        public async Task<TemplateResponse> CreateAsync(TemplateRequest template)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Post, $"/templates", template)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Updated a template.
        /// </summary>
        /// <param name="templateId">Template id.</param>
        /// <param name="template">Template settings.</param>
        /// <returns>Updated template data.</returns>
        public async Task<TemplateResponse> UpdateAsync(string templateId, TemplateRequest template)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Put, $"/templates/{templateId}", template)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a template.
        /// </summary>
        /// <param name="templateId">Template id.</param>
        /// <returns>Template deletion status.</returns>
        public async Task<DeleteTemplateResponse> DeleteAsync(string templateId)
        {
            return await _client.SendRequest<DeleteTemplateResponse>(HttpMethod.Delete, $"/templates/{templateId}")
                .ConfigureAwait(false);
        }
    }
}
