
# Deploying or Restoring WordPress on an Azure VM

This guide provides a comprehensive walkthrough for setting up a testing environment on Azure by deploying or restoring WordPress on an Ubuntu VM. The instructions cover preparing a LAMP stack environment, configuring essential components, and deploying the WordPress application. Follow these steps to ensure a smooth deployment and configuration process for testing purposes.

## 1. Preparing a LAMP Stack Environment

To prepare your environment, refer to the following guide:

[Preparing a LAMP Stack Environment for Hosting](https://github.com/DevOpsVisions/common-workspace-hub/blob/main/docs/technical-guides/prepare-lamp-stack-env.md)

## 2. Download and Set Up WordPress

Download the WordPress zip file, whether it's the latest version or a backup from your production environment.

- **Extract the WordPress site from the backup file:**

```bash
unar /home/azureuser/Downloads/backup.tgz
```
The `unar` command extracts the contents of `backup.tgz` to the current directory. Make sure you have the `unar` utility installed.

## 3. Restore WordPress Files

- **Remove all files in the web root directory:**

```bash
sudo rm -r /var/www/html/*
```
*Deletes all existing files in the web server's root directory (`/var/www/html`) to prepare for the restoration.*

- **Copy the backup files to the web root:**

```bash
sudo cp -a /home/azureuser/backup/public_html/. /var/www/html
```
*Copies the restored WordPress files from the backup location to the web server's root directory.*

- **Adjust ownership and permissions:**

```bash
sudo chown -R www-data:www-data /var/www/html/
```
```bash
sudo find /var/www/html -type d -exec chmod 755 {} \;
```
```bash
sudo find /var/www/html -type f -exec chmod 644 {} \;
```
*Sets the correct ownership (`www-data`) and permissions (755 for directories, 644 for files) to ensure the web server can access the files properly.*

## 4. Configure MySQL Database

- **Log in to MySQL:** Log in to MySQL with the root user.

```bash
sudo mysql -p
```
*This command opens the MySQL command line interface. The `-p` option prompts you to enter your MySQL root password.*

- **List all MySQL users:**

```sql
SELECT User, Host FROM mysql.user;
```
*This SQL query displays all existing users and their host permissions in the MySQL server.*

- **Create a new MySQL user for WordPress:**

```sql
CREATE USER 'wordpressUser'@'localhost' IDENTIFIED BY 'YourStrongPassword';
```
*Creates a new MySQL user `wordpressUser` with a strong password, restricted to the local host.*

> [!IMPORTANT]  
> Ensure you use a secure password.

- **Check existing databases:**

```sql
SHOW DATABASES;
```
*Lists all databases on the MySQL server to ensure there is no conflict with the new database name.*

- **Create a new WordPress database:**

```sql
CREATE DATABASE wordpress;
```
```sql
SHOW DATABASES;
```
*Creates a new database named `wordpress` and lists all databases to confirm its creation.*

- **Grant all privileges to the new user:**

```sql
GRANT ALL PRIVILEGES ON wordpress.* TO 'wordpressUser'@'localhost';
```
```sql
FLUSH PRIVILEGES;
```

*Grants full privileges to `wordpressUser` on the `wordpress` database and applies the changes with `FLUSH PRIVILEGES`.*

## 5. Configure WordPress Database

- **Import Database (Optional):** If you are restoring from a production environment backup, use the following commands to import the database:

```sql
USE wordpress;
```
```sql
source /home/azureuser/backup/backup.sql;
```
*Imports the SQL backup file into the newly created `wordpress` database.*

- **Update the site URL and home URL:**

```sql
UPDATE wp_options SET option_value = 'http://test.example.com/' WHERE option_name = 'siteurl';
```
```sql
UPDATE wp_options SET option_value = 'http://test.example.com/' WHERE option_name = 'home';
```
```sql
exit
```
*Modifies the WordPress site URLs to match the new domain or IP address.*

- **Open the `wp-config.php` file for editing:**

```bash
sudo nano /var/www/html/wp-config.php
```
*Uses the `nano` text editor to open the WordPress configuration file. Update database settings to match the new database and user created earlier.*

## 6. Remove Unnecessary Plugins

- **Delete the unnecessary plugin:**

```bash
sudo rm -r /var/www/html/wp-content/plugins/object-cache-pro
```
*Removes the `object-cache-pro` plugin if it is not required.*

## 7. Install Required Extensions

If your WordPress site includes the MasterStudy LMS plugin, the `mbstring` extension is required for proper functionality.

```bash
sudo apt-get install php-mbstring
```
The `php-mbstring` extension is necessary for handling multibyte string operations, especially in the context of LMS plugins like MasterStudy. The installation is performed using `apt-get`, the package manager for Ubuntu/Debian systems.

## 8. Configure Apache

- **Enable `rewrite` module:**

```bash
sudo a2enmod rewrite
```
*Enables the Apache rewrite module to allow URL rewriting, which is often necessary for WordPress permalinks.*

- **Restart Apache:**

```bash
sudo systemctl restart apache2
```
*Restarts the Apache server to apply changes.*

- **Open Apache configuration file:**

```bash
sudo nano /etc/apache2/apache2.conf
```
*Opens the Apache configuration file for editing.*

- **Edit and ensure the following configuration exists:**
```
<Directory /var/www/html/>
   Options Indexes FollowSymLinks
   AllowOverride All
   Require all granted
</Directory>
```
*Allows Apache to override settings with `.htaccess` files and ensures proper access control.*

- **Restart Apache:**

```bash
sudo systemctl restart apache2
```
*Restarts the Apache server to apply the new configuration.*

## 9. Install WP-CLI

- **Download WP-CLI:** as we need it later in the next step

```bash
curl -O https://raw.githubusercontent.com/wp-cli/builds/gh-pages/phar/wp-cli.phar
```
*Downloads the WP-CLI executable for managing WordPress installations via command line.*

- **Check WP-CLI information:**

```bash
php wp-cli.phar --info
```
*Verifies the installation and configuration of WP-CLI.*

- **Make WP-CLI executable and move it:**

```bash
chmod +x wp-cli.phar
```
```bash
sudo mv wp-cli.phar /usr/local/bin/wp
```
```bash
wp --info
```
*Makes the WP-CLI file executable and moves it to a directory in the system's `PATH` for global access.*

## 10. Replace URLs and Flush Cache

- **Navigate to the WordPress installation directory:**

```bash
cd /var/www/html/
```
*Changes the current working directory to the WordPress root directory.*

- **Replace all URLs:**

```bash
wp search-replace 'https://example.com/' 'http://test.example.com/' --all-tables
```
```bash
wp cache flush
```
*Replaces old URLs with the new ones across all database tables and clears the WordPress cache.*

## 11. Adjust Plugin Permissions

- **Correct plugin ownership and permissions:**

```bash
sudo chown -R www-data:www-data /var/www/html/wp-content/plugins/
```
```bash
sudo chmod -R 755 /var/www/html/wp-content/plugins/
```
*Ensures the correct ownership and permissions are set for the plugins directory to avoid permission errors.*

## 12. Clean Up Unnecessary Plugins

- **Remove unnecessary plugins from the WordPress admin panel.** Log in to the WordPress admin dashboard and delete any unused plugins to maintain a clean and secure environment.*

## 12. Final Checks and Testing

**Test the WordPress site:**

- Navigate to the site's URL in your web browser to ensure it is loading correctly.
- Log in to the WordPress admin dashboard and verify that all settings and plugins are configured as expected.
- Check the functionality of the MasterStudy LMS plugin to ensure it is working properly.
