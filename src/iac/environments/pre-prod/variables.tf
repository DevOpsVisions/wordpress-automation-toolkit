variable "workload" {
  description = "The name of the workload/application"
  type        = string
}

variable "environment" {
  description = "The environment of the deployment"
  type        = string
}

variable "location" {
  description = "The location of the resources"
  type        = string
}

variable "instance" {
  description = "The instance number or identifier"
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
