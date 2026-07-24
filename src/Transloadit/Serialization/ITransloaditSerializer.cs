namespace Transloadit.Serialization
{
    /// <summary>
    /// Abstracts the JSON serializer used by <see cref="TransloaditClient"/>, allowing the underlying engine
    /// (System.Text.Json, Newtonsoft.Json, or a custom implementation) to be plugged in.
    /// </summary>
    public interface ITransloaditSerializer
    {
        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <returns>The JSON representation of <paramref name="value"/>.</returns>
        string Serialize(object value);

        /// <summary>
        /// Deserializes the specified JSON string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>The deserialized instance.</returns>
        T Deserialize<T>(string json);
    }
}
