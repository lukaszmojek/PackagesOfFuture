import { Address, CreateAddressDto } from "./addresses";

export type UserActionDto = RegisterUserDto | ChangeUserDetailsDto

export enum UserActionType {
  Register,
  Add,
  ChangeDetails
}

export enum UserType
{
  Client = 0,
  Driver = 1,
  Administrator = 2
}

export interface User {
  id: number
  firstName: string        
  lastName: string
  email: string
  type: UserType
  address: Address
}

export interface RegisterUserDto {
  firstName: string
  lastName: string
  email: string
  type: number
  password: string
  address: CreateAddressDto
}
export interface ChangeUserDetailsDto {
  id: number
  firstName: string
  lastName: string
  email: string
  type: number
  address: CreateAddressDto
}

export interface ChangePasswordDto {
  userId: number, 
  oldPassword: string, 
  newPassword: string
}