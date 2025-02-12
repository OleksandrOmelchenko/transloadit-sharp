using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots
{
    public class AdvancedUse
    {
        public AnyOf<List<string>, List<AdvancedStep>> Steps { get; set; }
        public bool? BundleSteps { get; set; }
        public bool? GroupByOriginal { get; set; }
        public List<string> Fields { get; set; }
    }

    public class AdvancedStep
    {
        public string Name { get; set; }
        public string As { get; set; }
        public string Fields { get; set; }
    }


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
