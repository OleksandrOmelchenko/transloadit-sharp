using System.Collections.Generic;
using Transloadit.Models;
using Transloadit.Models.Robots;

namespace Transloadit.Tests.Robots
{
    public class TestImageResizeRobot : RobotBase
    {
        public AnyOf<string, List<string>> Use { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public TestImageResizeRobot()
        {
            Robot = "/image/resize";
        }
    }

    public class TestHttpImportRobot : RobotBase
    {
        public string Url { get; set; }

        public TestHttpImportRobot()
        {
            Robot = "/http/import";
        }
    }

    public class TestImageOptimizeRobot : RobotBase
    {
        public string Use { get; set; }
        public string Priority { get; set; }
        public bool PreserveMetaData { get; set; }

        public TestImageOptimizeRobot()
        {
            Robot = "/image/optimize";
        }
    }
}
