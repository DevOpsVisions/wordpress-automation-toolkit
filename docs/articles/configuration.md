# Configuration

This section provides details on configuring the WordPress Learning Automation Toolkit.

## Configuration Options

The following configuration options are available:

### Platform Settings

- **LoginUrl**: The URL for the admin login page.
- **AddNewUserUrl**: The URL for adding new users.
- **Admin1UserNameOrEmail**: The username or email of the first admin.
- **Admin2UserNameOrEmail**: The username or email of the second admin.
- **PreRegisterRole**: The role assigned to users before registration.
- **PostRegisterRole**: The role assigned to users after registration.

### Data Columns

- **UserNameColumn**: The column name for the username in the Excel file.
- **EmailColumn**: The column name for the email in the Excel file.
- **MembershipColumn**: The column name for the membership level in the Excel file.
- **ColumnNames**: A comma-separated list of column names in the Excel file.

## Usage

To configure the application, update the `App.config` file with the appropriate values for your environment. Here is an example configuration:

```xml
<configuration>
  <appSettings>
    <!-- Platform Settings -->
    <add key="LoginUrl" value="https://example.com/admin"/>
    <add key="AddNewUserUrl" value="https://example.com/wp-admin/user-new.php"/>
    <add key="Admin1UserNameOrEmail" value="Admin1UserNameOrEmail"/>
    <add key="Admin2UserNameOrEmail" value="Admin2UserNameOrEmail"/>
    <add key="PreRegisterRole" value="pre_register"/>
    <add key="PostRegisterRole" value="member"/>

    <!-- Data Columns -->
    <add key="UserNameColumn" value="Username" />
    <add key="EmailColumn" value="Email" />
    <add key="MembershipColumn" value="Membership" />
    <add key="ColumnNames" value="Username,Email,Membership" />
  </appSettings>
</configuration>
```

Update the values as needed to match your environment and requirements.
