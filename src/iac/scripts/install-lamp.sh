#!/bin/bash

# Update and upgrade the system
sudo apt update && sudo apt upgrade -y

# Install prerequisites
sudo apt install -y software-properties-common

# Add the PHP 8.1 PPA
sudo add-apt-repository ppa:ondrej/php -y
sudo apt update

# Install Apache
sudo apt install -y apache2

# Install PHP 8.1 and common modules
sudo apt install -y php8.1 libapache2-mod-php8.1 php8.1-mysql

# Install MySQL Server
sudo apt install -y mysql-server

# Restart Apache to apply PHP module
sudo systemctl restart apache2

# Verify installations
apache2 -v
mysql --version
php -v
