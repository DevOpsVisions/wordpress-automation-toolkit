module "network" {
  source              = "./modules/network"
  resource_group_name = var.resource_group_name
  location            = var.location
  vnet_name           = var.vnet_name
  subnet_name         = var.subnet_name
}

module "security" {
  source              = "./modules/security"
  nsg_name            = var.nsg_name
  location            = module.network.location
  resource_group_name = module.network.resource_group_name
  security_rules = [
    {
      name                       = "SSH"
      priority                   = 1001
      direction                  = "Inbound"
      access                     = "Allow"
      protocol                   = "Tcp"
      source_port_range          = "*"
      destination_port_range     = "22"
      source_address_prefix      = "*"
      destination_address_prefix = "*"
    },
    {
      name                       = "RDP"
      priority                   = 1002
      direction                  = "Inbound"
      access                     = "Allow"
      protocol                   = "Tcp"
      source_port_range          = "*"
      destination_port_range     = "3389"
      source_address_prefix      = "*"
      destination_address_prefix = "*"
    },
    {
      name                       = "HTTP"
      priority                   = 1003
      direction                  = "Inbound"
      access                     = "Allow"
      protocol                   = "Tcp"
      source_port_range          = "*"
      destination_port_range     = "80"
      source_address_prefix      = "*"
      destination_address_prefix = "*"
    }
  ]
}

module "compute" {
  source              = "./modules/compute"
  pip_name            = var.pip_name
  nic_name            = var.nic_name
  vm_name             = var.vm_name
  location            = module.network.location
  resource_group_name = module.network.resource_group_name
  subnet_id           = module.network.subnet_id
  admin_username      = var.admin_username
  admin_password      = var.admin_password
  provisioner_script  = var.provisioner_script
}

resource "azurerm_network_interface_security_group_association" "nsg_association" {
  network_interface_id      = module.compute.nic_id
  network_security_group_id = module.security.nsg_id
}