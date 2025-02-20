using Newtonsoft.Json.Converters;

namespace Transloadit.Serialization
{
    /// <summary>
    /// Represents date time converter used to format dates in specific Trasloadit format.
    /// </summary>
    public class AuthExpiresDateTimeConverter : IsoDateTimeConverter
    {
        public AuthExpiresDateTimeConverter()
        {
            DateTimeFormat = "yyyy'/'MM'/'dd HH:mm:ss+00:00";
        }
    }

    /// <summary>
    /// Represents date time converter used to format dates when using pagination.
    /// </summary>
    public class PaginationDateTimeConverter : IsoDateTimeConverter
    {
        public PaginationDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
