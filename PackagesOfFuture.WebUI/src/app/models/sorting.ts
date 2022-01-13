import { AddressDto } from "./address";

export interface SortingDto {
    id: number;
    name: string;
    address: AddressDto;
}

export interface AddSortingDto {
    name: string;
    address: AddressDto;
}

export interface ChangeSortingDetailsDto {
    id: number;
    name: string;
    address: AddressDto;
}

export interface AddChangeSortingData {
    editMode: boolean;
    sortingToEdit: ChangeSortingDetailsDto;
}