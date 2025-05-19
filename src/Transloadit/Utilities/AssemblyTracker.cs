using System;
using System.Threading;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;

namespace Transloadit.Utilities
{
    /// <summary>
    /// Contains configuration for <see cref="AssemblyTracker"/>.
    /// </summary>
    public class AssemblyTrackerOptions
    {
        /// <summary>
        /// Completion timeout in milliseconds.
        /// </summary>
        public int WaitCompletionTimeout { get; set; }
    }

    /// <summary>
    /// Represents an Assembly tracker.
    /// </summary>
    public class AssemblyTracker
    {
        private readonly TransloaditClient _client;
        private readonly AssemblyTrackerOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyTracker"/> class with given <see cref="TransloaditClient"/>.
        /// </summary>
        /// <param name="client">Transloadit client</param>
        /// <param name="options">Assembly tracker options</param>
        public AssemblyTracker(TransloaditClient client, AssemblyTrackerOptions options = null)
        {
            _client = client;
            _options = MergeOptions(options);
        }

        private AssemblyTrackerOptions MergeOptions(AssemblyTrackerOptions options)
        {
            return new AssemblyTrackerOptions
            {
                WaitCompletionTimeout = options?.WaitCompletionTimeout ?? 30000,
            };
        }

        /// <summary>
        /// Waits Assembly completion using polling.
        /// </summary>
        /// <param name="assemblyId">Assembly id.</param>
        /// <param name="millisecondsDelay">Delay in milliseconds.</param>
        /// <returns>Completed assembly.</returns>
        public async Task<AssemblyResponse> WaitCompletionAsync(string assemblyId, int millisecondsDelay = 1000)
        {
            var assemblyResponse = await _client.Assemblies.GetAsync(assemblyId).ConfigureAwait(false);
            return await WaitCompletionAsync(assemblyResponse, millisecondsDelay).ConfigureAwait(false);
        }

        /// <summary>
        /// Waits Assembly completion using polling.
        /// </summary>
        /// <param name="assemblyUrl">Assembly url.</param>
        /// <param name="millisecondsDelay">Delay in milliseconds.</param>
        /// <returns>Completed assembly.</returns>
        public async Task<AssemblyResponse> WaitCompletionAsync(Uri assemblyUrl, int millisecondsDelay = 1000)
        {
            var assemblyResponse = await _client.Assemblies.GetAsync(assemblyUrl).ConfigureAwait(false);
            return await WaitCompletionAsync(assemblyResponse, millisecondsDelay).ConfigureAwait(false);
        }

        /// <summary>
        /// Waits Assembly completion using polling.
        /// </summary>
        /// <param name="assembly">Assembly.</param>
        /// <param name="millisecondsDelay">Delay in milliseconds.</param>
        /// <returns>Completed assembly.</returns>
        public async Task<AssemblyResponse> WaitCompletionAsync(AssemblyResponse assembly, int millisecondsDelay = 1000)
        {
            var assemblyResponse = assembly;
            using var cts = new CancellationTokenSource(_options.WaitCompletionTimeout);
            while (assemblyResponse.Base.Ok is ResponseCodes.AssemblyExecuting or ResponseCodes.AssemblyUploading)
            {
                await Task.Delay(millisecondsDelay, cts.Token).ConfigureAwait(false);
                assemblyResponse = await _client.Assemblies.GetAsync(assembly.AssemblyId).ConfigureAwait(false);
            }

            return assemblyResponse;
        }
    }
}
