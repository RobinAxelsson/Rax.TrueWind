using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace TrueWind.API.Internals.ConfigurationProviders
{
    internal sealed class ConfigurationProvider : ConfigurationProviderBase
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigurationProvider()
        {
            var configurationBuilder = new ConfigurationBuilder();
            _ = configurationBuilder.AddJsonFile("appsettings.json");

            LoadEnvironmentSpecificAppSettings(configurationBuilder);

            _configurationRoot = configurationBuilder.Build();
        }

        private static void LoadEnvironmentSpecificAppSettings(ConfigurationBuilder configurationBuilder)
        {
            var aspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var environmentBasedSettingsFile = $"appsettings.{aspNetCoreEnvironment}.json";
            if (File.Exists(environmentBasedSettingsFile))
            {
                configurationBuilder.AddJsonFile(environmentBasedSettingsFile);
            }
        }

        [ExcludeFromCodeCoverage]
        internal ConfigurationProvider(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        protected override string RetrieveConfigurationSettingValue(string key)
        {
            return _configurationRoot["AppSettings:" + key];
        }

        protected override string KeyMissingInConfigSourceMessage(string key)
        {
            return $"{key} missing in appsettings.json or appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json add with 'AppSettings' as parent for example: \n" +
                $"\"AppSettings\":{{ \"{key}\": \"value\" }}";
        }
    }
}
