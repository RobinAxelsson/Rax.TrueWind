using System.Diagnostics.CodeAnalysis;

namespace TrueWind.API.Internals.Core.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public sealed class InvalidUnitValueException : TrueWindBusinessBaseException
    {
        public override string Reason => "Invalid value for unit";

        public InvalidUnitValueException() { }
        public InvalidUnitValueException(string message) : base(message) { }
        public InvalidUnitValueException(string message, Exception inner) : base(message, inner) { }
        private InvalidUnitValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
