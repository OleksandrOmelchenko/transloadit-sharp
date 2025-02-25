using System.Collections.Generic;

namespace Transloadit.Models.Credentials
{
    /// <summary>
    /// Represents base credentials request object.
    /// </summary>
    public abstract class CredentialsRequestBase : BaseParams
    {
        /// <summary>
        /// Template credentials name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Template credentials type.
        /// </summary>
        public string Type { get; protected set; }
    }

    /// <summary>
    /// Represents generic credentials request.
    /// </summary>
    public class GenericCredentialsRequest : CredentialsRequestBase
    {
        /// <summary>
        /// Initializes generic credentials request.
        /// </summary>
        public GenericCredentialsRequest(string type)
        {
            Type = type;
        }

        /// <summary>
        /// Generic credentials content.
        /// </summary>
        public Dictionary<string, string> Content { get; set; }
    }
}
