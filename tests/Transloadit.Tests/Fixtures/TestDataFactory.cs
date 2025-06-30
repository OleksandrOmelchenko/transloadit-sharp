using Transloadit.Tests.Robots;

namespace Transloadit.Tests.Fixtures
{
    public static class TestDataFactory
    {
        public static TestHttpImportRobot GetDemoHttpImportRobot() => new TestHttpImportRobot
        {
            Url = TestConstants.DemoImageUrl,
        };
    }
}
