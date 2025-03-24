using System;
using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models;
using Transloadit.Models.Assemblies;

namespace Transloadit.Services
{
    /// <summary>
    /// Represents API requests to <c>/assemblies</c> endpoints.
    /// </summary>
    public class AssembliesService
    {
        private readonly TransloaditClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssembliesService"/> class with given <see cref="TransloaditClient"/>.
        /// </summary>
        /// <param name="client">Transloadit client</param>
        public AssembliesService(TransloaditClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Retrieves assembly data.
        /// </summary>
        /// <param name="assemblyId">Assembly id.</param>
        /// <returns>Requested assembly data.</returns>
        public async Task<AssemblyResponse> GetAsync(string assemblyId)
        {
            var parameters = new BaseParams
            {
                EnableSignatureAuth = false,
            };
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Get, $"/assemblies/{assemblyId}", parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves paginated list of assemblies.
        /// </summary>
        /// <param name="paginationParams">Pagination parameters.</param>
        /// <returns>Paginated list of assemblies.</returns>
        public async Task<PaginatedListResponse<AssemblyCompactResponse>> GetListAsync(AssemblyListRequest paginationParams = null)
        {
            return await _client.SendRequest<PaginatedListResponse<AssemblyCompactResponse>>(HttpMethod.Get, $"/assemblies", paginationParams)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creates and runs an assembly.
        /// </summary>
        /// <param name="assembly">Assembly creation data.</param>
        /// <param name="formData">Form data containing file uploads and other values, that can be referenced via <c>${fields.*}</c>.</param>
        /// <returns>Created assembly data.</returns>
        public async Task<AssemblyResponse> CreateAsync(AssemblyRequest assembly, MultipartFormDataContent formData = null)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Post, $"/assemblies", assembly, formData)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cancels an assembly (and upload if that is still in progress).
        /// </summary>
        /// <param name="assemblyId">Assembly id.</param>
        /// <returns>Canceled assembly data.</returns>
        public async Task<AssemblyResponse> CancelAsync(string assemblyId)
        {
            var parameters = new BaseParams
            {
                EnableSignatureAuth = false,
            };
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Delete, $"/assemblies/{assemblyId}", parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cancels an assembly (and upload if that is still in progress).
        /// </summary>
        /// <param name="assemblyUrl">Assembly url.</param>
        /// <returns>Canceled assembly data.</returns>
        public async Task<AssemblyResponse> CancelAsync(Uri assemblyUrl)
        {
            return await _client.SendRequest<AssemblyResponse>(HttpMethod.Delete, assemblyUrl)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Replays an assembly.
        /// </summary>
        /// <param name="assemblyId">Assembly id.</param>
        /// <param name="replayAssembly">Replay assembly data.</param>
        /// <returns>Replayed assembly data.</returns>
        public async Task<ReplayAssemblyResponse> ReplayAsync(string assemblyId, ReplayAssemblyRequest replayAssembly = null)
        {
            return await _client.SendRequest<ReplayAssemblyResponse>(HttpMethod.Post, $"/assemblies/{assemblyId}/replay", replayAssembly)
                .ConfigureAwait(false);
        }
    }
}
