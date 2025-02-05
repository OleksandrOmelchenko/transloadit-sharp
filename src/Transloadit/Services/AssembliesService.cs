using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models;

namespace Transloadit.Services
{
    public class AssembliesService
    {
        private readonly TransloaditClient _client;

        public AssembliesService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<AssemblyResponse> GetAsync(string id)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Get, $"/assemblies/{id}");
        }

        public async Task<PaginatedList<AssemblyResponse>> GetListAsync(PaginationParams paginationParams = null)
        {
            return await _client.SendRequest<PaginatedList<AssemblyResponse>>(HttpMethod.Get, $"/assemblies", paginationParams);
        }

        public async Task<AssemblyResponse> CancelAsync(string id)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Delete, $"/assemblies/{id}");
        }

        public async Task<AssemblyResponse> CancelByUrlAsync(string assemblyUrl)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Delete, assemblyUrl); //todo: different method
        }

        public async Task<AssemblyResponse> CreateAsync(object template)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Post, $"/assemblies");
        }

        public async Task<AssemblyResponse> ReplayAsync(string id)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Post, $"/assemblies/{id}/replay");
        }

        public async Task<AssemblyResponse> UpdateAsync(object template)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Put, $"/assemblies");
        }
    }
}
