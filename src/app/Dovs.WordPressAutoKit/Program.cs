using Dovs.WordPressAutoKit.Interfaces;
using Dovs.WordPressAutoKit.Services;
using Dovs.FileSystemInteractor.Interfaces;
using Dovs.FileSystemInteractor.Services;
using Dovs.WordPressAutoKit;

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

        if (args.Length == 8)
        {
            var arguments = ParseArguments(args);
            if (arguments.HasValue)
            {
                var (filePath, adminUsername, adminPassword, registrationPassword) = arguments.Value;
                AddUsers(filePath, adminUsername, adminPassword, registrationPassword);
            }
            else
            {
                Console.WriteLine("Invalid arguments. Please provide all required parameters.");
            }
        }
        else
        {
            DisplayMenu();
        }
    }

    static void InitializeServices()
    {
        configurationService = new ConfigurationService();
        filePathService = new FilePathService();
        authenticationService = new AuthenticationService();
        passwordService = new PasswordService();
        webDriverService = new WebDriverService();
        excelReaderService = new ExcelReaderService();
        userManagementService = new UserManagementService(new MembershipService());
        adminLoginService = new AdminLoginService();
        fileInteractionService = new FileInteractionService();
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Welcome to WordPress Automation Toolkit!");
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

    static void AddUsers()
    {
        const int LEVELSTRAVERSE = 2;

        string fileExtension = GetFileExtension();

        if (string.IsNullOrEmpty(fileExtension))
        {
            Console.WriteLine("Invalid file extension. Exiting the program.");
            return;
        }

        string filePath = fileInteractionService.SelectFilePath(filePathService, LEVELSTRAVERSE, fileExtension);

        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("Invalid file path. Exiting the program.");
            return;
        }

        string adminUsername = GetAdminUsername();
        if (string.IsNullOrEmpty(adminUsername))
        {
            Console.WriteLine("Invalid choice. Exiting the program.");
            return;
        }

        Console.WriteLine($"Logged in as: {adminUsername}");

        string adminPassword = passwordService.PromptForPassword("Enter your admin password:");
        string registrationPassword = passwordService.PromptForPassword("Enter the password to use for registration:");

        AddUsers(filePath, adminUsername, adminPassword, registrationPassword);
    }

    private static void AddUsers(string filePath, string adminUsername, string adminPassword, string registrationPassword)
    {
        if (string.IsNullOrEmpty(adminUsername))
        {
            Console.WriteLine("Invalid admin username. Exiting the program.");
            return;
        }

        string loginUrl = configurationService.GetConfigValue("LoginUrl");
        string postRegisterRole = configurationService.GetConfigValue("PostRegisterRole");
        string addNewUserUrl = configurationService.GetConfigValue("AddNewUserUrl");
        string preRegisterRole = configurationService.GetConfigValue("PreRegisterRole");

        using (var driver = webDriverService.CreateWebDriver())
        {
            try
            {
                adminLoginService.Login(driver, loginUrl, adminUsername, adminPassword);

                var columnNames = configurationService.GetColumnNames("ColumnNames");
                var dataList = excelReaderService.ReadData(filePath, columnNames);

                foreach (var data in dataList)
                {
                    var userData = new UserData(data["Username"], data["Email"], data["Membership"]);
                    userManagementService.AddNewUser(driver, userData, registrationPassword, postRegisterRole, addNewUserUrl, preRegisterRole);
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
        string Admin1UserNameOrEmail = configurationService.GetConfigValue("Admin1UserNameOrEmail");
        string Admin2UserNameOrEmail = configurationService.GetConfigValue("Admin2UserNameOrEmail");

        return authenticationService.GetAdminUsername(Admin1UserNameOrEmail, Admin2UserNameOrEmail);
    }

    private static (string FilePath, string AdminUsername, string AdminPassword, string RegistrationPassword)? ParseArguments(string[] args)
    {
        var arguments = args.Select((value, index) => new { value, index })
                            .GroupBy(x => x.index / 2)
                            .ToDictionary(g => g.First().value, g => g.Last().value);

        if (arguments.TryGetValue("-filePath", out string filePath) &&
            arguments.TryGetValue("-adminUsername", out string adminUsername) &&
            arguments.TryGetValue("-adminPassword", out string adminPassword) &&
            arguments.TryGetValue("-registrationPassword", out string registrationPassword))
        {
            return (filePath, adminUsername, adminPassword, registrationPassword);
        }

        return null;
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
