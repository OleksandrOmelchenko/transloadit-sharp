using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots
{
    public class TestImageResizeRobot : RobotBase
    {
        public string Use { get; set; }
        public bool Result { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public TestImageResizeRobot()
        {
            Robot = "/image/resize";
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
