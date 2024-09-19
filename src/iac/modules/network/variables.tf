variable "resource_group_name" {
  description = "The name of the resource group in which to create the network resources"
  type        = string
}

variable "location" {
  description = "The Azure region where the network resources will be created"
  type        = string
}

variable "vnet_name" {
  description = "The name of the virtual network (VNet) resource"
  type        = string
}

variable "subnet_name" {
  description = "The name of the subnet within the virtual network"
  type        = string
}