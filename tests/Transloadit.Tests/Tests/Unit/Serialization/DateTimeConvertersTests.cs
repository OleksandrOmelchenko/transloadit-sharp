#if TRANSLOADIT_NEWTONSOFT
using System;
using Newtonsoft.Json;
using Transloadit.Serialization;
using Xunit;

namespace Transloadit.Tests.Tests.Unit.Serialization
{
    public class DateTimeConvertersTests
    {
        private static readonly DateTime SampleUtc = new DateTime(2025, 2, 20, 1, 52, 4, DateTimeKind.Utc);

        [Fact]
        public void AuthExpiresConverter_UsesTransloaditFormat()
        {
            var json = JsonConvert.SerializeObject(SampleUtc, new AuthExpiresDateTimeConverter());
            Assert.Equal("\"2025/02/20 01:52:04+00:00\"", json);
        }

        [Fact]
        public void PaginationConverter_UsesSpaceSeparatedFormat()
        {
            var json = JsonConvert.SerializeObject(SampleUtc, new PaginationDateTimeConverter());
            Assert.Equal("\"2025-02-20 01:52:04\"", json);
        }
    }
}
#endif
