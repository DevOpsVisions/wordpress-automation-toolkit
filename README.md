# WordPress Learning Automation Toolkit

## Overview

WordPress Learning Automation Toolkit is a .NET Core application designed to automate various tasks using Selenium WebDriver and other services. 
The project includes services for configuration management, file path handling, authentication, password management, web driver operations, Excel reading, and user management.

## Purpose

The primary purpose of this project is to provide a comprehensive automation framework that can be used to automate repetitive tasks, such as adding users, removing users, membership updates, and data extraction from Excel files. 
By leveraging Selenium WebDriver, the application can interact with web pages and perform several actions like a human user. This makes it ideal for tasks that require web interaction, such as automated workflow data scraping, and web form submissions.

## Features
- **Adding Users:** Automates the process of adding new users to the platform.
- **Removing Users:** Automates the process of deleting users from the platform.
- **Membership Updates:** Automates the process of updating user memberships.
- **Reads User Data:** Extracts user information, such as username and email, directly from an Excel file, streamlining the registration process.
- **Secure Password Handling:** Ensures that passwords are handled securely during the registration process, protecting sensitive user information.
- **Flexible File Path Support:** Supports both default and custom file paths for the Excel file, allowing users to easily manage and update user data sources.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Selenium WebDriver](https://www.selenium.dev/) (ChromeDriver)
- [ExcelDataReader](https://github.com/ExcelDataReader/ExcelDataReader) library for reading Excel files.
- Google Chrome browser installed.

## Documentation

### Generating Documentation

To generate the technical documentation for the project, follow these steps:

1. Install [DocFX](https://dotnet.github.io/docfx/):
   ```sh
   choco install docfx -y
   ```

2. Navigate to the `docs` directory:
   ```sh
   cd docs
   ```

3. Run DocFX to generate the documentation:
   ```sh
   docfx
   ```

The generated documentation will be available in the `_site` directory.

### Accessing Documentation

The documentation is hosted on GitHub Pages and can be accessed at the following URL:

[https://devopsvisions.github.io/wordpress-automation-toolkit/](https://devopsvisions.github.io/wordpress-automation-toolkit/)
