using Transloadit.Serialization;

namespace Transloadit.Tests.Infrastructure;

// the default serializer for the current target framework (System.Text.Json, or Newtonsoft on net461).
// tests serialize through this so they exercise whichever provider is active per TFM.
internal static class TestSerializer
{
    public static readonly ITransloaditSerializer Default = TransloaditSerializerFactory.CreateDefault();
}
