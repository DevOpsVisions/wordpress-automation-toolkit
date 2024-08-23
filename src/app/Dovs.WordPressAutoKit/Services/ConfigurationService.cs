using Dovs.WordPressAutoKit.Interfaces;
using System.Configuration;

namespace Dovs.WordPressAutoKit.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
