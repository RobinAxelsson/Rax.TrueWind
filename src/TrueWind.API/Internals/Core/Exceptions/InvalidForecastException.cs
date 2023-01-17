using System.Diagnostics.CodeAnalysis;

namespace TrueWind.API.Internals.Core.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public sealed class InvalidForecastException : TrueWindBusinessBaseException
    {
        public override string Reason => "Invalid Forecast";

        public InvalidForecastException() { }
        public InvalidForecastException(string message) : base(message) { }
        public InvalidForecastException(string message, Exception inner) : base(message, inner) { }
        private InvalidForecastException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
