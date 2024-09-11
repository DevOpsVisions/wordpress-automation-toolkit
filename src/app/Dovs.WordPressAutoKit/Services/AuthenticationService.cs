
using System;
using Dovs.WordPressAutoKit.Interfaces;
using Dovs.FileSystemInteractor.Interfaces;
using Dovs.FileSystemInteractor.Services;

namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>  
    /// Service for handling authentication operations.  
    /// </summary>  
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>  
        /// Gets the admin username for login.  
        /// </summary>  
        /// <returns>The admin username.</returns>  
        public string GetAdminUsername(string Admin1UserNameOrEmail, string Admin2UserNameOrEmail)
        {
            Console.WriteLine($"Choose a username to login as admin: \n1. {Admin1UserNameOrEmail}\n2. {Admin2UserNameOrEmail}\n3. Other");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return Admin1UserNameOrEmail;
                case "2":
                    return Admin2UserNameOrEmail;
                case "3":
                    Console.WriteLine("Enter your username:");
                    return Console.ReadLine();
                default:
                    return null;
            }
        }
    }
}