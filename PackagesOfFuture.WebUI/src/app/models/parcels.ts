import { PackageDetailsDto } from "./packages";

export class ParcelType implements PackageDetailsDto {
    width: number;
    height: number;
    length: number;
    weight: number;
    id: number;
    description: string;
    price: number;
}