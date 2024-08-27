
using Dovs.WordPressAutoKit.Interfaces;
using System.Configuration;

namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>  
    /// Service for handling configuration operations.  
    /// </summary>  
    public class ConfigurationService : IConfigurationService
    {
        /// <summary>  
        /// Gets the configuration value for the specified key.  
        /// </summary>  
        /// <param name="key">The key of the configuration value.</param>  
        /// <returns>The configuration value associated with the specified key.</returns>  
        public string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}