using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Transloadit.Tests.Infrastructure
{
    // wraps a real HttpClientHandler and captures each raw response body before the client deserializes it, so
    // integration tests can inspect the exact API payload even when deserialization would throw
    internal sealed class CapturingHandler : DelegatingHandler
    {
        public CapturingHandler()
            : base(new HttpClientHandler())
        {
        }

        public string LastResponseBody { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (response.Content != null)
            {
                LastResponseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            return response;
        }
    }
}
