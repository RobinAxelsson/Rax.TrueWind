using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using TrueWind.Core.Exceptions;

namespace TrueWind.API.Internals.Services.Smhi.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    internal class SmhiResourceNotParsedException : TrueWindTechnicalBaseException
    {
        public override string Reason => "Smhi Service Reported - Not Found";
        public SmhiResourceNotParsedException()
        {
        }

        public SmhiResourceNotParsedException(string? message) : base(message)
        {
        }

        public SmhiResourceNotParsedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SmhiResourceNotParsedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}