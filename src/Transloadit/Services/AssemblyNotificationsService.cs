﻿using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models.AssemblyNotifications;

namespace Transloadit.Services
{
    public class AssemblyNotificationsService
    {
        private readonly TransloaditClient _client;

        public AssemblyNotificationsService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<ReplayNotificationResponse> ReplayAsync(string assemblyId, ReplayNotificationRequest notificationRequest = null)
        {
            return await _client.SendRequest<ReplayNotificationResponse>(
                HttpMethod.Post,
                $"/assembly_notifications/{assemblyId}/replay",
                notificationRequest);
        }
    }
}
