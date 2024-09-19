module "resource_group" {
  source              = "../../modules/resource-group"
  resource_group_name = local.resource_names["rg"]
  location            = var.location
}

module "network" {
  source              = "../../modules/network"
  resource_group_name = local.resource_names["rg"]
  location            = var.location
  vnet_name           = local.resource_names["vnet"]
  subnet_name         = local.resource_names["subnet"]

  depends_on = [module.resource_group]
}

module "security" {
  source              = "../../modules/security"
  nsg_name            = local.resource_names["nsg"]
  location            = var.location
  resource_group_name = local.resource_names["rg"]
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

  depends_on = [module.resource_group]
}

module "compute" {
  source              = "../../modules/compute"
  pip_name            = local.resource_names["pip"]
  nic_name            = local.resource_names["nic"]
  vm_name             = local.resource_names["vm"]
  location            = var.location
  resource_group_name = local.resource_names["rg"]
  subnet_id           = module.network.subnet_id
  admin_username      = var.admin_username
  admin_password      = var.admin_password
  provisioner_script  = var.provisioner_script

  depends_on = [module.resource_group]
}

resource "azurerm_network_interface_security_group_association" "nsg_association" {
  network_interface_id      = module.compute.nic_id
  network_security_group_id = module.security.nsg_id
}