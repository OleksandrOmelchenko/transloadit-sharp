using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Transloadit.Serialization
{
    /// <summary>
    /// Factory for creating <see cref="JsonSerializerSettings"/> configured for Transloadit API communication.
    /// </summary>
    public static class TransloaditSerializerSettings
    {
        /// <summary>
        /// Creates default <see cref="JsonSerializerSettings"/> used by <see cref="TransloaditClient"/>.
        /// Use this method to start from the built-in defaults and apply customizations before
        /// assigning settings to <see cref="TransloaditClientOptions.RequestSerializerSettings"/> or
        /// <see cref="TransloaditClientOptions.ResponseSerializerSettings"/>.
        /// </summary>
        /// <returns>New instance of default <see cref="JsonSerializerSettings"/>.</returns>
        public static JsonSerializerSettings CreateDefault()
        {
            return new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy(),
                },
                Converters = [new AnyOfConverter()],
            };
        }
    }
}
