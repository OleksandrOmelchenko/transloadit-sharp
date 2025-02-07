using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models;
using Transloadit.Models.Assemblies;

namespace Transloadit.Services
{
    public class AssembliesService
    {
        private readonly TransloaditClient _client;

        public AssembliesService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<AssemblyResponse> GetAsync(string assemblyId)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Get, $"/assemblies/{assemblyId}");
        }

        public async Task<PaginatedListResponse<AssemblyCompactResponse>> GetListAsync(AssemblyListRequest paginationParams = null)
        {
            return await _client.SendRequest<PaginatedListResponse<AssemblyCompactResponse>>(HttpMethod.Get, $"/assemblies", paginationParams);
        }

        public async Task<AssemblyResponse> CreateAsync(AssemblyRequest assembly)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Post, $"/assemblies", assembly);
        }

        public async Task<AssemblyResponse> UpdateAsync(AssemblyRequest assembly)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Put, $"/assemblies", assembly);
        }

        public async Task<AssemblyResponse> CancelAsync(string assemblyId)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Delete, $"/assemblies/{assemblyId}");
        }

        public async Task<AssemblyResponse> CancelByUrlAsync(string assemblyUrl)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Delete, assemblyUrl); //todo: different method
        }

        public async Task<AssemblyResponse> ReplayAsync(string assemblyId, ReplayAssemblyRequest replayAssembly = null)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Post, $"/assemblies/{assemblyId}/replay", replayAssembly);
        }
    }
}
