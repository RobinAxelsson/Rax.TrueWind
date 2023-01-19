using System.Diagnostics.CodeAnalysis;

namespace TrueWind.Core.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public abstract class TrueWindTechnicalBaseException : TrueWindBaseException
    {
        protected TrueWindTechnicalBaseException() { }
        protected TrueWindTechnicalBaseException(string message) : base(message) { }
        protected TrueWindTechnicalBaseException(string message, Exception inner) : base(message, inner) { }
        protected TrueWindTechnicalBaseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
