using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transloadit.Models
{
    public class ErrorResponse
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public int HttpCode { get; set; }
    }

    public class ResponseBase
    {
        public string Ok { get; set; }

        public string Message { get; set; }
    }
}
