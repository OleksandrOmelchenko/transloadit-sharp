using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models.AssemblyNotifications;

namespace Transloadit.Services
{
    /// <summary>
    /// Represents API requests to <c>/assembly_notifications</c> endpoints.
    /// </summary>
    public class AssemblyNotificationsService
    {
        private readonly TransloaditClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyNotificationsService"/> class with given <see cref="TransloaditClient"/>.
        /// </summary>
        /// <param name="client">Transloadit client</param>
        public AssemblyNotificationsService(TransloaditClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Replays an assembly notification.
        /// </summary>
        /// <param name="assemblyId">Assembly id.</param>
        /// <param name="notificationRequest">Replay notification settings.</param>
        /// <returns>Replay notification response.</returns>
        public async Task<ReplayNotificationResponse> ReplayAsync(string assemblyId, ReplayNotificationRequest notificationRequest = null)
        {
            return await _client.SendRequest<ReplayNotificationResponse>(
                HttpMethod.Post,
                $"/assembly_notifications/{assemblyId}/replay",
                notificationRequest);
        }
    }
}
