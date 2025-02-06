using System;
using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models.Billing;

namespace Transloadit.Services
{
    public class BillingService
    {
        private readonly TransloaditClient _client;

        public BillingService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<BillingResponse> GetAsync(DateTime dateTime)
        {
            return await GetAsync(dateTime.Year, dateTime.Month);
        }

        public async Task<BillingResponse> GetAsync(int year, int month)
        {
            return await _client.SendRequest<BillingResponse>(HttpMethod.Get, $"/bill/{year:0000}-{month:00}");
        }
    }
}
