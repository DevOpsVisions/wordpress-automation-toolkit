variable "resource_group_name" {
  description = "The name of the resource group in which to create the network resources"
  type        = string
}

variable "location" {
  description = "The Azure region where the network resources will be created"
  type        = string
}