using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transloadit.Models.Credentials;
using Transloadit.Serialization;
using Xunit;

using Transloadit.Tests.Infrastructure;

namespace Transloadit.Tests.Tests.Models
{
    // reflection-driven coverage over every concrete credentials request that has a
    // parameterless constructor: instantiate, serialize, and assert the type discriminator.
    public class CredentialsSerializationSmokeTests
    {
        public static IEnumerable<object[]> CredentialsTypeNames()
        {
            return ConcreteCredentialsTypes().Select(t => new object[] { t.FullName });
        }

        [Theory]
        [MemberData(nameof(CredentialsTypeNames))]
        public void Credentials_Serializes_WithTypeDiscriminator(string typeName)
        {
            var type = typeof(TransloaditClient).Assembly.GetType(typeName, throwOnError: true);
            var credentials = (CredentialsRequestBase)Activator.CreateInstance(type);

            var json = TestSerializer.Default.Serialize(credentials);
            var parsed = JObject.Parse(json);

            Assert.False(string.IsNullOrEmpty(credentials.Type));
            Assert.Equal(credentials.Type, (string)parsed["type"]);
        }

        [Fact]
        public void Discovers_ManyCredentialsTypes()
        {
            var count = ConcreteCredentialsTypes().Count();
            Assert.True(count >= 10, $"expected many credentials types, found {count}");
        }

        private static IEnumerable<Type> ConcreteCredentialsTypes()
        {
            return typeof(TransloaditClient).Assembly
                .GetTypes()
                .Where(t => typeof(CredentialsRequestBase).IsAssignableFrom(t)
                    && !t.IsAbstract
                    && t.GetConstructor(Type.EmptyTypes) != null);
        }
    }
}
