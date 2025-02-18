using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models.Queues;

namespace Transloadit.Services
{
    /// <summary>
    /// Represents API requests to <c>/queues</c> endpoints.
    /// </summary>
    public class QueuesService
    {
        private readonly TransloaditClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueuesService"/> class with given <see cref="TransloaditClient"/>.
        /// </summary>
        /// <param name="client">Transloadit client</param>
        public QueuesService(TransloaditClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Retrieves job slots information.
        /// </summary>
        /// <returns>Job slots information.</returns>
        public async Task<QueueResponse> GetJobSlotsAsync()
        {
            return await _client.SendRequest<QueueResponse>(HttpMethod.Get, $"/queues/job_slots");
        }
    }
}
