using TrueWind.Core.Exceptions;

namespace TrueWind.Smhi.ConfigurationProviders
{
    public abstract class ConfigurationProviderBase
    {
        public string GetUrlSmhiGkss()
        {
            var smhiUrl = RetrieveConfigurationSettingValueThrowIfMissing("UrlSmhiGkss");
            if (smhiUrl.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                throw new ConfigurationSettingMissingException($"Url {smhiUrl} needs to end with a '/'");
            }
            return smhiUrl;
        }

        private string RetrieveConfigurationSettingValueThrowIfMissing(string key)
        {
            var valueAsRetrieved = RetrieveConfigurationSettingValue(key);
            if (valueAsRetrieved == null)
            {
                throw new ConfigurationSettingMissingException(KeyMissingInConfigSourceMessage(key));
            }
            else if (valueAsRetrieved.Length == 0)
            {
                throw new ConfigurationSettingValueEmptyException($"The Configuration Setting with Key: {key}, Exists but its value is Empty");
            }
            else if (IsWhiteSpaces(valueAsRetrieved))
            {
                throw new ConfigurationSettingValueEmptyException($"The Configuration Setting with Key: {key}, Exists but its value is White spaces.");
            }

            return valueAsRetrieved;
        }

        private static bool IsWhiteSpaces(string valueAsRetrieved)
        {
            foreach (var chr in valueAsRetrieved)
            {
                if (!char.IsWhiteSpace(chr))
                {
                    return false;
                }
            }

            return true;
        }

        protected abstract string KeyMissingInConfigSourceMessage(string key);
        protected abstract string RetrieveConfigurationSettingValue(string key);
    }
}
