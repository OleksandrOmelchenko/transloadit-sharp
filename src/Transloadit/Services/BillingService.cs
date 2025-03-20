using System;
using System.Net.Http;

using System.Threading.Tasks;
using Transloadit.Models.Billing;

namespace Transloadit.Services
{
    /// <summary>
    /// Represents API requests to <c>/bill</c> endpoints.
    /// </summary>
    public class BillingService
    {
        private readonly TransloaditClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingService"/> class with given <see cref="TransloaditClient"/>.
        /// </summary>
        /// <param name="client">Transloadit client</param>
        public BillingService(TransloaditClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Retrieves billing information for the period.
        /// </summary>
        /// <param name="dateTime">Biling date.</param>
        /// <returns>Billing information.</returns>
        public async Task<BillingResponse> GetAsync(DateTime dateTime)
        {
            return await GetAsync(dateTime.Year, dateTime.Month)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves billing information for the period.
        /// </summary>
        /// <param name="year">Billing year.</param>
        /// <param name="month">Billing month.</param>
        /// <returns>Billing information.</returns>
        public async Task<BillingResponse> GetAsync(int year, int month)
        {
            return await _client.SendRequest<BillingResponse>(HttpMethod.Get, $"/bill/{year:0000}-{month:00}")
                .ConfigureAwait(false);
        }
    }
}
