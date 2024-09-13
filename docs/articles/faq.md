# Frequently Asked Questions (FAQ)

## General Questions

### What is the WordPress Learning Automation Toolkit?

The WordPress Learning Automation Toolkit is a .NET Core application designed to automate various tasks using Selenium WebDriver and other services. It includes services for configuration management, file path handling, authentication, password management, web driver operations, Excel reading, and user management.

### What are the main features of the toolkit?

The main features of the toolkit include:
- Adding Users: Automates the process of adding new users to the platform.
- Removing Users: Automates the process of deleting users from the platform.
- Membership Updates: Automates the process of updating user memberships.
- Reads User Data: Extracts user information, such as username and email, directly from an Excel file, streamlining the registration process.
- Secure Password Handling: Ensures that passwords are handled securely during the registration process, protecting sensitive user information.
- Flexible File Path Support: Supports both default and custom file paths for the Excel file, allowing users to easily manage and update user data sources.

## Installation and Setup

### What are the prerequisites for using the toolkit?

Before you begin, ensure you have the following installed:
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Selenium WebDriver](https://www.selenium.dev/) (ChromeDriver)
- [ExcelDataReader](https://github.com/ExcelDataReader/ExcelDataReader) library for reading Excel files.
- Google Chrome browser installed.

### How do I install the toolkit?

1. Clone the repository:
   ```sh
   git clone https://github.com/DevOpsVisions/wordpress-automation-toolkit.git
   cd wordpress-automation-toolkit
   ```

2. Restore the .NET Core dependencies:
   ```sh
   dotnet restore
   ```

3. Build the project:
   ```sh
   dotnet build
   ```

## Usage

### How do I add users using the toolkit?

1. Prepare an Excel file with user data, including columns for username, email, and membership level.
2. Run the application and select the "Register Users" option from the menu.
3. Provide the file path to the Excel file, admin username, admin password, and registration password.
4. The application will read the user data from the Excel file and add the users to the platform.

### How do I update user memberships using the toolkit?

1. Prepare an Excel file with user data, including columns for username, email, and membership level.
2. Run the application and select the "Update Users" option from the menu.
3. Provide the file path to the Excel file, admin username, and admin password.
4. The application will read the user data from the Excel file and update the membership levels for the users on the platform.

### How do I remove users using the toolkit?

1. Prepare an Excel file with user data, including columns for username and email.
2. Run the application and select the "Remove Users" option from the menu.
3. Provide the file path to the Excel file, admin username, and admin password.
4. The application will read the user data from the Excel file and remove the users from the platform.

## Troubleshooting

### What should I do if the application fails to log in to the admin panel?

1. Verify that the login URL is correct in the `App.config` file.
2. Ensure that the admin username and password are correct.
3. Check if the website is accessible and not down for maintenance.

### What should I do if the user registration fails?

1. Ensure that the `AddNewUserUrl` is correct in the `App.config` file.
2. Verify that the user data in the Excel file is correct and complete.
3. Check if the registration password is correct.

### What should I do if the membership update fails?

1. Verify that the membership level dropdown is correctly identified in the code.
2. Ensure that the membership levels in the Excel file match the options available on the website.
3. Check if the user exists on the platform before attempting to update the membership.

### What should I do if the application cannot find the specified Excel file?

1. Ensure that the file path provided is correct.
2. Verify that the file exists and is accessible.
3. Check if the file extension is correct (e.g., `.xlsx`).

### What should I do if the application encounters WebDriver errors?

1. Ensure that the ChromeDriver is installed and its path is correctly set.
2. Verify that the Google Chrome browser is installed and up to date.
3. Check if the WebDriver version is compatible with the installed Chrome version.
