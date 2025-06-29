using Transloadit.Tests.Robots;

namespace Transloadit.Tests.Fixtures
{
    public static class TestDataFactory
    {
        public static TestHttpImportRobot GetDemoHttpImportRobot() => new TestHttpImportRobot
        {
            Url = "https://demos.transloadit.com/66/01604e7d0248109df8c7cc0f8daef8/snowflake.jpg"
        };
    }
}
