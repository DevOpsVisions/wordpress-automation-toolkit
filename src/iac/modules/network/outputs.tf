output "resource_group_name" {
  value = azurerm_resource_group.rg.name
}

output "location" {
  value = azurerm_resource_group.rg.location
}

output "subnet_id" {
  value = azurerm_subnet.subnet.id
}

output "vnet_name" {
  value = azurerm_virtual_network.vnet.name
}