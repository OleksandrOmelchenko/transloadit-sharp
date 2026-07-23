namespace Transloadit.Serialization
{
    /// <summary>
    /// Creates the default <see cref="ITransloaditSerializer"/> for the current target framework:
    /// System.Text.Json, or Newtonsoft.Json on frameworks where System.Text.Json is unavailable (net452, net461).
    /// </summary>
    public static class TransloaditSerializerFactory
    {
        /// <summary>
        /// Creates a new default <see cref="ITransloaditSerializer"/> for the current framework.
        /// </summary>
        /// <returns>A new default serializer instance.</returns>
        public static ITransloaditSerializer CreateDefault()
        {
#if TRANSLOADIT_NEWTONSOFT
            return new NewtonsoftJsonSerializer();
#else
            return new SystemTextJsonSerializer();
#endif
        }
    }
}
