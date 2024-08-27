using Dovs.WordPressAutoKit.Interfaces;
using Dovs.WordPressAutoKit.Common;
using System;
using System.IO;

namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>
    /// Service for handling file path operations.
    /// </summary>
    public class FilePathService : IFilePathService
    {
        /// <summary>
        /// Gets the base path by traversing upwards the specified number of levels.
        /// </summary>
        /// <param name="levelsToTraverse">The number of levels to traverse upwards.</param>
        /// <returns>The base path after traversing the specified number of levels.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of levels to traverse is less than one.</exception>
        public string GetBasePath(int levelsToTraverse)
        {
            if (levelsToTraverse < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(levelsToTraverse), "Number of levels to traverse must be greater than zero.");
            }

            string currentDir = Directory.GetCurrentDirectory();

            for (int i = 0; i < levelsToTraverse; i++)
            {
                DirectoryInfo parentDir = Directory.GetParent(currentDir);

                if (parentDir == null)
                {
                    Console.WriteLine("Reached the root directory.");
                    break;
                }

                currentDir = parentDir.FullName;
            }

            return currentDir;
        }

        /// <summary>
        /// Gets the file path based on user input or the default file path.
        /// </summary>
        /// <param name="defaultFilePath">The default file path.</param>
        /// <returns>The file path chosen by the user or the default file path.</returns>
        public string GetFilePath(string defaultFilePath)
        {
            PrintFilePathOptions(defaultFilePath);
            EUserChoice choice = GetValidUserChoice();
            return HandleUserChoice(choice, defaultFilePath);
        }

        /// <summary>
        /// Prints the file path options based on whether the default file exists.
        /// </summary>
        /// <param name="defaultFilePath">The default file path.</param>
        private void PrintFilePathOptions(string defaultFilePath)
        {
            if (File.Exists(defaultFilePath))
            {
                Console.WriteLine("File Found: Press \n1 to use the default path \n2 to enter your own path:");
            }
            else
            {
                Console.WriteLine($"File not found: Ensure it's copied to {defaultFilePath}. Press \n1 to use the default path \n2 to enter your own path:");
            }
        }

        /// <summary>
        /// Continuously prompts the user until they provide a valid choice.
        /// </summary>
        /// <returns>The valid user choice.</returns>
        private EUserChoice GetValidUserChoice()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (Enum.TryParse(input, out EUserChoice choice) && Enum.IsDefined(typeof(EUserChoice), choice))
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 for default path or 2 to enter a custom path.");
                }
            }
        }

        /// <summary>
        /// Handles the user's choice and returns the corresponding file path.
        /// </summary>
        /// <param name="choice">The user's choice.</param>
        /// <param name="defaultFilePath">The default file path.</param>
        /// <returns>The file path based on the user's choice.</returns>
        private string HandleUserChoice(EUserChoice choice, string defaultFilePath)
        {
            return choice switch
            {
                EUserChoice.DefaultPath => defaultFilePath,
                EUserChoice.CustomPath => GetCustomPath(),
                _ => throw new InvalidOperationException("Unexpected error. Returning null.")
            };
        }

        /// <summary>
        /// Prompts the user to enter a custom path.
        /// </summary>
        /// <returns>The custom path entered by the user.</returns>
        private string GetCustomPath()
        {
            Console.WriteLine("Please enter your own path:");
            return Console.ReadLine();
        }
    }
}