using Newtonsoft.Json.Converters;

namespace Transloadit.Serialization
{
    public class AuthExpiresDateTimeConverter : IsoDateTimeConverter
    {
        public AuthExpiresDateTimeConverter()
        {
            DateTimeFormat = "yyyy'/'MM'/'dd HH:mm:ss+00:00";
        }
    }
}
