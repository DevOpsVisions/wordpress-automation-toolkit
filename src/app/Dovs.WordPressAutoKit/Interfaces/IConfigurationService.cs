namespace Dovs.WordPressAutoKit.Interfaces
{
    /// <summary>
    /// Interface for configuration service.
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the configuration value for the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration value.</param>
        /// <returns>The configuration value associated with the specified key.</returns>
        string GetConfigValue(string key);
    }
}
