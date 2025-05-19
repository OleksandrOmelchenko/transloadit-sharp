using Transloadit.Tests.Configuration;
using Transloadit.Utilities;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Transloadit.Tests
{
    public class TestBase
    {
        public TransloaditConfig Configuration { get; }
        public TransloaditClient TransloaditClient { get; }
        public TransloaditClient TransloaditClientNoAuth { get; }
        public AssemblyTracker AssemblyTracker { get; }

        public TestBase()
        {
            Configuration = TestConfiguration.ReadFromAppSettings().Transloadit;
            TransloaditClient = new TransloaditClient(Configuration.AuthKey, Configuration.AuthSecret);
            TransloaditClientNoAuth = new TransloaditClient(Configuration.AuthKey);
            AssemblyTracker = new AssemblyTracker(TransloaditClient);
        }
    }
}
