variable "pip_name" {
  description = "The name of the public IP address resource"
  type        = string
}

variable "nic_name" {
  description = "The name of the network interface card (NIC) resource"
  type        = string
}

variable "vm_name" {
  description = "The name of the virtual machine resource"
  type        = string
}

variable "location" {
  description = "The Azure region where the resources will be created"
  type        = string
}

variable "resource_group_name" {
  description = "The name of the resource group in which to create the resources"
  type        = string
}

variable "subnet_id" {
  description = "The ID of the subnet in which to create the resources"
  type        = string
}

variable "admin_username" {
  description = "The admin username for the virtual machine"
  type        = string
}

variable "admin_password" {
  description = "The admin password for the virtual machine"
  type        = string
}

variable "provisioner_script" {
  description = "The path to the script that will be used to provision configurations on the virtual machine"
  type        = string
}