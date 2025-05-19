using System;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;

namespace Transloadit.Utilities
{
    /// <summary>
    /// Represents an Assembly tracker.
    /// </summary>
    public class AssemblyTracker
    {
        private readonly TransloaditClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyTracker"/> class with given <see cref="TransloaditClient"/>.
        /// </summary>
        /// <param name="client">Transloadit client</param>
        public AssemblyTracker(TransloaditClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Waits Assembly completion using polling.
        /// </summary>
        /// <param name="assemblyId">Assembly id.</param>
        /// <param name="millisecondsDelay">Delay in milliseconds.</param>
        /// <returns>Completed assembly.</returns>
        public async Task<AssemblyResponse> WaitCompletion(string assemblyId, int millisecondsDelay = 1000)
        {
            var assemblyResponse = await _client.Assemblies.GetAsync(assemblyId).ConfigureAwait(false);
            return await WaitCompletion(assemblyResponse, millisecondsDelay).ConfigureAwait(false);
        }

        /// <summary>
        /// Waits Assembly completion using polling.
        /// </summary>
        /// <param name="assemblyUrl">Assembly url.</param>
        /// <param name="millisecondsDelay">Delay in milliseconds.</param>
        /// <returns>Completed assembly.</returns>
        public async Task<AssemblyResponse> WaitCompletion(Uri assemblyUrl, int millisecondsDelay = 1000)
        {
            var assemblyResponse = await _client.Assemblies.GetAsync(assemblyUrl).ConfigureAwait(false);
            return await WaitCompletion(assemblyResponse, millisecondsDelay).ConfigureAwait(false);
        }

        /// <summary>
        /// Waits Assembly completion using polling.
        /// </summary>
        /// <param name="assembly">Assembly.</param>
        /// <param name="millisecondsDelay">Delay in milliseconds.</param>
        /// <returns>Completed assembly.</returns>
        public async Task<AssemblyResponse> WaitCompletion(AssemblyResponse assembly, int millisecondsDelay = 1000)
        {
            var assemblyResponse = assembly;
            while (assemblyResponse.Base.Ok is ResponseCodes.AssemblyExecuting or ResponseCodes.AssemblyUploading)
            {
                await Task.Delay(millisecondsDelay).ConfigureAwait(false);
                assemblyResponse = await _client.Assemblies.GetAsync(assembly.AssemblyId).ConfigureAwait(false);
            }

            return assemblyResponse;
        }
    }
}
