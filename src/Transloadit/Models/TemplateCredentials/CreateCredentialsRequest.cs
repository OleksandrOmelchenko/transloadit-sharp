using System.Collections.Generic;

namespace Transloadit.Models.TemplateCredentials
{
    public abstract class CreateCredentialsRequestBase : BaseParams
    {
        public string Name { get; set; }
        public string Type { get; protected set; }
    }

    public class CreateGenericCredentialsRequest : CreateCredentialsRequestBase
    {
        public CreateGenericCredentialsRequest(string type)
        {
            Type = type;
        }

        public Dictionary<string, string> Content { get; set; }
    }

    public class CreateCredentialsRequest<T> : CreateCredentialsRequestBase
    {
        public T Content { get; set; }
    }

   
}
