
using System;
using System.IO;
using Dovs.WordPressAutoKit.Common;
using Dovs.WordPressAutoKit.Interfaces;
using Dovs.WordPressAutoKit.Services;
using OpenQA.Selenium;

/// <summary>  
/// Entry point of the application.  
/// </summary>  
/// 

const int LEVELSTRAVERSE = 2;

IConfigurationService configurationService = new ConfigurationService();
IFilePathService filePathService = new FilePathService();
IAuthenticationService authenticationService = new AuthenticationService(configurationService);
IPasswordService passwordService = new PasswordService();
IWebDriverService webDriverService = new WebDriverService();
IExcelReaderService excelReaderService = new ExcelReaderService();
IUserManagementService userManagementService = new UserManagementService(new MembershipUpdater(), configurationService);
IAdminLoginService adminLoginService = new AdminLoginService(configurationService);

string basePath = filePathService.GetBasePath(LEVELSTRAVERSE);
string defaultFilePath = Path.Combine(basePath, "default.xlsx");

Console.WriteLine("Current default path is: " + defaultFilePath);

string filePath = filePathService.GetFilePath(defaultFilePath);
if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
{
    Console.WriteLine("File not found. Please provide a valid file path.");
    return;
}

/// <summary>  
/// Gets the admin username for login.  
/// </summary>  
string username = authenticationService.GetAdminUsername();
if (string.IsNullOrEmpty(username))
{
    Console.WriteLine("Invalid choice. Exiting the program.");
    return;
}

Console.WriteLine($"Logged in as: {username}");

/// <summary>  
/// Prompts the user for the admin password and the new user password.  
/// </summary>  
string password = passwordService.PromptForPassword("Enter your admin password:");
string newUserPassword = passwordService.PromptForPassword("Enter the password to use for registration:");

/// <summary>  
/// Creates a new WebDriver instance, logs in, reads user data from Excel, and adds new users.  
/// </summary>  
using (IWebDriver driver = webDriverService.CreateWebDriver())
{
    adminLoginService.Login(driver, username, password);
    var userDataList = excelReaderService.ReadUserData(filePath);

    foreach (var userData in userDataList)
    {
        userManagementService.AddNewUser(driver, userData, newUserPassword);
    }

    webDriverService.QuitWebDriver(driver);
}

/// <summary>  
/// Exits the application.  
/// </summary>  
Environment.Exit(0);
