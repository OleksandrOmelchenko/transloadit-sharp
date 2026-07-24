using System;
using System.Net;
using System.Threading.Tasks;
using Transloadit.Models;

namespace Transloadit.Tests.Infrastructure
{
    // small retry helper for the opt-in existence checks, which issue many live calls in a row and can trip the
    // account rate limit. adds a short delay before each attempt and backs off on HTTP 429.
    internal static class RateLimit
    {
        public static async Task<T> Retry<T>(Func<Task<T>> action, int maxAttempts = 5)
            where T : ResponseBase
        {
            for (var attempt = 0; ; attempt++)
            {
                await Task.Delay(200).ConfigureAwait(false);
                var result = await action().ConfigureAwait(false);
                // HttpStatusCode.TooManyRequests (429) is not defined on older TFMs, so compare the numeric value
                if ((int?)result?.TransloaditResponse?.StatusCode != 429 || attempt >= maxAttempts)
                {
                    return result;
                }

                await Task.Delay(2000 * (attempt + 1)).ConfigureAwait(false);
            }
        }
    }
}
