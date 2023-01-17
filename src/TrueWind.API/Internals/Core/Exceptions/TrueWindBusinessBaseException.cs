using System.Diagnostics.CodeAnalysis;

namespace TrueWind.API.Internals.Core.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public abstract class TrueWindBusinessBaseException : TrueWindBaseException
    {
        protected TrueWindBusinessBaseException() { }
        protected TrueWindBusinessBaseException(string message) : base(message) { }
        protected TrueWindBusinessBaseException(string message, Exception inner) : base(message, inner) { }
        protected TrueWindBusinessBaseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
