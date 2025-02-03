using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transloadit.Services
{
    public class BillingService
    {
        private readonly TransloaditClient _client;

        public BillingService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<BillingReponse> GetAsync(DateTime dateTime)
        {
            return await GetAsync(dateTime.Year, dateTime.Month);
        }

        public async Task<BillingReponse> GetAsync(int year, int month)
        {
            return await _client.SendRequest<BillingReponse>(HttpMethod.Get, $"/bill/{year:0000}-{month:00}");
        }
    }

    public class TemplateService
    {
        private readonly TransloaditClient _client;

        public TemplateService(TransloaditClient client)
        {
            _client = client;
        }

        public async Task<TemplateResponse> GetAsync(string id)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Get, $"/templates/{id}");
        }

        public async Task<PaginatedList<TemplateResponse>> GetListAsync()
        {
            return await _client.SendRequest<PaginatedList<TemplateResponse>>(HttpMethod.Get, $"/templates");
        }

        public async Task<TemplateResponse> DeleteAsync(string id)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Delete, $"/templates/{id}");
        }

        public async Task<TemplateResponse> CreateAsync(object template)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Post, $"/templates");
        }

        public async Task<TemplateResponse> UpdateAsync(object template)
        {
            return await _client.SendRequest<TemplateResponse>(HttpMethod.Put, $"/templates");
        }
    }
}
