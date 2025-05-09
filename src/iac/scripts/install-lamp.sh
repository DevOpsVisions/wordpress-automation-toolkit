#!/bin/bash

# Update and upgrade the system
sudo apt update && sudo apt upgrade -y

sudo DEBIAN_FRONTEND=noninteractive apt-get -y install xfce4

sudo apt install xfce4-session -y

sudo apt-get -y install xrdp

sudo adduser xrdp ssl-cert

echo xfce4-session >~/.xsession

sudo service xrdp restart

sudo apt install firefox -y

sudo apt install unzip

sudo apt install unar

# Install LAMP
sudo apt install lamp-server^ -y

# Verify Apache installation
apache2 -v

# Verify MySQL installation
mysql -V

# Verify PHP installation
php -v
