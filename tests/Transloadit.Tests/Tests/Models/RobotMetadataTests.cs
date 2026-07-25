using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Transloadit.Models.Robots;
using Xunit;

namespace Transloadit.Tests.Tests.Models;

// integrity checks over every concrete robot: its Robot path string must be present, well-formed, and unique.
// catches copy-paste mistakes when adding a robot — a duplicated path (two classes claiming the same robot) or a
// malformed one — which the per-robot NewRobotsTests assertions do not catch globally.
public class RobotMetadataTests
{
    private static readonly Regex RobotPath = new Regex("^(/[a-z0-9]+(-[a-z0-9]+)*){2,}$", RegexOptions.Compiled);

    private static IEnumerable<RobotBase> AllRobots()
        => typeof(TransloaditClient).Assembly
            .GetTypes()
            .Where(type => typeof(RobotBase).IsAssignableFrom(type) && !type.IsAbstract && type.GetConstructor(Type.EmptyTypes) != null)
            .Select(type => (RobotBase)Activator.CreateInstance(type));

    [Fact]
    public void EveryRobot_HasAWellFormedPath()
    {
        var bad = AllRobots()
            .Where(robot => string.IsNullOrEmpty(robot.Robot) || !RobotPath.IsMatch(robot.Robot))
            .Select(robot => $"{robot.GetType().Name} -> '{robot.Robot}'")
            .ToList();

        Assert.True(
            bad.Count == 0,
            "robots with a missing or malformed Robot path (expected /category/name):" + Environment.NewLine + string.Join(Environment.NewLine, bad));
    }

    [Fact]
    public void RobotPaths_AreUnique()
    {
        var duplicates = AllRobots()
            .GroupBy(robot => robot.Robot)
            .Where(group => group.Count() > 1)
            .Select(group => $"'{group.Key}' claimed by {string.Join(", ", group.Select(r => r.GetType().Name))}")
            .ToList();

        Assert.True(
            duplicates.Count == 0,
            "duplicate Robot paths (each robot must map to a distinct path):" + Environment.NewLine + string.Join(Environment.NewLine, duplicates));
    }
}
