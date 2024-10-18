using Dovs.WordPressAutoKit.Interfaces;
using Dovs.WordPressAutoKit.Services;
using Dovs.FileSystemInteractor.Interfaces;
using Dovs.FileSystemInteractor.Services;
using Dovs.CommonComponents;
using OpenQA.Selenium;
using Dovs.WordPressAutoKit;

class Program
{
    static void Main(string[] args)
    {
        InitializeServices();

        if (args.Length > 0 && args[0].Equals("add-user", StringComparison.OrdinalIgnoreCase))
        {
            if (args.Length == 9)
            {
                string filePath = GetArgumentValue(args, "--file-path", "-fp");
                string adminUsername = GetArgumentValue(args, "--admin-username", "-aun");
                string adminPassword = GetArgumentValue(args, "--admin-password", "-apass");
                string registrationPassword = GetArgumentValue(args, "--registration-password", "-rpass");

                if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(adminUsername) && !string.IsNullOrEmpty(adminPassword) && !string.IsNullOrEmpty(registrationPassword))
                {
                    AddUsers(filePath, adminUsername, adminPassword, registrationPassword);
                }
                else
                {
                    Console.WriteLine("Invalid arguments. Usage: WordPressAutoKit.exe add-user --file-path <filePath> --admin-username <adminUsername> --admin-password <adminPassword> --registration-password <registrationPassword>");
                }
            }
            else
            {
                Console.WriteLine("Invalid arguments. Usage: WordPressAutoKit.exe add-user --file-path <filePath> --admin-username <adminUsername> --admin-password <adminPassword> --registration-password <registrationPassword>");
            }
        }
        else
        {
            DisplayMenu();
        }
    }

    private static string GetArgumentValue(string[] args, string longForm, string shortForm)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].Equals(longForm, StringComparison.OrdinalIgnoreCase) || args[i].Equals(shortForm, StringComparison.OrdinalIgnoreCase))
            {
                if (i + 1 < args.Length)
                {
                    return args[i + 1];
                }
            }
        }
        return string.Empty;
    }

    private static void DisplayMenu()
    {
        Console.WriteLine(CoreUtilities.CreateWelcomeMessage("WordPress Automation Toolkit"));
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Add Users");
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

    private static int GetOptionFromUser()
    {
        Console.Write("Enter the option number: ");
        string input = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(input, out int option))
        {
            return option;
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
            return GetOptionFromUser();
        }
    }

    private static void AddUsers()
    {
        string filePath = GetFilePathWithExtension();
        if (string.IsNullOrEmpty(filePath)) return;

        string adminUsername = GetAdminUsername();
        if (string.IsNullOrEmpty(adminUsername)) return;

        string adminPassword = GetAdminPassword();
        if (string.IsNullOrEmpty(adminPassword)) return;

        string registrationPassword = GetRegistrationPassword();
        if (string.IsNullOrEmpty(registrationPassword)) return;

        AddUsers(filePath, adminUsername, adminPassword, registrationPassword);
    }

    private static void AddUsers(string filePath, string adminUsername, string adminPassword, string registrationPassword)
    {
        using (var driver = webDriverService?.CreateWebDriver())
        {
            if (driver == null)
            {
                Console.WriteLine("Failed to create WebDriver. Exiting the program.");
                return;
            }

            try
            {
                AdminLogin(driver, adminUsername, adminPassword);
                AddUsers(driver, filePath, registrationPassword);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                webDriverService?.QuitWebDriver(driver);
            }
        }
    }

    private static void AdminLogin(IWebDriver driver, string adminUsername, string adminPassword)
    {
        string loginUrl = configurationService?.GetConfigValue("PlatformSettings:LoginUrl") ?? string.Empty;
        adminLoginService?.Login(driver, loginUrl, adminUsername, adminPassword);
    }

    private static void AddUsers(IWebDriver driver, string filePath, string registrationPassword)
    {
        string addNewUserUrl = configurationService?.GetConfigValue("PlatformSettings:AddNewUserUrl") ?? string.Empty;
        var columnNames = configurationService?.GetColumnNames("DataColumns:ColumnNames") ?? new List<string>();
        var dataList = excelReaderService?.ReadData(filePath, columnNames) ?? new List<Dictionary<string, string>>();
        var role = configurationService?.GetConfigValue("PlatformSettings:PostRegisterRole") ?? string.Empty;

        foreach (var data in dataList)
        {
            var userData = new UserData(data["Username"], data["Email"], data["Membership"]);
            userManagementService?.AddNewUser(driver, userData, registrationPassword, addNewUserUrl);
            roleService?.UpdateRole(driver, role);
            membershipService?.AddMembership(driver, data["Membership"]);
        }
    }

    private static string GetFilePathWithExtension()
    {
        const int LEVELSTRAVERSE = 2;

        string fileExtension = GetFileExtension();
        if (string.IsNullOrEmpty(fileExtension))
        {
            Console.WriteLine("Invalid file extension. Exiting the program.");
            return string.Empty;
        }

        string filePath = fileInteractionService?.SelectFilePath(filePathService, LEVELSTRAVERSE, fileExtension) ?? string.Empty;
        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("Invalid file path. Exiting the program.");
            return string.Empty;
        }

        return filePath;
    }

    private static string GetFileExtension()
    {
        Console.WriteLine("Please select the file type or specify the extension:\n1. Excel (.xlsx)\n2. Markdown (.md)\n3. CSV (.csv)\nPress Enter to select Excel (.xlsx) by default.");
        string input = Console.ReadLine() ?? string.Empty;

        return input switch
        {
            "1" => ".xlsx",
            "2" => ".md",
            "3" => ".csv",
            "" => ".xlsx", // Default to Excel if Enter is pressed
            _ => input // Assume the user specified the extension directly
        };
    }

    private static string GetAdminUsername()
    {
        string adminUserNames = configurationService?.GetConfigValue("PlatformSettings:AdminUserNames") ?? string.Empty;
        return authenticationService?.GetAdminUsername(adminUserNames) ?? string.Empty;
    }

    private static string GetAdminPassword()
    {
        string adminPassword = passwordService?.PromptForPassword("Enter your admin password:") ?? string.Empty;
        if (string.IsNullOrEmpty(adminPassword))
        {
            Console.WriteLine("Invalid password. Exiting the program.");
        }
        return adminPassword;
    }

    private static string GetRegistrationPassword()
    {
        string registrationPassword = passwordService?.PromptForPassword("Enter the password to use for registration:") ?? string.Empty;
        if (string.IsNullOrEmpty(registrationPassword))
        {
            Console.WriteLine("Invalid registration password. Exiting the program.");
        }
        return registrationPassword;
    }

    private static void RemoveUsers()
    {
        Console.WriteLine("Remove Users method is not implemented yet.");
    }

    private static void UpdateUsers()
    {
        Console.WriteLine("Update Users method is not implemented yet.");
    }

    private static void InitializeServices()
    {
        configurationService = new ConfigurationService();
        filePathService = new FilePathService();
        authenticationService = new AuthenticationService();
        passwordService = new PasswordService();
        webDriverService = new WebDriverService();
        excelReaderService = new ExcelReaderService();
        userManagementService = new UserManagementService();
        roleService = new RoleService();
        membershipService = new MembershipService();
        adminLoginService = new AdminLoginService();
        fileInteractionService = new FileInteractionService();
    }

    private static IConfigurationService? configurationService;
    private static IFilePathService? filePathService;
    private static IAuthenticationService? authenticationService;
    private static IPasswordService? passwordService;
    private static IWebDriverService? webDriverService;
    private static IExcelReaderService? excelReaderService;
    private static IUserManagementService? userManagementService;
    private static IRoleService? roleService;
    private static IMembershipService? membershipService;
    private static IAdminLoginService? adminLoginService;
    private static IFileInteractionService? fileInteractionService;
}