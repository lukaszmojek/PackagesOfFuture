import { SortingDto } from "./sorting";

export interface DroneDto {
    id: number;
    model: string;
    range: number;
    sortingName: string;
}

export interface RegisterDroneDto {
    model: string;
    range: number;
    sortingId: number;
}

export interface ChangeSortingDroneDto {
    droneId: number;
    sortingId: number;
}

export interface AddEditDrone {
    drone: DroneDto;
    sortings: SortingDto[];
}

export interface EditDroneDto {
    droneId: number;
    sortingId: number;
    model: string;
    range: number;
}