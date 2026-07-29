using System.Collections.Generic;
using Transloadit.Models;
using Transloadit.Models.Robots;
using Transloadit.Serialization.Attributes;

namespace Transloadit.Tests.Robots;

// these doubles stand in for user-authored custom robots. like any model that flows through the client they must
// declare their JSON names with [TransloaditJsonName] — the serializers apply no naming convention of their own.
public class TestImageResizeRobot : RobotBase
{
    [TransloaditJsonName("use")]
    public AnyOf<string, List<string>> Use { get; set; }

    [TransloaditJsonName("width")]
    public int Width { get; set; }

    [TransloaditJsonName("height")]
    public int Height { get; set; }

    public TestImageResizeRobot()
    {
        Robot = "/image/resize";
    }
}

public class TestHttpImportRobot : RobotBase
{
    [TransloaditJsonName("url")]
    public string Url { get; set; }

    public TestHttpImportRobot()
    {
        Robot = "/http/import";
    }
}

public class TestImageOptimizeRobot : RobotBase
{
    [TransloaditJsonName("use")]
    public string Use { get; set; }

    [TransloaditJsonName("priority")]
    public string Priority { get; set; }

    [TransloaditJsonName("preserve_meta_data")]
    public bool PreserveMetaData { get; set; }

    public TestImageOptimizeRobot()
    {
        Robot = "/image/optimize";
    }
}

public class NonExistentRobot : RobotBase
{
    public NonExistentRobot()
    {
        Robot = "/robot/does-not-exist";
    }
}
