using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Bll.Exeptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode Code { get; set; }
        public ApiException()
        {
        }

        public ApiException(HttpStatusCode code, string? message) : base(message)
        {
            Code = code;
        }

        public ApiException(HttpStatusCode code, string? message, Exception? innerException) : base(message, innerException)
        {
            Code = code;
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
