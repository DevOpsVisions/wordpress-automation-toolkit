using Dovs.WordPressAutoKit.Interfaces;
using System;
using System.IO;

namespace Dovs.WordPressAutoKit.Services
{
    public class FilePathService : IFilePathService
    {
        public string GetFilePath(string defaultFilePath)
        {
            if (File.Exists(defaultFilePath))
            {
                Console.WriteLine("File Found: Press \n1 to use the default path \n2 to enter your own path:");
            }
            else
            {
                Console.WriteLine("File not found: Press \n1 to use the default path \n2 to enter your own path:");
            }

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                return defaultFilePath;
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter your own file path:");
                return Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting the program.");
                Environment.Exit(0);
                return null;
            }
        }
    }
}
