using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using TrueWind.Core.Exceptions;

namespace TrueWind.ViVa.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    internal class ViVaServiceNotFoundException : TrueWindTechnicalBaseException
    {
        public override string Reason => "ViVa Service Reported - Not Found";
        public ViVaServiceNotFoundException()
        {
        }

        public ViVaServiceNotFoundException(string? message) : base(message)
        {
        }

        public ViVaServiceNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ViVaServiceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}