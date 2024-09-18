output "public_ip" {
  value = azurerm_public_ip.pip.ip_address
}

output "nic_id" {
  value = azurerm_network_interface.nic.id
}

output "vm_id" {
  value = azurerm_virtual_machine.vm.id
}
