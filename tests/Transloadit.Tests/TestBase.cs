using Transloadit.Tests.Configuration;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Transloadit.Tests
{
    public class TestBase
    {
        public TransloaditConfig Transloadit { get; set; }
        public TransloaditClient TransloaditClient { get; set; }
        public TransloaditClient TransloaditClientNoAuth { get; set; }

        public TestBase()
        {
            Transloadit = TestConfiguration.ReadFromAppSettings().Transloadit;
            TransloaditClient = new TransloaditClient(Transloadit.AuthKey, Transloadit.AuthSecret);
            TransloaditClientNoAuth = new TransloaditClient(Transloadit.AuthKey);
        }
    }
}
