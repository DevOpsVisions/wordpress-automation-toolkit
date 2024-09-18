#!/bin/bash

# Update and upgrade the system
sudo apt update && sudo apt upgrade -y

# Install LAMP
sudo apt install lamp-server^ -y

# Verify Apache installation
apache2 -v

# Verify MySQL installation
mysql -V

# Verify PHP installation
php -v