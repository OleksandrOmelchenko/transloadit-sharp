using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Api.Existence;

// opt-in live verification that every robot the library defines actually exists in the Transloadit API.
// gated behind RUN_EXISTENCE_CHECKS=1 because it makes one assembly-create call per robot (~88). a robot whose
// Robot string was renamed or removed upstream fails with ASSEMBLY_STEP_UNKNOWN_ROBOT; an existing robot with
// missing params returns a different error (or succeeds), which still confirms the robot is recognized.
public class RobotExistenceApiTests : TestBase
{
    private static bool Enabled => Environment.GetEnvironmentVariable("RUN_EXISTENCE_CHECKS") == "1";

    public static IEnumerable<object[]> RobotTypeNames()
    {
        if (!Enabled)
        {
            // sentinel so the theory has data; the test no-ops when the check is disabled
            yield return new object[] { null };
            yield break;
        }

        var types = typeof(TransloaditClient).Assembly
            .GetTypes()
            .Where(t => typeof(RobotBase).IsAssignableFrom(t) && !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null)
            .OrderBy(t => t.FullName, StringComparer.Ordinal);

        foreach (var type in types)
        {
            yield return new object[] { type.FullName };
        }
    }

    [Theory]
    [MemberData(nameof(RobotTypeNames))]
    public async Task Robot_ExistsInApi(string typeName)
    {
        if (typeName == null)
        {
            return; // disabled — set RUN_EXISTENCE_CHECKS=1 to run
        }

        var type = typeof(TransloaditClient).Assembly.GetType(typeName, throwOnError: true);
        var robot = (RobotBase)Activator.CreateInstance(type);

        var request = new AssemblyRequest
        {
            Steps = new Dictionary<string, RobotBase> { ["step1"] = robot },
        };

        var response = await RateLimit.Retry(() => TransloaditClient.Assemblies.CreateAsync(request));

        Assert.False(
            response.Base.Error == ResponseCodes.AssemblyStepUnknownRobot,
            $"{robot.Robot} ({type.Name}) is not recognized by the API " +
            $"(error={response.Base.Error}, reason={response.Base.Reason})");
    }
}
