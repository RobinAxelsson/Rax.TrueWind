using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using TrueWind.Core.Exceptions;

namespace TrueWind.ViVa.Exceptions;

[Serializable]
[ExcludeFromCodeCoverage]
internal class ViVaResourceNotParsedException : TrueWindTechnicalBaseException
{
    public override string Reason => "ViVa Service Reported - Not Found";
    public ViVaResourceNotParsedException()
    {
    }

    public ViVaResourceNotParsedException(string? message) : base(message)
    {
    }

    public ViVaResourceNotParsedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ViVaResourceNotParsedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}