#if TRANSLOADIT_NEWTONSOFT
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Transloadit.Serialization;
using Xunit;

namespace Transloadit.Tests.Tests
{
    public class SerializationDefaultsTests
    {
        [Fact]
        public void CreateDefault_Should_ReturnExpectedDefaults()
        {
            var settings = TransloaditSerializerSettings.CreateDefault();

            Assert.Equal(NullValueHandling.Ignore, settings.NullValueHandling);
            var resolver = Assert.IsType<TransloaditContractResolver>(settings.ContractResolver);
            Assert.IsType<SnakeCaseNamingStrategy>(resolver.NamingStrategy);
            Assert.Contains(settings.Converters, converter => converter is AnyOfConverter);
        }

        [Fact]
        public void CreateDefault_Should_ReturnNewInstanceEachCall()
        {
            var first = TransloaditSerializerSettings.CreateDefault();
            var second = TransloaditSerializerSettings.CreateDefault();

            Assert.NotSame(first, second);
            Assert.NotSame(first.Converters, second.Converters);
            Assert.Contains(first.Converters, c => c is AnyOfConverter);
            Assert.Contains(second.Converters, c => c is AnyOfConverter);
        }
    }
}
#endif
