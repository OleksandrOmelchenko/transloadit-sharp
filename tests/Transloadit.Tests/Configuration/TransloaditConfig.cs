using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transloadit.Tests.Configuration
{
    internal class TransloaditConfig
    {
        public const string Section = "Transloadit";

        public string AuthKey { get; set; }
        public string AuthSecret { get; set; }
    }
}
