using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transloadit.Models.Robots;
using Transloadit.Models.Robots.FileImporting;
using Transloadit.Models.Robots.ImageManipulation;
using Transloadit.Serialization;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Unit;

// guards the base-class generic-param model:
//   RobotBase           -> result, force_accept, output_meta, interpolate, queue  (universal)
//   ProcessingRobotBase -> ignore_errors                                          (non-import only)
//   ImportRobotBase     -> force_name, import_on_errors, return_file_stubs; NO ignore_errors
public class BaseRobotParamsTests
{
    [Fact]
    public void ProcessingRobot_SerializesUniversalAndIgnoreErrors()
    {
        var robot = new ImageResizeRobot
        {
            OutputMeta = true,
            Interpolate = false,
            Queue = "batch",
            IgnoreErrors = true,
        };

        var json = JObject.Parse(TestSerializer.Default.Serialize(robot));

        Assert.True((bool)json["output_meta"]);
        Assert.False((bool)json["interpolate"]);
        Assert.Equal("batch", (string)json["queue"]);
        Assert.True((bool)json["ignore_errors"]);
    }

    [Fact]
    public void ImportRobot_SerializesUniversalAndImportParams_ButNotIgnoreErrors()
    {
        var robot = new S3ImportRobot
        {
            OutputMeta = true,
            Queue = "batch",
            ForceName = "renamed.jpg",
            ImportOnErrors = new List<string> { "meta" },
            ReturnFileStubs = true,
        };

        var json = JObject.Parse(TestSerializer.Default.Serialize(robot));

        Assert.True((bool)json["output_meta"]);
        Assert.Equal("batch", (string)json["queue"]);
        Assert.Equal("renamed.jpg", (string)json["force_name"]);
        Assert.Equal("meta", (string)json["import_on_errors"][0]);
        Assert.True((bool)json["return_file_stubs"]);
        Assert.Null(json["ignore_errors"]);
    }

    [Fact]
    public void RobotBase_UniversalParams_AreOnEveryRobot()
    {
        foreach (var type in ConcreteRobotTypes())
        {
            Assert.NotNull(type.GetProperty("OutputMeta"));
            Assert.NotNull(type.GetProperty("Interpolate"));
            Assert.NotNull(type.GetProperty("Queue"));
        }
    }

    [Fact]
    public void IgnoreErrors_IsOnNonImportRobots_NotImports()
    {
        foreach (var type in ConcreteRobotTypes())
        {
            var isImport = typeof(ImportRobotBase).IsAssignableFrom(type);
            var hasIgnoreErrors = type.GetProperty("IgnoreErrors") != null;
            if (isImport)
            {
                Assert.False(hasIgnoreErrors, $"{type.Name} is an import robot and must not expose IgnoreErrors");
            }
        }
    }

    [Fact]
    public void ImportRobots_ExposeUniversalImportParams()
    {
        // force_name and import_on_errors are documented on every import robot (18/18);
        // return_file_stubs is only on a subset (9/18), so it is modelled per-robot, not on the base.
        foreach (var type in ConcreteRobotTypes().Where(t => typeof(ImportRobotBase).IsAssignableFrom(t)))
        {
            Assert.NotNull(type.GetProperty("ForceName"));
            Assert.NotNull(type.GetProperty("ImportOnErrors"));
        }
    }

    private static IEnumerable<Type> ConcreteRobotTypes()
    {
        return typeof(TransloaditClient).Assembly
            .GetTypes()
            .Where(t => typeof(RobotBase).IsAssignableFrom(t) && !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null);
    }
}
