using System;
using Dovs.WordPressAutoKit.Interfaces;

namespace Dovs.WordPressAutoKit.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfigurationService _configurationService;

        public AuthenticationService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

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