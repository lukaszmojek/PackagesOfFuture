import { AddressDto } from "./address";

export interface RegisterPackageDto {
    deliveryAddress: AddressDto;
    receiveAddress: AddressDto;
    package: PackageDetailsDto;
    serviceId: number;
    payment: CreatePaymentDto;
}

export interface CreatePaymentDto {
    type: number;
    amount: number;
}

export interface PackageDetailsDto {
    width: number;
    height: number;
    length: number;
    weight: number;
}