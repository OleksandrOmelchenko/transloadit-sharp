using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transloadit.Models.Robots;
using Transloadit.Serialization;
using Xunit;

namespace Transloadit.Tests.Tests.Models
{
    // reflection-driven coverage over every concrete robot in the library assembly:
    // instantiate, serialize with the default settings, and assert the robot key is emitted.
    // this keeps coverage broad and fails automatically if a new robot breaks serialization.
    public class RobotSerializationSmokeTests
    {
        public static IEnumerable<object[]> RobotTypeNames()
        {
            return ConcreteRobotTypes().Select(t => new object[] { t.FullName });
        }

        [Theory]
        [MemberData(nameof(RobotTypeNames))]
        public void Robot_Serializes_WithMatchingRobotKey(string typeName)
        {
            var type = typeof(TransloaditClient).Assembly.GetType(typeName, throwOnError: true);
            var robot = (RobotBase)Activator.CreateInstance(type);

            var json = JsonConvert.SerializeObject(robot, TransloaditSerializerSettings.CreateDefault());
            var parsed = JObject.Parse(json);

            Assert.Equal(robot.Robot, (string)parsed["robot"]);
        }

        [Fact]
        public void Discovers_ManyRobots()
        {
            var count = ConcreteRobotTypes().Count();
            Assert.True(count >= 80, $"expected the library to expose many robots, found {count}");
        }

        private static IEnumerable<Type> ConcreteRobotTypes()
        {
            return typeof(TransloaditClient).Assembly
                .GetTypes()
                .Where(t => typeof(RobotBase).IsAssignableFrom(t)
                    && !t.IsAbstract
                    && t.GetConstructor(Type.EmptyTypes) != null);
        }
    }
}
