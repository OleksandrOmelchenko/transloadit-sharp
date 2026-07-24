#if TRANSLOADIT_NEWTONSOFT
using Newtonsoft.Json;

namespace Transloadit.Serialization;

/// <summary>
/// Factory for creating <see cref="JsonSerializerSettings"/> configured for Transloadit API communication.
/// Used by <see cref="NewtonsoftJsonSerializer"/>; also useful as a starting point when customizing the
/// Newtonsoft settings passed to <see cref="NewtonsoftJsonSerializer(System.Action{JsonSerializerSettings})"/>.
/// </summary>
public static class TransloaditSerializerSettings
{
    /// <summary>
    /// Creates the default Newtonsoft.Json <see cref="JsonSerializerSettings"/> used for Transloadit serialization:
    /// null values are ignored, the provider-neutral Transloadit attributes are honored via
    /// <see cref="TransloaditContractResolver"/>, and the <see cref="AnyOfConverter"/> is registered.
    /// </summary>
    /// <returns>New instance of default <see cref="JsonSerializerSettings"/>.</returns>
    public static JsonSerializerSettings CreateDefault()
    {
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new TransloaditContractResolver(),
        };
        settings.Converters.Add(new AnyOfConverter());
        return settings;
    }
}
#endif
