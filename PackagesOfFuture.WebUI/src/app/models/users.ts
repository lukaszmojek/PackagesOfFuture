import { Address, CreateAddressDto } from "./addresses";

export interface User {
  id: number
  firstName: string        
  lastName: string
  email: string
  type: string
  address: Address
}

export interface RegisterUserDto {
  firstName: string
  lastName: string
  email: string
  type: string
  password: string
  address: CreateAddressDto
}

export interface ChangePasswordDto {
  userId: number, 
  oldPassword: string, 
  newPassword: string
}