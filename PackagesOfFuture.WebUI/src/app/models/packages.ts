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

export interface PackageDto {
    id: number;
    deliveryDate: Date;
    status: number;
    width: number;
    height: number;
    length: number;
    weight: number;
    payment: PaymentDto;
    deliveryAddress: AddressDto;
    receiveAddress: AddressDto;

    deliveryAddressId: number;
    receiveAddressId: number;
}

export interface PaymentDto {
    id: number;
    type: number;
    amount: number;
    status: number;
}

export interface ChangeStatusPaymentDto {
    paymentId: number;
    paymentStatus: number;
}

export interface ChangePackageStatusDto {
    packageId: number;
    statusId: number;
}