using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transloadit.Models.Credentials;
using Transloadit.Tests.Infrastructure;
using Xunit;

namespace Transloadit.Tests.Tests.Api.Existence
{
    // opt-in live verification that every credentials type the library defines maps to a credentials type the
    // Transloadit API recognizes. gated behind RUN_EXISTENCE_CHECKS=1 (one create call per type, ~16). an unknown
    // type discriminator makes the API reply "Invalid Credentials type: <type>"; a recognized type with missing
    // content fails differently (or succeeds), so empty content is enough to probe the type discriminator.
    public class CredentialExistenceApiTests : TestBase
    {
        private const string UnknownTypeMarker = "Invalid Credentials type";

        private static bool Enabled => Environment.GetEnvironmentVariable("RUN_EXISTENCE_CHECKS") == "1";

        public static IEnumerable<object[]> CredentialTypeNames()
        {
            if (!Enabled)
            {
                yield return new object[] { null };
                yield break;
            }

            var types = typeof(TransloaditClient).Assembly
                .GetTypes()
                .Where(t => typeof(CredentialsRequestBase).IsAssignableFrom(t) && !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null)
                .OrderBy(t => t.FullName, StringComparer.Ordinal);

            foreach (var type in types)
            {
                yield return new object[] { type.FullName };
            }
        }

        [Theory]
        [MemberData(nameof(CredentialTypeNames))]
        public async Task CredentialType_IsRecognizedByApi(string typeName)
        {
            if (typeName == null)
            {
                return; // disabled — set RUN_EXISTENCE_CHECKS=1 to run
            }

            var type = typeof(TransloaditClient).Assembly.GetType(typeName, throwOnError: true);
            var credential = (CredentialsRequestBase)Activator.CreateInstance(type);
            credential.Name = $"existence-{Guid.NewGuid():N}";

            var response = await RateLimit.Retry(() => TransloaditClient.Credentials.CreateAsync(credential));

            // clean up if a bare type actually created (unlikely without content, but be safe)
            if (response.Credential?.Id != null)
            {
                try
                {
                    await TransloaditClient.Credentials.DeleteAsync(response.Credential.Id);
                }
                catch
                {
                    // best-effort cleanup
                }
            }

            var message = response.Base.Message ?? string.Empty;
            Assert.False(
                message.Contains(UnknownTypeMarker),
                $"credentials type of {type.Name} is not recognized by the API (message={message})");
        }
    }
}
