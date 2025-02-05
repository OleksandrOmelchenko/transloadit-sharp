using Transloadit.Tests.Configuration;

namespace Transloadit.Tests
{
    public class TestBase
    {
        public TransloaditConfig Transloadit { get; set; }
        public TransloaditClient TransloaditClient { get; set; }

        public TestBase()
        {
            Transloadit = TestConfiguration.ReadFromAppSettings().Transloadit;
            TransloaditClient = new TransloaditClient(Transloadit.AuthKey, Transloadit.AuthSecret);
        }
    }
}
