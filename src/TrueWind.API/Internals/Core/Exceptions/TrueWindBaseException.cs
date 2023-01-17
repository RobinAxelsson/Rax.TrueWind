using System.Diagnostics.CodeAnalysis;

namespace TrueWind.API.Internals.Core.Exceptions;

[Serializable]
[ExcludeFromCodeCoverage]
public abstract class TrueWindBaseException : Exception
{
    public abstract string Reason { get; }
    protected TrueWindBaseException() { }
    protected TrueWindBaseException(string message) : base(message) { }
    protected TrueWindBaseException(string message, Exception inner) : base(message, inner) { }
    protected TrueWindBaseException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}