using Dovs.WordPressAutoKit.Interfaces;


namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>
    /// Service for handling password input operations.
    /// </summary>
    public class PasswordService : IPasswordService
    {
        /// <summary>
        /// Prompts the user for a password with the specified prompt message.
        /// </summary>
        /// <param name="prompt">The prompt message to display to the user.</param>
        /// <returns>The password entered by the user.</returns>
        public string PromptForPassword(string prompt)
        {
            Console.WriteLine(prompt);
            return ReadPassword();
        }

        /// <summary>
        /// Reads the password input from the user, masking the input with asterisks.
        /// </summary>
        /// <returns>The password entered by the user.</returns>
        private string ReadPassword()
        {
            var password = new System.Text.StringBuilder();
            ConsoleKeyInfo key;

            while ((key = Console.ReadKey(intercept: true)).Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Length--;
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            }

            Console.WriteLine();
            return password.ToString();
        }
    }
}