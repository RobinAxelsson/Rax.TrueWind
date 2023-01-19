using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using TrueWind.Core.Exceptions;

namespace TrueWind.API.Internals.Services.Smhi.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    internal class SmhiServiceNotFoundException : TrueWindTechnicalBaseException
    {
        public override string Reason => "Smhi Service Reported - Not Found";
        public SmhiServiceNotFoundException()
        {
        }

        public SmhiServiceNotFoundException(string? message) : base(message)
        {
        }

        public SmhiServiceNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SmhiServiceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}