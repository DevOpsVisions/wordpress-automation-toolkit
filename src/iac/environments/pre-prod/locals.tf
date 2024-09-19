locals {
  workload    = var.workload
  environment = var.environment
  location    = var.location
  instance    = var.instance

  base_name = "${local.workload}-${local.environment}-${local.location}-${local.instance}"

  resource_types = ["rg", "vnet", "subnet", "nsg", "pip", "nic", "vm"]

  resource_names = {
    for resource in local.resource_types :
    resource => "${resource}-${local.base_name}"
  }
}