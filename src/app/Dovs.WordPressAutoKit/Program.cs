using System;
using System.IO;
using Dovs.WordPressAutoKit.Common;
using Dovs.WordPressAutoKit.Interfaces;
using Dovs.WordPressAutoKit.Services;
using Dovs.FileSystemInteractor.Interfaces;
using Dovs.FileSystemInteractor.Services;

class Program
{
    private static IConfigurationService? configurationService;
    private static IFilePathService? filePathService;
    private static IAuthenticationService? authenticationService;
    private static IPasswordService? passwordService;
    private static IWebDriverService? webDriverService;
    private static IExcelReaderService? excelReaderService;
    private static IUserManagementService? userManagementService;
    private static IAdminLoginService? adminLoginService;
    private static IFileInteractionService? fileInteractionService;

    static void Main(string[] args)
    {
        InitializeServices();
        DisplayMenu();
    }

    static void InitializeServices()
    {
        configurationService = new ConfigurationService();
        filePathService = new FilePathService();
        authenticationService = new AuthenticationService(configurationService);
        passwordService = new PasswordService();
        webDriverService = new WebDriverService();
        excelReaderService = new ExcelReaderService(configurationService);
        userManagementService = new UserManagementService(new MembershipService(), configurationService);
        adminLoginService = new AdminLoginService(configurationService);
        fileInteractionService = new FileInteractionService();
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Welcome to Q2A Automation Toolkit!");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Register Users");
        Console.WriteLine("2. Remove Users");
        Console.WriteLine("3. Update Users");
        Console.WriteLine("4. Exit");

        int option = GetOptionFromUser();

        switch (option)
        {
            case 1:
                AddUsers();
                DisplayMenu();
                break;
            case 2:
                RemoveUsers();
                DisplayMenu();
                break;
            case 3:
                UpdateUsers();
                DisplayMenu();
                break;
            case 4:
                Console.WriteLine("Exiting the App...");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                DisplayMenu();
                break;
        }
    }

    static int GetOptionFromUser()
    {
        Console.Write("Enter the option number: ");
        string input = Console.ReadLine() ?? string.Empty;
        int option;
        if (int.TryParse(input, out option))
        {
            return option;
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
            return GetOptionFromUser();
        }
    }

    static void AddUsers()
    {
        const int LEVELSTRAVERSE = 2;

        string filePath = fileInteractionService.SelectFilePath(filePathService, LEVELSTRAVERSE);

        string adminUsername = authenticationService.GetAdminUsername();
        if (string.IsNullOrEmpty(adminUsername))
        {
            Console.WriteLine("Invalid choice. Exiting the program.");
            return;
        }

        Console.WriteLine($"Logged in as: {adminUsername}");

        string adminPassword = passwordService.PromptForPassword("Enter your admin password:");
        string registrationPassword = passwordService.PromptForPassword("Enter the password to use for registration:");

        using (var driver = webDriverService.CreateWebDriver())
        {
            try
            {
                adminLoginService.Login(driver, adminUsername, adminPassword);
                var userDataList = excelReaderService.ReadUserData(filePath);

                foreach (var userData in userDataList)
                {
                    userManagementService.AddNewUser(driver, userData, registrationPassword);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                webDriverService.QuitWebDriver(driver);
            }
        }
    }

    static void RemoveUsers()
    {
        Console.WriteLine("Remove Users method is not implemented yet.");
    }

    static void UpdateUsers()
    {
        Console.WriteLine("Update Users method is not implemented yet.");
    }
}
