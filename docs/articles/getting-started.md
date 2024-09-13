# Getting Started

This guide will help you set up and use the WordPress Learning Automation Toolkit.

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Selenium WebDriver](https://www.selenium.dev/) (ChromeDriver)
- [ExcelDataReader](https://github.com/ExcelDataReader/ExcelDataReader) library for reading Excel files.
- Google Chrome browser installed.

## Installation

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

### Adding Users

1. Prepare an Excel file with user data, including columns for username, email, and membership level.
2. Run the application and select the "Register Users" option from the menu.
3. Provide the file path to the Excel file, admin username, admin password, and registration password.
4. The application will read the user data from the Excel file and add the users to the platform.

### Updating Memberships

1. Prepare an Excel file with user data, including columns for username, email, and membership level.
2. Run the application and select the "Update Users" option from the menu.
3. Provide the file path to the Excel file, admin username, and admin password.
4. The application will read the user data from the Excel file and update the membership levels for the users on the platform.

### Removing Users

1. Prepare an Excel file with user data, including columns for username and email.
2. Run the application and select the "Remove Users" option from the menu.
3. Provide the file path to the Excel file, admin username, and admin password.
4. The application will read the user data from the Excel file and remove the users from the platform.
