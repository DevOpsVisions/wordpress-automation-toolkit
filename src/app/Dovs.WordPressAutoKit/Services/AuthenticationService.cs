
using System;
using Dovs.WordPressAutoKit.Interfaces;

namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>  
    /// Service for handling authentication operations.  
    /// </summary>  
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfigurationService _configurationService;

        /// <summary>  
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.  
        /// </summary>  
        /// <param name="configurationService">The configuration service.</param>  
        public AuthenticationService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        /// <summary>  
        /// Gets the admin username for login.  
        /// </summary>  
        /// <returns>The admin username.</returns>  
        public string GetAdminUsername()
        {
            string admin1 = _configurationService.GetConfigValue("Admin1");
            string admin2 = _configurationService.GetConfigValue("Admin2");

            Console.WriteLine($"Choose a username to login as admin: \n1. {admin1}\n2. {admin2}\n3. Other");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return admin1;
                case "2":
                    return admin2;
                case "3":
                    Console.WriteLine("Enter your username:");
                    return Console.ReadLine();
                default:
                    return null;
            }
        }
    }
}