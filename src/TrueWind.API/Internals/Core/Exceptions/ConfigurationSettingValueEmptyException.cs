using System.Diagnostics.CodeAnalysis;

namespace TrueWind.API.Internals.Core.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public sealed class ConfigurationSettingValueEmptyException : TrueWindTechnicalBaseException
    {
        public override string Reason => "Configuration Setting Value Empty";
        public ConfigurationSettingValueEmptyException() { }
        public ConfigurationSettingValueEmptyException(string message) : base(message) { }
        public ConfigurationSettingValueEmptyException(string message, Exception inner) : base(message, inner) { }
        private ConfigurationSettingValueEmptyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
