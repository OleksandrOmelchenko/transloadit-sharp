#if NET452
using System;

namespace Transloadit.Polyfills
{
    internal static class DateTimeOffsetExtensions
    {
        public static long ToUnixTimeMilliseconds(this DateTimeOffset dateTimeOffset)
        {
            var unixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            return (long)(dateTimeOffset - unixEpoch).TotalMilliseconds;
        }
    }
}
#endif