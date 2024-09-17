using Dovs.WordPressAutoKit.Interfaces;

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
        /// <param name="adminUserNames">Comma-separated admin usernames.</param>
        /// <returns>The admin username.</returns>  
        public string GetAdminUsername(string adminUserNames)
        {
            var usernames = adminUserNames.Split(',');

            if (usernames.Length < 2)
            {
                throw new ArgumentException("Please provide at least two admin usernames separated by a comma.");
            }

            Console.WriteLine("Choose a username to login as admin:");
            for (int i = 0; i < usernames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {usernames[i].Trim()}");
            }
            Console.WriteLine($"{usernames.Length + 1}. Other");

            string choice = Console.ReadLine();
            int choiceNumber;
            if (int.TryParse(choice, out choiceNumber))
            {
                if (choiceNumber >= 1 && choiceNumber <= usernames.Length)
                {
                    return usernames[choiceNumber - 1].Trim();
                }
                else if (choiceNumber == usernames.Length + 1)
                {
                    Console.WriteLine("Enter your username:");
                    return Console.ReadLine();
                }
            }

            return null;
        }
    }
}