using Dovs.WordPressAutoKit.Interfaces;
using Dovs.WordPressAutoKit.Services;
using Dovs.FileSystemInteractor.Interfaces;
using Dovs.FileSystemInteractor.Services;
using Dovs.CommonComponents;
using OpenQA.Selenium;
using Dovs.WordPressAutoKit;
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            InitializeServices();
            ConfigureLogging();

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
                        Log.Error("Invalid arguments. Usage: WordPressAutoKit.exe add-user --file-path <filePath> --admin-username <adminUsername> --admin-password <adminPassword> --registration-password <registrationPassword>");
                    }
                }
                else
                {
                    Log.Error("Invalid arguments. Usage: WordPressAutoKit.exe add-user --file-path <filePath> --admin-username <adminUsername> --admin-password <adminPassword> --registration-password <registrationPassword>");
                }
            }
            else
            {
                DisplayMenu();
            }
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "An unhandled exception occurred.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static void ConfigureLogging()
    {
        string logFilePath = $"logs/log_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        var minimumLevel = configurationService?.GetConfigValue("Serilog:MinimumLevel") ?? "Debug";

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(Enum.Parse<Serilog.Events.LogEventLevel>(minimumLevel, true))
            .WriteTo.Console()
            .WriteTo.File(logFilePath)
            .CreateLogger();
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
                Log.Information("Exiting the App...");
                break;
            default:
                Log.Warning("Invalid option. Please try again.");
                DisplayMenu();
                break;
        }
    }

    private static int GetOptionFromUser()
    {
        Console.WriteLine("Enter the option number: ");
        string input = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(input, out int option))
        {
            string optionText = option switch
            {
                1 => "Add Users",
                2 => "Remove Users",
                3 => "Update Users",
                4 => "Exit",
                _ => "Invalid option"
            };
            Log.Information($"User selected option {option}: {optionText}");
            return option;
        }
        else
        {
            Log.Warning("Invalid option. Please try again.");
            return GetOptionFromUser();
        }
    }

    private static void AddUsers()
    {
        string filePath = fileInteractionService != null && filePathService != null
            ? fileInteractionService.GetFilePathWithExtension(filePathService)
            : string.Empty;
        if (string.IsNullOrEmpty(filePath))
        {
            Log.Error("File path is empty. Exiting Add Users process.");
            return;
        }
        Log.Information($"File path selected: {filePath}");

        string adminUsername = GetAdminUsername();
        if (string.IsNullOrEmpty(adminUsername))
        {
            Log.Error("Admin username is empty. Exiting Add Users process.");
            return;
        }

        string adminPassword = GetAdminPassword();
        if (string.IsNullOrEmpty(adminPassword))
        {
            Log.Error("Admin password is empty. Exiting Add Users process.");
            return;
        }

        string registrationPassword = GetRegistrationPassword();
        if (string.IsNullOrEmpty(registrationPassword))
        {
            Log.Error("Registration password is empty. Exiting Add Users process.");
            return;
        }

        AddUsers(filePath, adminUsername, adminPassword, registrationPassword);
    }

    private static void AddUsers(string filePath, string adminUsername, string adminPassword, string registrationPassword)
    {
        using (var driver = webDriverService?.CreateWebDriver())
        {
            if (driver == null)
            {
                Log.Error("Failed to create WebDriver. Exiting the program.");
                return;
            }

            try
            {
                AdminLogin(driver, adminUsername, adminPassword);
                AddUsers(driver, filePath, registrationPassword);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while adding users.");
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
        Log.Information("Starting to add users from Excel file");

        string addNewUserUrl = configurationService?.GetConfigValue("PlatformSettings:AddNewUserUrl") ?? string.Empty;
        var columnNames = configurationService?.GetColumnNames("DataColumns:ColumnNames") ?? new List<string>();
        var dataList = excelReaderService?.ReadData(filePath, columnNames) ?? new List<Dictionary<string, string>>();
        var role = configurationService?.GetConfigValue("PlatformSettings:PostRegisterRole") ?? string.Empty;

        Log.Information($"Read {dataList.Count} entries from Excel file");

        foreach (var data in dataList)
        {
            var userData = new UserData(data["Username"], data["Email"], data["Membership"]);
            Log.Information($"Adding user: {userData.UserName}, Email: {userData.Email}, Membership: {userData.Membership}");

            userManagementService?.AddNewUser(driver, userData, registrationPassword, addNewUserUrl);
            Log.Information($"User {userData.UserName} added successfully");

            roleService?.UpdateRole(driver, role);
            Log.Information($"Role updated to {role} for user {userData.UserName}");

            membershipService?.AddMembership(driver, data["Membership"]);
            Log.Information($"Membership {data["Membership"]} added for user {userData.UserName}");
        }

        Log.Information("Completed adding users from Excel file");
    }

    private static string GetAdminUsername()
    {
        string adminUserNames = configurationService?.GetConfigValue("PlatformSettings:AdminUserNames") ?? string.Empty;
        string adminUsername = authenticationService?.GetAdminUsername(adminUserNames) ?? string.Empty;
        Log.Information($"Choosing to log as {adminUsername} Admin");
        return adminUsername;
    }

    private static string GetAdminPassword()
    {
        string adminPassword = passwordService?.PromptForPassword("Enter your admin password:") ?? string.Empty;
        Log.Information("Adding Admin Password");
        if (string.IsNullOrEmpty(adminPassword))
        {
            Log.Error("Invalid password. Exiting the program.");
        }
        return adminPassword;
    }

    private static string GetRegistrationPassword()
    {
        string registrationPassword = passwordService?.PromptForPassword("Enter the password to use for registration:") ?? string.Empty;
        Log.Information("Adding Registration Password");
        if (string.IsNullOrEmpty(registrationPassword))
        {
            Log.Error("Invalid registration password. Exiting the program.");
        }
        return registrationPassword;
    }

    private static void RemoveUsers()
    {
        Log.Information("Remove Users method is not implemented yet.");
    }

    private static void UpdateUsers()
    {
        Log.Information("Update Users method is not implemented yet.");
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