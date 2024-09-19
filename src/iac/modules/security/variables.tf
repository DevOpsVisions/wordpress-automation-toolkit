variable "nsg_name" {
  description = "The name of the network security group (NSG) resource"
  type        = string
}

variable "location" {
  description = "The Azure region where the network security group will be created"
  type        = string
}

variable "resource_group_name" {
  description = "The name of the resource group in which to create the network security group"
  type        = string
}

variable "security_rules" {
  description = "A list of security rules to apply to the network security group"
  type        = list(object({
    name                       = string
    priority                   = number
    direction                  = string
    access                     = string
    protocol                   = string
    source_port_range          = string
    destination_port_range     = string
    source_address_prefix      = string
    destination_address_prefix = string
  }))
}