namespace Dovs.WordPressAutoKit.Interfaces
{
    /// <summary>
    /// Interface for password service.
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Prompts the user for a password with the specified prompt message.
        /// </summary>
        /// <param name="prompt">The prompt message to display to the user.</param>
        /// <returns>The password entered by the user.</returns>
        string PromptForPassword(string prompt);
    }
}
