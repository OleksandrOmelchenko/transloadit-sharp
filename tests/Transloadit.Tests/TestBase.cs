using Transloadit.Tests.Configuration;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Transloadit.Tests
{
    public class TestBase
    {
        public TransloaditConfig Configuration { get; set; }
        public TransloaditClient TransloaditClient { get; set; }
        public TransloaditClient TransloaditClientNoAuth { get; set; }

        public TestBase()
        {
            Configuration = TestConfiguration.ReadFromAppSettings().Transloadit;
            TransloaditClient = new TransloaditClient(Configuration.AuthKey, Configuration.AuthSecret);
            TransloaditClientNoAuth = new TransloaditClient(Configuration.AuthKey);
        }
    }
}
