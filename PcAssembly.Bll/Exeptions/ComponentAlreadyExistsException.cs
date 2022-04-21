using System.Net;
using System.Runtime.Serialization;

namespace PcAssembly.Bll.Exeptions
{
    [Serializable]
    internal class ComponentAlreadyExistsException : ApiException
    {
        public ComponentAlreadyExistsException()
        {
        }

        public ComponentAlreadyExistsException(string? message) : base(HttpStatusCode.BadRequest, message)
        {
        }

        public ComponentAlreadyExistsException(string? message, Exception? innerException) : base(HttpStatusCode.BadRequest, message, innerException)
        {
        }

        protected ComponentAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}