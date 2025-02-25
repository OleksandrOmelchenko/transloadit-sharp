using Newtonsoft.Json.Converters;

namespace Transloadit.Serialization
{
    /// <summary>
    /// Represents date time converter used to format dates in specific Trasloadit format.
    /// </summary>
    public class AuthExpiresDateTimeConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthExpiresDateTimeConverter"/> with <c>"yyyy'/'MM'/'dd HH:mm:ss+00:00"</c> date format.
        /// </summary>
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
         /// <summary>
        /// Initializes a new instance of the <see cref="PaginationDateTimeConverter"/> with <c>"yyyy-MM-dd HH:mm:ss"</c> date format.
        /// </summary>
        public PaginationDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
