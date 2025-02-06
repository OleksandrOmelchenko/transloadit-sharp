using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transloadit.Models.Templates
{
    public class TemplateRequest : BaseParams
    {
        public string Name { get; set; }

        public int RequireSignatureAuth { get; set; }

        public object Template { get; set; }
    }
}
