using System.Collections.Generic;

namespace Transloadit.Models.Templates
{
    public class TemplateRequest : BaseParams
    {
        public string Name { get; set; }

        public int RequireSignatureAuth { get; set; }

        public TemplateRequestContent Template { get; set; }
    }

    public class TemplateRequestContent
    {
        public Dictionary<string, RobotBase> Steps { get; set; }
    }

    public abstract class RobotBase
    {
        public string Robot { get; protected set; }
    }
}
