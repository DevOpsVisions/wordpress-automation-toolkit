namespace Dovs.WordPressAutoKit.Interfaces
{
    /// <summary>
    /// Interface for authentication service.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Gets the admin username for login.
        /// </summary>
        /// <returns>The admin username.</returns>
        string GetAdminUsername(string Admin1UserNameOrEmail, string Admin2UserNameOrEmail);
    }
}
