using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models;

namespace Transloadit.Services
{
    public class QueuesService
    {
        private readonly TransloaditClient _client;

        public QueuesService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<QueueResponse> GetJobSlotsAsync()
        {
            return await _client.SendRequest<QueueResponse>(HttpMethod.Get, $"/queues/job_slots");
        }
    }
}
