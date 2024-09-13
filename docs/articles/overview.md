# Project Overview

The WordPress Learning Automation Toolkit is a .NET Core application designed to automate various tasks using Selenium WebDriver and other services. The project includes services for configuration management, file path handling, authentication, password management, web driver operations, Excel reading, and user management.

## Main Features

- **Adding Users:** Automates the process of adding new users to the platform.
- **Removing Users:** Automates the process of deleting users from the platform.
- **Membership Updates:** Automates the process of updating user memberships.
- **Reads User Data:** Extracts user information, such as username and email, directly from an Excel file, streamlining the registration process.
- **Secure Password Handling:** Ensures that passwords are handled securely during the registration process, protecting sensitive user information.
- **Flexible File Path Support:** Supports both default and custom file paths for the Excel file, allowing users to easily manage and update user data sources.

## Examples and Use Cases

### Example 1: Adding Users

The following example demonstrates how to add users to the platform using the WordPress Learning Automation Toolkit:

1. Prepare an Excel file with user data, including columns for username, email, and membership level.
2. Run the application and select the "Register Users" option from the menu.
3. Provide the file path to the Excel file, admin username, admin password, and registration password.
4. The application will read the user data from the Excel file and add the users to the platform.

### Example 2: Updating Memberships

The following example demonstrates how to update user memberships using the WordPress Learning Automation Toolkit:

1. Prepare an Excel file with user data, including columns for username, email, and membership level.
2. Run the application and select the "Update Users" option from the menu.
3. Provide the file path to the Excel file, admin username, and admin password.
4. The application will read the user data from the Excel file and update the membership levels for the users on the platform.

### Example 3: Removing Users

The following example demonstrates how to remove users from the platform using the WordPress Learning Automation Toolkit:

1. Prepare an Excel file with user data, including columns for username and email.
2. Run the application and select the "Remove Users" option from the menu.
3. Provide the file path to the Excel file, admin username, and admin password.
4. The application will read the user data from the Excel file and remove the users from the platform.
