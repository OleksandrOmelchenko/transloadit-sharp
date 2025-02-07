using System.Collections.Generic;

namespace Transloadit.Models.Credentials
{
    public abstract class CredentialsRequestBase : BaseParams
    {
        public string Name { get; set; }
        public string Type { get; protected set; }
    }

    public class GenericCredentialsRequest : CredentialsRequestBase
    {
        public GenericCredentialsRequest(string type)
        {
            Type = type;
        }

        public Dictionary<string, string> Content { get; set; }
    }

    public class CredentialsRequest<T> : CredentialsRequestBase
    {
        public T Content { get; set; }
    }
}
