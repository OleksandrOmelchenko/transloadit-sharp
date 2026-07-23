using System;
using Newtonsoft.Json;

namespace Transloadit.Serialization
{
    /// <summary>
    /// <see cref="ITransloaditSerializer"/> implementation backed by Newtonsoft.Json.
    /// This is the default serializer on frameworks where System.Text.Json is not available (net452).
    /// </summary>
    public sealed class NewtonsoftJsonSerializer : ITransloaditSerializer
    {
        private readonly JsonSerializerSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonsoftJsonSerializer"/> class with the default settings.
        /// </summary>
        public NewtonsoftJsonSerializer()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonsoftJsonSerializer"/> class, allowing the default settings
        /// (null handling, contract resolver, converters) to be customized — for example to register additional converters.
        /// </summary>
        /// <param name="configure">An optional callback that receives the default <see cref="JsonSerializerSettings"/> before use.</param>
        public NewtonsoftJsonSerializer(Action<JsonSerializerSettings> configure)
        {
            _settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new TransloaditContractResolver(),
            };
            _settings.Converters.Add(new AnyOfConverter());
            configure?.Invoke(_settings);
        }

        /// <inheritdoc />
        public string Serialize(object value)
            => JsonConvert.SerializeObject(value, _settings);

        /// <inheritdoc />
        public T Deserialize<T>(string json)
            => JsonConvert.DeserializeObject<T>(json, _settings);
    }
}
