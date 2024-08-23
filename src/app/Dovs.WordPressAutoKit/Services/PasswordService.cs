using Dovs.WordPressAutoKit.Interfaces;
using System;


namespace Dovs.WordPressAutoKit.Services
{
    public class PasswordService : IPasswordService
    {
        public string PromptForPassword(string prompt)
        {
            Console.WriteLine(prompt);
            return ReadPassword();
        }

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
