using System.Collections.Generic;

namespace Transloadit.Models.Templates
{
    public class TemplateRequest : BaseParams
    {
        public string Name { get; set; }

        public int RequireSignatureAuth { get; set; }

        public TemplateBodyBase Template { get; set; }
    }

    public abstract class TemplateBodyBase
    {

    }

    public class TemplateBodyGeneric : TemplateBodyBase
    {
        public Dictionary<string, Dictionary<string, object>> Steps { get; set; }
    }

    public class TemplateBody : TemplateBodyBase
    {
        public Dictionary<string, RobotBase> Steps { get; set; }
    }

    public abstract class RobotBase
    {
        public string Robot { get; protected set; }
    }
}
