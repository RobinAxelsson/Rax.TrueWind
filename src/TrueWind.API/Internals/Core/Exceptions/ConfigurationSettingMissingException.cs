using System.Diagnostics.CodeAnalysis;

namespace TrueWind.API.Internals.Core.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public sealed class ConfigurationSettingMissingException : TrueWindTechnicalBaseException
    {
        public override string Reason => "Configuration Setting Missing";
        public ConfigurationSettingMissingException() { }
        public ConfigurationSettingMissingException(string message) : base(message) { }
        public ConfigurationSettingMissingException(string message, Exception inner) : base(message, inner) { }
        private ConfigurationSettingMissingException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
